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
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(200, _unitOfWork.Product.GetAll());
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

                return StatusCode(200, _unitOfWork.Product.Get(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _unitOfWork.Product.GetAll()
                    .Where(s => s.Stock != 0)
                    .Select(x => new { x.Id, Product = x.Description, x.Stock, x.UnitCost}).ToList();

                return StatusCode(200, products);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            try
            {
                if (product == null) return StatusCode(400, new { ErroMessage = "Object is Null" });

                product.CreationDate = DateTime.UtcNow.AddMinutes(-240);
                product.Id = Guid.NewGuid();
                product.Status = Status.Active;

                _unitOfWork.Product.Add(product);

                return StatusCode(201, _unitOfWork.Complete());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            try
            {
                if (product == null) return StatusCode(400, new { ErroMessage = "Object is Null" });

                product.UpdateDate = DateTime.UtcNow.AddMinutes(-240);

                product.Status = Status.Active;

                _unitOfWork.Product.Update(product);

                return StatusCode(204, _unitOfWork.Complete());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}