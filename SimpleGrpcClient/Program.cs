using Grpc.Net.Client;
using LoginProfileClient;
using System;
using System.Threading.Tasks;

namespace SimpleGrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().RunConsumer().Wait();
        }

        public async Task RunConsumer()
        {
            AppContext.SetSwitch(
            "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            // The port number(5000) must match the port of the gRPC server.
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new LoginProfile.LoginProfileClient(channel);

            while (true)
            {
                // Our shopper repository contains details of shopper's with IDs ranging from 1-5
                Console.WriteLine("Login))");
                Console.Write("Phone Number : ");
                var phone = Console.ReadLine();
                Console.Write("Password : ");
                var pass = Console.ReadLine();

                var response = await client.GetLoginProfileAsync(new LoginRequest() { Num = phone, Pass = pass, ApplicationVersion = "1.1.1.1"});

                if (response.Code == 200)
                {
                    Console.WriteLine($"User profile | repsonse Code: {response.Code} | Name: {response.UserName}");
                }
                else
                {
                    Console.WriteLine($"Login or Pass is Incorrect Response code {response.Code}");
                }



            }

            }
    }
}
