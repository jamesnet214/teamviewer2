using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamViewer2.Core
{
    public interface IViewLoadable
    {
        void OnLoaded(PrismContent view);
    }
}
