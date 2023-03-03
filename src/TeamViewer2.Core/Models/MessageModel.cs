using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamViewer2.Core.Models
{
    public class MessageModel
    {
        public string DataType { get; set; }
        public string Raw { get; set; }
        public UserModel UserInfo { get; set; }
    }
}
