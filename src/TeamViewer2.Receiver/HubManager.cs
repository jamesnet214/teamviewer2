using Microsoft.AspNetCore.SignalR.Client;
using System.Windows;
using TeamViewer2.Core.Models;

namespace TeamViewer2.Receiver
{
    public class HubManager
    {
        public HubConnection Connection;

        public static HubManager Create()
        {
            HubManager hubManager = new();
            hubManager.Connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:32767/chathub")
                .Build();

            return hubManager;
        }

        public async void Start()
        {
            Connection.On<MessageModel>("ResponseMessagePack", (message) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{message.UserInfo.Name}\n{message.DataType}";
                    //Messages.Add(new MessageModel(newMessage));
                });
            });

            try
            {
                await Connection.StartAsync();
            }
            catch (Exception ex)
            {
            }
        }
    }
}