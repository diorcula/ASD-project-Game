﻿using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using ActionHandling.DTO;
using DatabaseHandler;
using DatabaseHandler.POCO;
using DatabaseHandler.Repository;
using DatabaseHandler.Services;
using Network.DTO;
using Newtonsoft.Json;
using WorldGeneration;
using System.Numerics;

namespace ActionHandling
{
    public class MoveHandler : IMoveHandler, IPacketHandler
    {
        private IClientController _clientController;
        private IWorldService _worldService;

        private List<Character> _creatureMoves = new List<Character>();

        public MoveHandler(IClientController clientController, IWorldService worldService)
        {
            _clientController = clientController;
            _clientController.SubscribeToPacketType(this, PacketType.Move);
            _worldService = worldService;
        }

        public void SendMove(string directionValue, int stepsValue)
        {
            int x = 0;
            int y = 0;
            switch (directionValue)
            {
                case "right":
                case "east":
                    x = stepsValue;
                    break;

                case "left":
                case "west":
                    x = -stepsValue;
                    break;

                case "forward":
                case "up":
                case "north":
                    y = +stepsValue;
                    break;

                case "backward":
                case "down":
                case "south":
                    y = -stepsValue;
                    break;
            }

            var currentPlayer = _worldService.getCurrentPlayer();

            MoveDTO moveDTO = new(currentPlayer.Id, currentPlayer.XPosition + x, currentPlayer.YPosition + y);

            SendMoveDTO(moveDTO);
        }

        public void MoveAIs()
        {
            foreach (Character move in _creatureMoves)
            {
                MoveDTO moveDTO = new(move.Id, (int)move.Destination.X, (int)move.Destination.Y);
                SendMoveDTO(moveDTO);
            }
        }

        public void GetAIMoves()
        {
            _creatureMoves = _worldService.getCreatureMoves();
        }

        private void SendMoveDTO(MoveDTO moveDTO)
        {
            var payload = JsonConvert.SerializeObject(moveDTO);
            _clientController.SendPayload(payload, PacketType.Move);
            MoveAIs();
        }

        public HandlerResponseDTO HandlePacket(PacketDTO packet)
        {
            var moveDTO = JsonConvert.DeserializeObject<MoveDTO>(packet.Payload);

            //check for backup host like comments below
            //(_clientController.IsHost() && packet.Header.Target.Equals("host")) || _clientController.IsBackupHost)
            if (_clientController.IsHost() && packet.Header.Target.Equals("host"))
            {
                var servicePlayer = new DatabaseService<PlayerPOCO>();

                var allLocations = servicePlayer.GetAllAsync();

                allLocations.Wait();

                int newPosPlayerX = moveDTO.XPosition;
                int newPosPlayerY = moveDTO.YPosition;

                var result =
                    allLocations.Result.Where(x =>
                        x.XPosition == newPosPlayerX && x.YPosition == newPosPlayerY &&
                        x.GameGUID == _clientController.SessionId);

                if (result.Any())
                {
                    return new HandlerResponseDTO(SendAction.ReturnToSender, "Can't move to new position something is in the way");
                }
                else
                {
                    InsertToDatabase(moveDTO);
                    HandleMove(moveDTO);
                }
            }
            else if (packet.Header.Target.Equals(_clientController.GetOriginId()))
            {
                Console.WriteLine(packet.HandlerResponse.ResultMessage);
            }
            else
            {
                HandleMove(moveDTO);
            }

            return new HandlerResponseDTO(SendAction.SendToClients, null);
        }

        private void InsertToDatabase(MoveDTO moveDTO)
        {
            var playerService = new DatabaseService<PlayerPOCO>();
            var player = playerService.GetAllAsync().Result.FirstOrDefault(player => player.PlayerGUID == moveDTO.UserId);

            player.XPosition = moveDTO.XPosition;
            player.YPosition = moveDTO.YPosition;
            playerService.UpdateAsync(player);
        }

        private void HandleMove(MoveDTO moveDTO)
        {
            _worldService.UpdateCharacterPosition(moveDTO.UserId, moveDTO.XPosition, moveDTO.YPosition);
            _worldService.DisplayWorld();
        }
    }
}