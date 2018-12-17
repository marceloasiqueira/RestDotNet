﻿/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
*/
using Microsoft.AspNetCore.Mvc;
using RestDotNet.Model;
using RestDotNet.Services;

namespace RestDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET api/values
        [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        public IActionResult Get()
        {
            // return new string[] { "value1", "value2" };
            return Ok(_personService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        public IActionResult Get(int id)
        {
            // return "value";
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);

        }

        // POST api/values
        [HttpPost]
        // public void Post([FromBody] string value)
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        // public void Delete(int id)
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
