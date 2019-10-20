using System;
using Microsoft.AspNetCore.Mvc;
using AcquisitionPlus.Business.Interfaces;
using AcquisitionPlus.Entities.Entities;

namespace AcquisitionPlus.Web.Controllers
{
    /// <summary>
    /// Department Controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                return StatusCode(200, _unitOfWork.Department.GetAll());
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
                if (id == null)  return StatusCode(400, new { ErrorMessage = "Object is Null" });

                return StatusCode(200, _unitOfWork.Department.Get(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Add a Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update a Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Department department)
        {
            try
            {
                if (department == null) return StatusCode(400, new { ErroMessage = "Object is Null" });

                department.UpdateDate = DateTime.UtcNow.AddMinutes(-240);

                department.Status = Status.Active;

                _unitOfWork.Department.Update(department);

                return StatusCode(204, _unitOfWork.Complete());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
