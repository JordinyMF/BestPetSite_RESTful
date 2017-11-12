using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BestPetSite.UnitOfWork;
using BestPetSite.WebApi.Controllers.Base;

namespace BestPetSite.WebApi.Controllers
{
    public class VeterinaryServicesController : BaseController
    {
        public VeterinaryServicesController(IUnitOfWork unit) : base(unit)
        {
        }
    }
}
