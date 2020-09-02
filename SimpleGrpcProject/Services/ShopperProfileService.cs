using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using ShopperProfileServer;

namespace SimpleGrpcProject.Services
{
    public class ShopperProfileService : ShopperProfile.ShopperProfileBase
    {
        private List<ShopperDetails> _shopperProfiles => new List<ShopperDetails>(){
            new ShopperDetails(){ ShopperId = "1",Name = "test1"},
            new ShopperDetails(){ ShopperId = "2",Name = "test2"},
            new ShopperDetails(){ ShopperId = "3",Name = "test3"},
            new ShopperDetails(){ ShopperId = "4",Name = "test4"}
        };

        public override async Task<ShopperProfileResponse> GetShopperProfile(ShopperProfileRequest request, ServerCallContext context)
        {

            var shopperDetails = _shopperProfiles.Single(s => s.ShopperId == request.ShopperId);

            return await Task.FromResult(new ShopperProfileResponse() { ShopperDetails = shopperDetails });
        }
    }
}
