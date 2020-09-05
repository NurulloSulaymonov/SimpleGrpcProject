using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using LoginProfileServer;
namespace SimpleGrpcServer.Services
{
    public class LoginService : LoginProfile.LoginProfileBase
    {

        const string Internet = "Wifi";
        const int num = 12345;
        const string pass = "12345678";
        private List<User> users;

        public LoginService()
        {
            Seed();
        }

        private void Seed()
        {
            users = new List<User>()
            {
                new User(){Id = 1, Name = "Nurullo", PhoneNumber = "901010101", Password = "pass1"},
                new User(){Id = 2, Name = "Sulaymon", PhoneNumber = "901010102", Password = "pass2"},
                new User(){Id = 3, Name = "Abdullo", PhoneNumber = "901010103", Password = "pass3"},
                new User(){Id = 4, Name = "Muhammad", PhoneNumber = "901010104", Password = "pass4"},
            };
        }

        public override Task<LoginResponse> GetLoginProfile(LoginRequest request, ServerCallContext context)
        {
            var user = users.Where(x => x.PhoneNumber == request.Num && x.Password == request.Pass).FirstOrDefault();
            if (user != null)
            {
                return Task.FromResult(new LoginResponse
                {
                    Code = 200,
                    Message = "",
                    Time = DateTime.Now.ToString(),
                    UserName = user.Name
                });
            }
            return Task.FromResult(new LoginResponse() { Code = 404, Message = "login or pass is incorrect", Time = DateTime.Now.ToString() });
        }

    }


}
