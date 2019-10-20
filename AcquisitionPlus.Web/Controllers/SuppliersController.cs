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
    public class SuppliersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuppliersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all the Suppliers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(200, _unitOfWork.Supplier.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Get Suppliers by Id(GUID)
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

                return StatusCode(200, _unitOfWork.Supplier.Get(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Add a Supplier
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(Supplier supplier)
        {
            try
            {
                if (supplier == null) return StatusCode(400, new { ErroMessage = "Object is Null" });

                supplier.CreationDate = DateTime.UtcNow.AddMinutes(-240);
                supplier.Id = Guid.NewGuid();
                supplier.Status = Status.Active;

                _unitOfWork.Supplier.Add(supplier);

                return StatusCode(201, _unitOfWork.Complete());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Update a Supplier
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Supplier supplier)
        {
            try
            {
                if (supplier == null) return StatusCode(400, new { ErroMessage = "Object is Null" });

                supplier.UpdateDate = DateTime.UtcNow.AddMinutes(-240);

                supplier.Status = Status.Active;

                _unitOfWork.Supplier.Update(supplier);

                return StatusCode(204, _unitOfWork.Complete());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}