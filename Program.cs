using SimpleHeartBeat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Topshelf;

namespace SimpleHeartbeatService
{
    class Program
    {
        static void Main(string[] args) 
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<Heartbeat>(s =>
                {
                    s.ConstructUsing(heartbeat => new Heartbeat());
                    s.WhenStarted(heartbeat => heartbeat.Start());
                    s.WhenStopped(heartbeat => heartbeat.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("HeartbeatService");
                x.SetDisplayName("HeartBeat Service");
                x.SetDescription("This is the sample heartbeat service");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
