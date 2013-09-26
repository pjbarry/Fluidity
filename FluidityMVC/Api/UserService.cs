using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace FluidityMVC.Api
{
    public class UserService :Service
    {
        public IRepository Repository { get; set; }

        public object Post(AddUser request)
        {
            var id = Repository.AddUser(request.Name, request.Goal);
            return new AddUserResponse {UserId = id};
        }
        public object Get(Users request)
        {
            return new UsersResponse {Users = Repository.GetUsers()};
        }

        public object Post(AddFluid request)
        {
            var user = Repository.GetUsers(request.UserId);
            user.Total += request.Amount;
            Repository.UpdateUser(user);
            return new AddFluidResponse {NewTotal = user.Total};
        }
    }

   
}