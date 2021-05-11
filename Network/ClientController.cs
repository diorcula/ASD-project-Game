﻿using System;
using System.Collections.Generic;
using Network.DTO;
using Newtonsoft.Json;

namespace Network
{
    public class ClientController : IPacketHandler
    {
        private NetworkComponent _networkComponent;
        private HostController _hostController;
        private string _sessionId;
        private Dictionary<string, PacketDTO> _availableGames = new();
        private Dictionary<PacketType, IPacketHandler> _subscribers = new();

        public ClientController(NetworkComponent networkComponent)
        {
            _networkComponent = networkComponent;
        }

        public HandlerResponseDTO HandlePacket(PacketDTO packet)
        {
            if(packet.Header.SessionID == _sessionId || packet.Header.PacketType == PacketType.Session)
            {
                return _subscribers.GetValueOrDefault(packet.Header.PacketType).HandlePacket(packet);
            }
            else
            {
                return new HandlerResponseDTO(true, null);
            }



/*            if (packet.Header.PacketType == PacketType.GameAvailable)
            {
                _availableGames.Add(packet.Header.SessionID, packet);
                Console.WriteLine(packet.Header.SessionID + ": " + packet.Payload);
                
                return true;
            }

            if (packet.Header.PacketType == PacketType.ClientJoinedGame && IsTheSameSession(packet.Header.SessionID))
            {
                List<string> clients = JsonConvert.DeserializeObject<List<string>>(packet.Payload);
                if (clients != null)
                {
                    foreach (string client in clients)
                    {
                        _session.AddClient(client);
                    }
                    Console.WriteLine("Clients in current session:");
                    int index = 1;
                    foreach (string client in _session.GetAllClients())
                    {
                        Console.WriteLine(index + ". " + client);
                        index++;
                    }
                }

                return true;
            }
            else
            {
                return _subscribers.GetValueOrDefault(packet.Header.PacketType).HandlePacket(packet);
            }*/
        }

        public void SetSessionId(string sessionId)
        {
            _sessionId = sessionId;
            if(_hostController != null)
            {
                _hostController.SetSessionId(sessionId);
            }
        }

        public void CreateHostController()
        {
            _hostController = new HostController(_networkComponent, this, _sessionId);
        }

        public string GetOriginId()
        {
            return _networkComponent.OriginId;
        }

        public void SendPayload(string payload, PacketType packetType)
        {
            if (String.IsNullOrEmpty(payload))
            {
                throw new Exception("Payload is empty.");
            }

            PacketDTO packet = new PacketBuilder()
                .SetTarget("host")
                .SetPacketType(packetType)
                .SetPayload(payload)
                .SetSessionID(_sessionId)
                .Build();

            if (_hostController != null)
            {
                _hostController.ReceivePacket(packet); //host must check for session?
            }
            else
            {
                _networkComponent.SendPacket(packet);
            }
        }

        public void CreateGame(string sessionName)
        {
            _session = new Session(sessionName);
            _session.GenerateSessionId();
            _session.AddClient(_networkComponent.OriginId); // Add yourself to the clients in this session.
            _hostController = new HostController(_networkComponent, this, _session);
        }

        public void JoinGame(string sessionId)
        {
            if (!_availableGames.TryGetValue(sessionId, out PacketDTO packetDTO))
            {
                Console.WriteLine("Could not find game!");
                return;
            }

            _session = new Session(packetDTO.Payload);
            _session.SessionId = sessionId;
            Console.WriteLine("Trying to join game with name: " + _session.Name);

            PacketDTO newPacketDTO = new PacketBuilder()
                .SetTarget("host")
                .SetSessionID(_session.SessionId)
                .SetPacketType(PacketType.RequestToJoinGame)
                .SetPayload("payload")
                .Build();

            _networkComponent.SendPacket(newPacketDTO);
        }

        public void FindGames()
        {
            PacketDTO packetDTO = new PacketBuilder()
                .SetTarget("host")
                .SetPacketType(PacketType.GameAvailability)
                .SetPayload("testPayload")
                .Build();

            _networkComponent.SendPacket(packetDTO);
        }

        private bool IsTheSameSession(string sessionId)
        {
            return sessionId == _session.SessionId;
        }

        public void SubscribeToPacketType(IPacketHandler packetHandler, PacketType packetType)
        {
            _subscribers.Add(packetType, packetHandler);
        }
    }
}