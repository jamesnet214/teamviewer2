using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamViewer2.Based.Models.UserData;

namespace TeamViewer2.Based.Models.MessageData
{
    public class MessageModel
    {
        public string DataType { get; set; }
        public string Raw { get; set; }
        public UserModel UserInfo { get; set; }
    }
}
