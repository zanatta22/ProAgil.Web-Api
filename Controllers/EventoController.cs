﻿using Microsoft.AspNetCore.Mvc;
using ProAgil.WebApi.Model;
using ProAgil.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IProAgilRepository _repo;

        public EventoController(IProAgilRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllEventoAsync(true);

                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Banco de dados falhou");
            }

        }

        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId)
        {
            try
            {
                var results = await _repo.GetEventoAsyncById(EventoId, true);

                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Banco de dados falhou");
            }

        }

        [HttpGet("getByTema/{Tema}")]
        public async Task<IActionResult> Get(string Tema)
        {
            try
            {
                var results = await _repo.GetAllEventoAsyncByTema(Tema, true);

                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Banco de dados falhou");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpPut("{EventoId}")]
        public async Task<IActionResult> Put(int EventoId, Evento model)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(EventoId, false);

                if (evento == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "Banco de dados falhou");
            }

            return BadRequest();

        }

        [HttpDelete("{EventoId}")]
        public async Task<IActionResult> Delete(int EventoId)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(EventoId, false);
                if (evento == null) return NotFound();

                _repo.Delete(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "Banco de dados falhou");
            }

            return BadRequest();

        }
    }
}