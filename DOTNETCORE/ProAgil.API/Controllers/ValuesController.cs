﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAgil.API.model;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Evento>> Get()
        {
            return new Evento[] { 
                new Evento() {
                    eventoId = 1,
                    tema = "Angular e .NET Core",
                    local = "Belo Horizonte",
                    lote = "1° Lote",
                    qtdPessoas = 250,
                    dataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                new Evento() {
                    eventoId = 2,
                    tema = "vue.js",
                    local = "São Paulo",
                    lote = "2° Lote",
                    qtdPessoas = 300,
                    dataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
                }
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {
            return new Evento[] { 
                new Evento() {
                    eventoId = 1,
                    tema = "Angular e .NET Core",
                    local = "Belo Horizonte",
                    lote = "1° Lote",
                    qtdPessoas = 250,
                    dataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                new Evento() {
                    eventoId = 2,
                    tema = "vue.js",
                    local = "São Paulo",
                    lote = "2° Lote",
                    qtdPessoas = 300,
                    dataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
                }
            }.FirstOrDefault(x => x.eventoId.Equals(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
