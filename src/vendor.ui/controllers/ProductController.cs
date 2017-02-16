using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vendor.domain.entities;
using vendor.logic.models.abstracts;
using vendor.logic.models.concretes;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace vendor.ui.controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IModelProduct _model;
        public ProductController(IModelProduct model)
        {
            this._model = model;
        }

        [HttpGet("list")]
        public IEnumerable<Product> List()
        {
            // return this._model.List(null);
            return new Product[] { };
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            // return this._model.Get(x => x.Id == id);
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product value)
        {
            value.Id = 5;
            var result = new ResultProduct { Error = null, Results = new List<Product> { value } };
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product value)
        {
            // if (this._model.Validate(value))
            // {
            //     if (this._model.Update(value))
            //     {
            //         return Ok(value);
            //     }
            // }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return BadRequest("You can't delete");
        }



    }
}
