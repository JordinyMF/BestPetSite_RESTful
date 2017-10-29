using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BestPetSite.Models;
using BestPetSite.UnitOfWork;
using BestPetSite.WebApi.Controllers.Base;

namespace BestPetSite.WebApi.Controllers
{
    [RoutePrefix("customer")]
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork unit) : base(unit)
        {

            
        }

        public IHttpActionResult Get()
        {
            var user = new User()
            {
                Email = "jordiny@gmail.com",
                FirstName = "Jordiny"
                
            };
            
            return Json(user);
        }
    }

}
