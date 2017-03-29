using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Logging;

namespace Topshelf
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.UseLog4Net();
                x.Service<SimpleService>(s =>
                {
                    s.ConstructUsing(() => new SimpleService());
                    s.WhenStarted(start => start.Start());
                    s.WhenStopped(stop => stop.Stop());
                });
            }
            );
        }
    }
    class SimpleService
    {
        static LogWriter _logger = HostLogger.Get<SimpleService>();
        public SimpleService()
        {
            
        }
        public void Start()
        {
            _logger.Info($"Starting {this.GetType().Name} service");
            Console.WriteLine("Service is running");
            System.Threading.Thread.Sleep(1000);
            _logger.Info($"Service {this.GetType().Name} started");
        }
        public void Stop()
        {
            _logger.Info($"Stopping {this.GetType().Name} service");
            Console.WriteLine("Service is stopping");
            System.Threading.Thread.Sleep(1000);
            _logger.Info($"Service {this.GetType().Name} stopped");
        }
    }
}
