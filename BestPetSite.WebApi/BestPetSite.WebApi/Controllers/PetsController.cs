using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BestPetSite.Models;
using BestPetSite.UnitOfWork;
using BestPetSite.WebApi.Controllers.Base;
using BestPetSite.WebApi.Models.Dto;

namespace BestPetSite.WebApi.Controllers
{
    [RoutePrefix("bestpetsite/api/v1/pets")]
    public class PetsController  : BaseController
    {
        public PetsController(IUnitOfWork unit) : base(unit)
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
                dataResult.Content = _unit.Pets.GetAll();
                dataResult.Response = new ResponseDto { Code = 1, Description = "", Message = "Datos obtenidos correctamente" };
            }
            catch (Exception ex)
            {
                dataResult.Result = false;
                dataResult.Content = null;
                dataResult.Response = new ResponseDto { Code = -1, Description = "Error al obtener lista mascotas", Message = ex.Message };
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
                dataResult.Content = new Pet();
                dataResult.Response = new ResponseDto { Code = -1, Description = "id inválido", Message = "No se pudo obtener información - Id incorrecto" };
            }

            try
            {
                dataResult.Result = true;
                dataResult.Content = _unit.Pets.GetEntityById(id);
                dataResult.Response = new ResponseDto { Code = 1, Description = "", Message = "Datos obtenidos correctamente" };
            }
            catch (Exception ex)
            {
                dataResult.Result = false;
                dataResult.Content = null;
                dataResult.Response = new ResponseDto { Code = -1, Description = "Error al obtener mascota", Message = ex.Message };
            }
            return Ok(dataResult);

        }
        [AllowAnonymous]
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Pet pet)
        {
            pet.CreationDate = DateTime.Now;
            pet.ModificationDate = DateTime.Now;
            var dataResult = new DataResultDto();


            try
            {
                var id = _unit.Pets.Insert(pet);

                if (id > 0)
                {
                    pet.Id = id;
                    dataResult.Result = true;
                    dataResult.Content = pet;
                    dataResult.Response = new ResponseDto { Code = 1, Description = "", Message = "Se registro correctamente" };

                }
                else
                {
                    dataResult.Result = true;
                    dataResult.Content = pet;
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
        public IHttpActionResult Put(Pet pet)
        {
            pet.CreationDate = DateTime.Now;
            pet.ModificationDate = DateTime.Now;
            var dataResult = new DataResultDto();

            try
            {
                var resUpdate = _unit.Pets.Update(pet);

                if (resUpdate)
                {
                    dataResult.Result = true;
                    dataResult.Content = pet;
                    dataResult.Response = new ResponseDto { Code = 1, Description = "", Message = "Se actualizo correctamente" };

                }
                else
                {
                    dataResult.Result = true;
                    dataResult.Content = pet;
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
                dataResult.Content = new Pet();
                dataResult.Response = new ResponseDto { Code = -1, Description = "id inválido", Message = "No se pudo eliminar información - Id incorrecto" };
            }
            try
            {
                var resDelete = _unit.Customers.Delete(new Customer { Id = id });
                if (resDelete)
                {
                    dataResult.Result = true;
                    dataResult.Content = new Pet { Id = id };
                    dataResult.Response = new ResponseDto { Code = 1, Description = "", Message = "Se elimino correctamente" };

                }
                else
                {
                    dataResult.Result = true;
                    dataResult.Content = new Pet { Id = id };
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
