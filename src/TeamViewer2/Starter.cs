using System;
using TeamViewer2.Settings;

namespace TeamViewer2
{
    class Starter
    {
        [STAThread]
        static void Main(string[] args)
        {
            _ = new App()
                .WireViewModel()
                .AddModule<DirectModules>()
                .Run();
        }
    }
}
