using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.Entities.DTO;
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
        private readonly ISupplierRepositoryHandler _supplierRepositoryHandler;

        public SuppliersController(IUnitOfWork unitOfWork, ISupplierRepositoryHandler supplierRepositoryHandler)
        {
            _unitOfWork = unitOfWork;
            _supplierRepositoryHandler = supplierRepositoryHandler;
        }

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

        [HttpGet]
        [Route("GetSuppliers")]
        public IActionResult GetSuppliers()
        {
            try
            {
                var supplier = _unitOfWork.Supplier.GetAll().Select(x => new { x.Id, Supplier = x.Name }).ToList();

                return StatusCode(200, supplier);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

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