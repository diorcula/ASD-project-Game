using ActionHandling;
using Chat;
using InputHandling.Antlr.Ast;
using InputHandling.Antlr.Ast.Actions;
using InputHandling.Exceptions;
using Network;
using Newtonsoft.Json;
using Session;
using Creature;
using Session.DTO;
using Session.GameConfiguration;
using AST = InputHandling.Antlr.Ast.AST;
using ItemFrequency = InputHandling.Antlr.Ast.Actions.ItemFrequency;
using MonsterDifficulty = InputHandling.Antlr.Ast.Actions.MonsterDifficulty;


namespace InputHandling.Antlr.Transformer
{
    public class Evaluator : IEvaluator
    {
        private ISessionHandler _sessionHandler;
        private IMoveHandler _moveHandler;
        private IGameSessionHandler _gameSessionHandler;
        private IChatHandler _chatHandler;
        private IAgentHandler _agentHandler;
        
        private IClientController _clientController;
        private IInventoryHandler _inventoryHandler;
        private const int MINIMUM_STEPS = 1;
        private const int MAXIMUM_STEPS = 10;
        private string _commando;

        public Evaluator(ISessionHandler sessionHandler, IMoveHandler moveHandler, IGameSessionHandler gameSessionHandler, IChatHandler chatHandler, IInventoryHandler inventoryHandler, IClientController clientController, IAgentHandler agentHandler)
        {
            _sessionHandler = sessionHandler;
            _moveHandler = moveHandler;
            _gameSessionHandler = gameSessionHandler;
            _chatHandler = chatHandler;
            _agentHandler = agentHandler;
            _clientController = clientController;
            _inventoryHandler = inventoryHandler;
        }
        public void Apply(AST ast)
        {
            TransformNode(ast.Root);
        }

        private void TransformNode(ASTNode node)
        {
            var input = (Input)node;
            var nodeBody = input.Body;
            for (int i = 0; i < nodeBody.Count; i++)
                switch (nodeBody[i])
                {
                    case Attack:
                        TransformAttack((Attack)nodeBody[i]);
                        break;
                    case Drop:
                        TransformDrop((Drop)nodeBody[i]);
                        break;
                    case Exit:
                        TransformExit();
                        break;
                    case Move:
                        TransformMove((Move)nodeBody[i]);
                        break;
                    case Pause:
                        TransformPause();
                        break;
                    case Pickup:
                        TransformPickup((Pickup)nodeBody[i]);
                        break;
                    case Replace:
                        TransformReplace();
                        break;
                    case Resume:
                        TransformResume();
                        break;
                    case Say:
                        TransformSay((Say)nodeBody[i]);
                        break;
                    case Shout:
                        TransformShout((Shout)nodeBody[i]);
                        break;
                    case CreateSession:
                        TransformCreateSession((CreateSession)nodeBody[i]);
                        break;
                    case JoinSession:
                        TransformJoinSession((JoinSession)nodeBody[i]);
                        break;
                    case RequestSessions:
                        TransformRequestSessions((RequestSessions)nodeBody[i]);
                        break;
                    case StartSession:
                        TransformStartSession((StartSession)nodeBody[i]);
                        break;
                    case MonsterDifficulty:
                        TransformMonsterDifficulty((MonsterDifficulty)nodeBody[i]);
                        break;
                    case ItemFrequency:
                        TransformItemFrequency((ItemFrequency)nodeBody[i]);
                        break;
                    case Inspect:
                        TransformInspect((Inspect)nodeBody[i]);
                        break;    
                    case Use:
                        TransformUse((Use)nodeBody[i]);
                        break;
                    case Search:
                        TransformSearch();
                        break;
                }
        }

        private void TransformUse(Use use)
        {
            _inventoryHandler.UseItem(use.Step.StepValue);
        }

        private void TransformMove(Move move)
        {
            switch (move.Steps.StepValue)
            {
                case < MINIMUM_STEPS:
                    throw new MoveException($"Too few steps, the minimum is {MINIMUM_STEPS}.");
                case > MAXIMUM_STEPS:
                    throw new MoveException($"Too many steps, the maximum is {MAXIMUM_STEPS}.");
                default:
                    _moveHandler.SendMove(move.Direction.DirectionValue, move.Steps.StepValue);
                    break;
            }
        }

        private void TransformPickup(Pickup pickup)
        {
            _inventoryHandler.PickupItem(pickup.Item.StepValue);
        }

        private void TransformDrop(Drop drop)
        {
            _inventoryHandler.DropItem(drop.InventorySlot.InventorySlotValue);
        }

        private void TransformAttack(Attack attack)
        {
            // TODO: Call AttackHandler method with (attack.Direction.DirectionValue)
        }

        private void TransformExit()
        {
            // TODO: Implement exitHandler
        }

        private void TransformPause()
        {
            // TODO: Remove? Must be replaced by save
        }

        private void TransformReplace()
        {
            _agentHandler.Replace();
        }

        private void TransformResume()
        {
            // TODO: Remove? Must be replaced by load functionality
        }

        private void TransformSay(Say say)
        {
            _chatHandler.SendSay(say.Message.MessageValue);
        }

        private void TransformShout(Shout shout)
        {
            _chatHandler.SendShout(shout.Message.MessageValue);
        }

        private void TransformCreateSession(CreateSession createSession)
        {
            _sessionHandler.CreateSession(createSession.Message.MessageValue, createSession.Username.UsernameValue);
        }

        private void TransformJoinSession(JoinSession joinSession)
        {
            _sessionHandler.JoinSession(joinSession.Message.MessageValue, joinSession.Username.UsernameValue);
        }

        private void TransformRequestSessions(RequestSessions requestSessions)
        {
            _sessionHandler.RequestSessions();
        }

        private void TransformStartSession(StartSession startSession)
        {
            _gameSessionHandler.SendGameSession();
        }

        private void TransformMonsterDifficulty(MonsterDifficulty monster)
        {
            if (!_clientController.IsHost())//TODO Check GameStarted wordt toegevoegd in andere feature
            {
                return;
            }

            int difficulty = -1;
            switch (monster.Difficulty)
            {
                case "easy":
                    difficulty = (int) Session.GameConfiguration.MonsterDifficulty.Easy;
                    break;
                case "medium":
                    difficulty = (int) Session.GameConfiguration.MonsterDifficulty.Medium;
                    break;
                case "hard":
                    difficulty = (int) Session.GameConfiguration.MonsterDifficulty.Hard;
                    break;
                case "impossible":
                    difficulty = (int) Session.GameConfiguration.MonsterDifficulty.Impossible;
                    break;
            }

            SessionDTO sessionDto = new SessionDTO
            {
                SessionType = SessionType.EditMonsterDifficulty,
                Name = difficulty.ToString()
            };
            SendPayload(sessionDto);
        }

        private void TransformItemFrequency(ItemFrequency itemFrequency)
        {
            if (!_clientController.IsHost()) //TODO Check GameStarted wordt toegevoegd in andere feature
            {
                return;
            }
            
            int frequency = -1;
            switch (itemFrequency.Frequency)
            {
                case "low":
                    frequency = (int) ItemSpawnRate.Low;
                    break;
                case "medium":
                    frequency = (int) ItemSpawnRate.Medium;
                    break;
                case "high":
                    frequency = (int) ItemSpawnRate.High;
                    break;
            }
            SessionDTO sessionDto = new SessionDTO
            {
                SessionType = SessionType.EditItemSpawnRate,
                Name = frequency.ToString()
            };
            SendPayload(sessionDto);
        }

        private void SendPayload(SessionDTO sessionDto)
        {
            var jsonObject = JsonConvert.SerializeObject(sessionDto);
            _clientController.SendPayload(jsonObject, PacketType.Session);
        }
        private void TransformInspect(Inspect inspect)
        {
            string slot = inspect.InventorySlot.InventorySlotValue;
            if (slot == "armor" | slot == "weapon" | slot == "helmet" | slot == "slot 1" | slot == "slot 2" | slot == "slot 3")
            {
                _inventoryHandler.InspectItem(inspect.InventorySlot.InventorySlotValue);
            }
            else
            {
                throw new SlotException($"The slot you provided {slot} is not valid.");
            }
        }

        private void TransformSearch()
        {
            _inventoryHandler.Search();
        }
    }
}