using System;
using Microsoft.AspNetCore.Mvc;
using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.Entities.Entities;

namespace AcquisitionPlus.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                if (id == null)  return StatusCode(400, new { ErrorMessage = "Object is Null" });

                return StatusCode(200, _unitOfWork.Department.Get(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return StatusCode(200, _unitOfWork.Department.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            try
            {
                if (department == null) return StatusCode(400, new { ErroMessage = "Object is Null" });

                department.CreationDate = DateTime.UtcNow.AddMinutes(-240);
                department.Id = Guid.NewGuid();
                department.Status = Status.Active;

                _unitOfWork.Department.Add(department);

                return StatusCode(201, _unitOfWork.Complete());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
