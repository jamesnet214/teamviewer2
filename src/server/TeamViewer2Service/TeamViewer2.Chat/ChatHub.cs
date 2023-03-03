using Microsoft.AspNetCore.SignalR;
using SignalR.EasyUse.Server;
using TeamViewer2.Based.Models.DataPack;
using TeamViewer2.Based.Models.MessageData;

namespace TeamViewer2.Chat
{
    public class ChatHub : Hub
    {
        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync(new ReceiveMessage
        //    {
        //        User = user,
        //        Message = message + $" {DateTime.Now}"
        //    });
        //}

        public async Task SendMessage(MessageModel request)
        {
            ResponseMessagePack pack = new();
            pack.Response = request;
            await Clients.All.SendAsync(pack);
        }
    }
}