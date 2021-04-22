using System;
using System.Security.Cryptography;
using Chat.antlr.ast;
using Chat.antlr.ast.actions;
using Player;

namespace Chat.antlr.transformer
{
    public class Evaluator : ITransform
    {
        private readonly IPlayerModel _playerModel;

        public Evaluator(IPlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void apply(AST ast)
        {
            transformNode(ast.root);
        }

        private void transformNode(ASTNode node)
        {
            var input = (Input)node;
            var nodeBody = input.body;
            for (int i = 0; i < nodeBody.Count; i++)
                switch (nodeBody[i])
                {
                    case Move:
                        transformMove((Move)nodeBody[i]);
                        break;
                    case Pickup:
                        transformPickup((Pickup)nodeBody[i]);
                        break;
                }
        }

        private void transformMove(Move move)
        {
            {
                _playerModel.HandleDirection(move.direction.ToString(), move.steps.value);
            }
        }

        private void transformPickup(Pickup pickup)
        {
            _playerModel.HandleItemAction("pickup");     
        }

        private void transformPickup(Drop drop)
        {
            _playerModel.HandleItemAction("drop");
        }

        private void transformPickup(Attack attack)
        {
            _playerModel.HandleItemAction("attack");
        }

        private void transformPickup(Exit exit)
        {
            _playerModel.HandleItemAction("exit");
        }

        private void transformPickup(Pause pause)
        {
            _playerModel.HandleItemAction("pause");
        }

        private void transformPickup(Replace replace)
        {
            _playerModel.HandleItemAction("replace");
        }

        private void transformPickup(Resume resume)
        {
            _playerModel.HandleItemAction("resume");
        }

        private void transformPickup(Say say)
        {
            _playerModel.HandleItemAction("say");
        }

        private void transformPickup(Shout shout)
        {
            _playerModel.HandleItemAction("shout");
        }
    }
}