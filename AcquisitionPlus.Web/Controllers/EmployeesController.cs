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

        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetProducts()
        {
            try
            {
                var Employees = _unitOfWork.Employee.GetAll().Select(x => new { x.Id, FullName = $"{x.Name} { x.LastName}" }).ToList();

                return StatusCode(200, Employees);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

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