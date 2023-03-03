using SignalR.EasyUse.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamViewer2.Based.Models.MessageData;

namespace TeamViewer2.Based.Models.DataPack
{
    public class ResponseMessagePack : IClientMethod
    {
        public MessageModel Response { get; set; }
    }
}
