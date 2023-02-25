using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamViewer2.Core.Models;

namespace TeamViewer2.Core.Events
{
    public class InitializeCurrentUserEvent : PubSubEvent<UserModel>
    {

    }
}
