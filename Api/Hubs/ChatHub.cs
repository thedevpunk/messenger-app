using System;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
    public class ChatHub : Hub<IClient>
    {
        private readonly ConnectionStore _connectionStore;
        public ChatHub(ConnectionStore connectionStore)
        {
            _connectionStore = connectionStore;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public async Task Subscribe(string userId)
        {
            _connectionStore.Add(userId, Context.ConnectionId);

            await Clients.Caller.ReiveiceConnected(userId);
        }

        public async Task SendMessage(string reveicerId, Message message)
        {
            string receiverConnectionId = _connectionStore.GetConnectionId(reveicerId);

            Console.WriteLine(message.Sender.Id + " has send a message to " + reveicerId);
        
            await Clients.All.ReceiveMessage(message);
        }

    }
}