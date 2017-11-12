using System;
using System.Web.Http;
using BestPetSite.Models;
using BestPetSite.UnitOfWork;
using BestPetSite.WebApi.Controllers.Base;
using BestPetSite.WebApi.Models.Dto;

namespace BestPetSite.WebApi.Controllers
{
    [RoutePrefix("bestpetsite/api/v1/customers")]
    [Authorize]
    public class CustomersController : BaseController
    {
        public CustomersController(IUnitOfWork unit) : base(unit)
        {

            
        }
        
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var dataResult = new DataResultDto();
            try
            {
                dataResult.Result = true;
                dataResult.Content = _unit.Customers.GetAll();
                dataResult.Response =new ResponseDto {Code  =1, Description = "", Message = "Datos obtenidos correctamente"};
            }
            catch (Exception ex)
            {
                dataResult.Result = false;
                dataResult.Content = null;
                dataResult.Response = new ResponseDto { Code = -1, Description = "Error al obtener lista clientes", Message = ex.Message };
            }
              
            return Ok(dataResult);
        }
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var dataResult = new DataResultDto();
            if (id <= 0)
            {
                dataResult.Result = true;
                dataResult.Content = new Customer();
                dataResult.Response = new ResponseDto { Code = -1, Description = "id inválido", Message = "No se pudo obtener información - Id incorrecto" };
            }
       
            try
            {
                dataResult.Result = true;
                dataResult.Content = _unit.Customers.GetEntityById(id);
                dataResult.Response = new ResponseDto { Code = 1, Description = "", Message = "Datos obtenidos correctamente" };
            }
            catch (Exception ex)
            {
                dataResult.Result = false;
                dataResult.Content = null;
                dataResult.Response = new ResponseDto { Code = -1, Description = "Error al obtener cliente", Message = ex.Message };
            }
            return Ok(dataResult);

        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Customer customer)
        {

            var dataResult = new DataResultDto();
            

            try
            {
                var id = _unit.Customers.Insert(customer);
                
                if (id > 0)
                {
                    customer.Id = id;
                    dataResult.Result = true;
                    dataResult.Content = customer;
                    dataResult.Response = new ResponseDto { Code = 1, Description = "", Message = "Se registro correctamente" };

                }
                else
                {
                    dataResult.Result = true;
                    dataResult.Content = customer;
                    dataResult.Response = new ResponseDto { Code = -1, Description = "", Message = "Error al registrar" };
                }
                
            }
            catch (Exception ex)
            {
                dataResult.Result = false;
                dataResult.Content = null;
                dataResult.Response = new ResponseDto { Code = -1, Description = "Error al registrar", Message = ex.Message };
            }
           
            return Ok(dataResult);
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Customer customer)
        {
            var dataResult = new DataResultDto();

            try
            {
                var resUpdate = _unit.Customers.Update(customer);

                if (resUpdate)
                {
                    dataResult.Result = true;
                    dataResult.Content = customer;
                    dataResult.Response = new ResponseDto { Code = 1, Description = "", Message = "Se actualizo correctamente" };

                }
                else
                {
                    dataResult.Result = true;
                    dataResult.Content = customer;
                    dataResult.Response = new ResponseDto { Code = -1, Description = "", Message = "Error al actualizar" };
                }

            }
            catch (Exception ex)
            {
                dataResult.Result = false;
                dataResult.Content = null;
                dataResult.Response = new ResponseDto { Code = -1, Description = "Error al actualizar", Message = ex.Message };
            }


            return Ok(dataResult);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
         

            var dataResult = new DataResultDto();
            if (id <= 0)
            {
                dataResult.Result = true;
                dataResult.Content = new Customer();
                dataResult.Response = new ResponseDto { Code = -1, Description = "id inválido", Message = "No se pudo eliminar información - Id incorrecto" };
            }
            try
            {
                var resDelete = _unit.Customers.Delete(new Customer { Id = id });
                if (resDelete)
                {
                    dataResult.Result = true;
                    dataResult.Content = new Customer{Id = id};
                    dataResult.Response = new ResponseDto { Code = 1, Description = "", Message = "Se elimino correctamente" };

                }
                else
                {
                    dataResult.Result = true;
                    dataResult.Content = new Customer { Id = id };
                    dataResult.Response = new ResponseDto { Code = -1, Description = "", Message = "Error al eliminar" };
                }

            }
            catch (Exception ex)
            {
                dataResult.Result = false;
                dataResult.Content = null;
                dataResult.Response = new ResponseDto { Code = -1, Description = "Error al eliminar", Message = ex.Message };
            }

            return Ok(dataResult);
        }
    }

}
