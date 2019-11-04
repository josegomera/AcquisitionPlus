using System;
using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.Domain.handler;
using AcquisitionPlus.Entities.DTO;
using AcquisitionPlus.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcquisitionPlus.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPurchaseOrderHandler _handler;

        public PurchaseOrdersController(IUnitOfWork unitOfWork, IPurchaseOrderHandler handler)
        {
            _unitOfWork = unitOfWork;
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                return StatusCode(200, _unitOfWork.PurchaseOrder.GetAll());
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

                return StatusCode(200, _unitOfWork.PurchaseOrder.Get(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(PurchaseOrder purchase)
        {
            try
            {
                if (purchase == null) return StatusCode(400, new { ErroMessage = "Object is Null" });

                _handler.Execute(purchase);
                
                return StatusCode(201, _unitOfWork.Complete());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}