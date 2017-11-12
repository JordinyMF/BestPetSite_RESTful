﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BestPetSite.UnitOfWork;
using BestPetSite.WebApi.Controllers.Base;

namespace BestPetSite.WebApi.Controllers
{
    [RoutePrefix("bestpetsite/api/v1/pets")]
    public class PetsController  : BaseController
    {
        public PetsController(IUnitOfWork unit) : base(unit)
        {
        }


    }
}