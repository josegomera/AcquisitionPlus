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

        /// <summary>
        /// Get all the Products
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get product by Id(GUID)
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

                return StatusCode(200, _unitOfWork.Product.Get(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Add a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
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