using BestPetSite.UnitOfWork;
using System.Collections.Generic;
using System.Web.Http;
using BestPetSite.WebApi.Models.Dto;

namespace BestPetSite.WebApi.Controllers.Base
{
    public class BaseController : ApiController
    {
        protected readonly IUnitOfWork _unit;
        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IHttpActionResult AjaxResultSuccessNoParam()
        {
            return Json(
                new
                {
                    result = true
                });
        }

        public IHttpActionResult AjaxResultSuccess(string successMessage)
        {
            return Json(
                new
                {
                    result = true,
                    message = successMessage
                });
        }

        public IHttpActionResult AjaxResultError(string errorDescription, string errorMessage)
        {
            return Json(
                new
                {
                    result = false,
                    description = errorDescription,
                    message = errorMessage
                });
        }
        public IHttpActionResult AjaxResult(List<ResponseDto> errorList, List<ResponseDto> successList, string exception)
        {
            return Json(
                new
                {

                    ErrorList = errorList,
                    SuccessList = successList,
                    Exception = exception
                });
        }

    }
}