using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcquisitionPlus.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UnitOfMeasurementsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfMeasurementsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all the UnitOfMeasurement
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(200, _unitOfWork.UnitOfMeasurement.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Get UnitOfMeasurement by Id(GUID)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                if (id == null) return StatusCode(400, new { ErrorMessage = "Object is Null" });

                return StatusCode(200, _unitOfWork.UnitOfMeasurement.Get(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Add a UnitOfMeasurement
        /// </summary>
        /// <param name="unitOfMeasurement"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(UnitOfMeasurement unitOfMeasurement)
        {
            try
            {
                if (unitOfMeasurement == null) return StatusCode(400, new { ErroMessage = "Object is Null" });

                unitOfMeasurement.CreationDate = DateTime.UtcNow.AddMinutes(-240);
                unitOfMeasurement.Id = Guid.NewGuid();
                unitOfMeasurement.Status = Status.Active;

                _unitOfWork.UnitOfMeasurement.Add(unitOfMeasurement);

                return StatusCode(201, _unitOfWork.Complete());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Update a UnitOfMeasurement
        /// </summary>
        /// <param name="unitOfMeasurement"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(UnitOfMeasurement unitOfMeasurement)
        {
            try
            {
                if (unitOfMeasurement == null) return StatusCode(400, new { ErroMessage = "Object is Null" });

                unitOfMeasurement.UpdateDate = DateTime.UtcNow.AddMinutes(-240);

                unitOfMeasurement.Status = Status.Active;

                _unitOfWork.UnitOfMeasurement.Update(unitOfMeasurement);

                return StatusCode(204, _unitOfWork.Complete());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}