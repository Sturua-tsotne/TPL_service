using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TplApiService.Controllers
{

    public class BaseController : ControllerBase
    {
        protected int UserId()
        {
            string userinfo = "";
           var  user = from c in User.Claims select  new { c.Type, c.Value };
            foreach (var item in user)
            {
                if (item.Type== "client_id")
                {
                    userinfo = item.Value;
                }
            }
            return Convert.ToInt32(userinfo);
        }
    }

   
}
