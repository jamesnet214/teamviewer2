using SignalR.EasyUse.Interface;

namespace TeamViewer2.Based
{
    public class ReceiveMessage : IClientMethod
    {
        public string User { get; set; }
        public string Message { get; set; }
    }
}