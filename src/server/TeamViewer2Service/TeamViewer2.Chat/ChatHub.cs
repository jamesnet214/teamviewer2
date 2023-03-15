using Microsoft.AspNetCore.SignalR;
using SignalR.EasyUse.Server;
using TeamViewer2.Based.Models.DataPack;
using TeamViewer2.Based.Models.MessageData;
using TeamViewer2.EntityContext.Entites;
using TeamViewer2.EntityContext.Services;

namespace TeamViewer2.Chat
{
    public class ChatHub : Hub
    {
        private UserService _userService;

        public ChatHub(UserService userService)
        {
            _userService = userService;
        }

        public async Task SendMessage(MessageModel request)
        {

            //var newUser = new User
            //{
            //    FullName = "John Doe",
            //    Nickname = "johnny",
            //    Email = "john.doe@example.com",
            //    Password = "your_password_hash",
            //    Thumbnail = null,
            //    CreatedAt = DateTime.Now,
            //    UpdatedAt = DateTime.Now
            //};

            //await _userService.AddUserAsync(newUser);

            ResponseMessagePack pack = new();
            pack.Response = request;
            await Clients.All.SendAsync(pack);
        }
    }
}