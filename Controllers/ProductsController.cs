using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuxuryCars.Models;
using LuxuryCars.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LuxuryCars.Models.Entities;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace LuxuryCars.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly ILCRepository _repository;
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public ProductsController(ILCRepository repository,
          ILogger<ProductsController> logger,
          IMapper mapper,
          UserManager<User> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = Mapping.Mapping.Mapper;
            _userManager = userManager;


        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            }
        }

        [HttpGet]
        [Route("getProductById/{id}")]
        public IActionResult GetProductById([FromRoute] int id)
        {
            try
            {
                return Ok(_repository.GetProductById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            }
        }
            
        [HttpPost]
        [Route("postProduct")]
        public async Task<IActionResult> Post([FromBody]ProductViewModel model)
        {
            // add it to the db
            try
            {
                if (ModelState.IsValid)
                {
                    var newProduct = _mapper.Map<ProductViewModel, Product>(model);

                    var currentUser = await _userManager.FindByNameAsync(model.UserName);
                    newProduct.User = currentUser;

                    _repository.AddEntity(newProduct);
                    if (_repository.SaveAll())
                    {
                        return Created($"/api/products/{newProduct.Id}", _mapper.Map<Product, ProductViewModel>(newProduct));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save a new order: {ex}");
            }

            return BadRequest("Failed to save new order");

        }
    }
}