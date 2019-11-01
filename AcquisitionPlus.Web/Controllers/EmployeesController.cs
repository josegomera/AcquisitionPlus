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
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all the Employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(200, _unitOfWork.Employee.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Get Employee by Id(GUID)
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

                return StatusCode(200, _unitOfWork.Employee.Get(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Add a Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            try
            {
                if (employee == null) return StatusCode(400, new { ErroMessage = "Object is Null" });

                employee.CreationDate = DateTime.UtcNow.AddMinutes(-240);
                employee.Id = Guid.NewGuid();
                employee.Status = Status.Active;

                _unitOfWork.Employee.Add(employee);

                return StatusCode(201, _unitOfWork.Complete());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Update a Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Employee employee)
        {
            try
            {
                if (employee == null) return StatusCode(400, new { ErroMessage = "Object is Null" });

                employee.UpdateDate = DateTime.UtcNow.AddMinutes(-240);

                employee.Status = Status.Active;

                _unitOfWork.Employee.Update(employee);

                return StatusCode(204, _unitOfWork.Complete());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}