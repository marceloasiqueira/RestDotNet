﻿/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
*/
using Microsoft.AspNetCore.Mvc;
using RestDotNet.Model;
using RestDotNet.Business;

/* URL PROJETO: https://github.com/leandrocgsi/RestWithASP-NETUdemy */

namespace RestDotNet.Controllers
{
    /* Mapeia as requisições de http://localhost:{porta}/api/person/
       Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
       pegando a primeira parte do nome da classe em lower case [Person]Controller
       e expõe como endpoint REST */
    // https://github.com/Microsoft/aspnet-api-versioning
    // https://github.com/Microsoft/aspnet-api-versioning/tree/master/samples
    // [Route("api/[controller]")]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        // Declaração do serviço usado
        private IPersonBusiness _personBusiness;

        /* Injeção de uma instancia de IPersonBusiness ao criar
           uma instancia de PersonController */
        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        /* Mapeia as requisições GET para http://localhost:{porta}/api/person/
           Get sem parâmetros para o FindAll --> Busca Todos */
        // GET api/values
        [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        public IActionResult Get()
        {
            // return new string[] { "value1", "value2" };
            return Ok(_personBusiness.FindAll());
        }

        /* Mapeia as requisições GET para http://localhost:{porta}/api/person/{id}
           recebendo um ID como no Path da requisição
           Get com parâmetros para o FindById --> Busca Por ID */
        // GET api/values/5
        [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        public IActionResult Get(long id)
        {
            // return "value";
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);

        }

        /* Mapeia as requisições POST para http://localhost:{porta}/api/person/
           O [FromBody] consome o Objeto JSON enviado no corpo da requisição */
        // POST api/values
        [HttpPost]
        // public void Post([FromBody] string value)
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        /* Mapeia as requisições PUT para http://localhost:{porta}/api/person/
           O [FromBody] consome o Objeto JSON enviado no corpo da requisição */
        // PUT api/values/5
        [HttpPut] // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Update(person));
        }

        /* Mapeia as requisições DELETE para http://localhost:{porta}/api/person/{id}
           recebendo um ID como no Path da requisição */
        // DELETE api/values/5
        [HttpDelete("{id}")]
        // public void Delete(int id)
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
