using System;
using System.ServiceModel;

namespace AirportSeriviceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(AirportService.AirportService)))
            {
                host.Open();
                Console.WriteLine("Host started at: "+ DateTime.UtcNow.ToString());
                Console.ReadLine();
            }
        }
    }
}
