using Gibraltar.Agent;
using Loupe.Configuration;
using Microsoft.Extensions.Configuration;
using System;


namespace LoupeTester
{
    class Program
    {
        private static AgentConfiguration LoadConfig(string[] args)
        {
            var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .AddEnvironmentVariables()
              .AddCommandLine(args)
              .Build();

            var agentConfig = new AgentConfiguration();
            config.GetSection("Loupe").Bind(agentConfig);
            return agentConfig;
        }


        static void Main(string[] args)
        {
            var loupeConfig = LoadConfig(args);
            Log.StartSession(loupeConfig);
            try
            {
                Log.TraceVerbose("Docker says hello at {0}", DateTime.Now.ToLongTimeString());
                Log.TraceInformation("Docker says hello at {0}", DateTime.Now.ToLongTimeString());
                Log.TraceWarning("Docker says hello at {0}", DateTime.Now.ToLongTimeString());
                Log.TraceError("Docker says hello at {0}", DateTime.Now.ToLongTimeString());
                Log.TraceCritical("Docker says hello at {0}", DateTime.Now.ToLongTimeString());

                var i = 5;
                while (i > 0)
                {
                    Console.WriteLine("Press [Enter] to exit in [{0}]", i--);
                    Console.ReadLine();
                }
            }
            finally
            {
                Log.EndSession();
            }
        }
    }
}
