using Microsoft.AspNetCore.SignalR.Client;
using Prism.Events;
using System.Windows;
using TeamViewer2.Core.Models;

namespace TeamViewer2.Receiver
{
    public class HubManager
    {
        public HubConnection Connection;
        private IEventAggregator _ea;

        public int Test { get; private set; }

        public static HubManager Create()
        {
            HubManager hubManager = new();
            hubManager.Connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:32767/chathub")
                .Build();

            return hubManager;
        }

        public async void Start(IEventAggregator ea)
        {
            _ea = ea;

            Test = 113;

            Connection.On<MessageModel>("ResponseMessagePack", (message) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    _ea.GetEvent<PubSubEvent<MessageModel>>().Publish(message);
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