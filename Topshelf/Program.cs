using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Logging;
using log4net.Config;
using System.IO;

namespace Topshelf
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x=>
            {
                x.UseLog4Net("log4net.config");
                x.Service<SimpleService>(xs =>
                {
                    xs.ConstructUsing<SimpleService>(() => new SimpleService());
                    xs.WhenStarted(v => v.Start());
                    xs.WhenStopped(v => v.Stop());
                });
                x.RunAsLocalService();
                x.SetDescription("Description");
                x.SetDisplayName("Display name");
                x.SetServiceName("Service name");

            }
            );
        }
    }
}
