﻿namespace Network
{
    public class HostController : IPacketListener
    {
        private NetworkComponent _networkComponent;
        private IPacketHandler _client;
        private Session _session;

        public HostController(NetworkComponent networkComponent, IPacketHandler client, Session session)
        {
            _networkComponent = networkComponent;
            _client = client;
            _session = session;
            _networkComponent.Host = this;
        }

        public void ReceivePacket(PacketDTO packet)
        {
            if (packet.Header.PacketType == PacketType.GameAvailability)
            {
                PacketDTO packetDto = new PacketBuilder()
                    .SetSessionID(_session.SessionId)
                    .SetTarget("client")
                    .SetPacketType(PacketType.GameAvailable)
                    .SetPayload(_session.Name)
                    .Build();

                _networkComponent.SendPacket(packetDto);
            }
            else if(packet.Header.SessionID == _session.SessionId)
            {
                bool succesfullyHandledPacket = _client.HandlePacket(packet);
                if (succesfullyHandledPacket)
                {
                    packet.Header.Target = "client";
                    _networkComponent.SendPacket(packet);
                }
                else
                {
                    //TODO: send error
                }
            }
        }
    }
}
