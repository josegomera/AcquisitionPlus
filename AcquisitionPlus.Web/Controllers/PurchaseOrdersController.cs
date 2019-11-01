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
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPurchaseHandler _purchaseHadler;

        public PurchaseOrdersController(IUnitOfWork unitOfWork, IPurchaseHandler purchaseHadler)
        {
            _unitOfWork = unitOfWork;
            _purchaseHadler = purchaseHadler;
        }

        /// <summary>
        /// Get all the Departments
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get Department by Id(GUID)
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

                return StatusCode(200, _unitOfWork.PurchaseOrder.Get(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Add a Department
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(AddPurchaseOrderDTO purchaseOrder)
        {
            try
            {
                _purchaseHadler.AddPurchaseOrder(purchaseOrder);

                return StatusCode(201, _unitOfWork.Complete());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //[HttpPut]
        //public IActionResult Update(PurchaseOrder purchaseOrder)
        //{
        //    try
        //    {
        //        if (department == null) return StatusCode(400, new { ErroMessage = "Object is Null" });

        //        department.UpdateDate = DateTime.UtcNow.AddMinutes(-240);

        //        department.Status = Status.Active;

        //        _unitOfWork.Department.Update(department);

        //        return StatusCode(204, _unitOfWork.Complete());
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}
    }
}