using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vendor.domain.entities;
using vendor.logic.models.abstracts;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace vendor.ui.controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductModel _model;
        public ProductController(IProductModel model)
        {
            this._model = model;
        }

        [HttpGet]
        public IEnumerable<Product> List()
        {
            return this._model.List(null);
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return this._model.Get(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product value)
        {
            if (this._model.Validate(value))
            {
                if (this._model.Add(value))
                {
                    return Ok(value);
                }
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product value)
        {
            if (this._model.Validate(value))
            {
                if (this._model.Update(value))
                {
                    return Ok(value);
                }
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return BadRequest("You can't delete");
        }
    }
}
