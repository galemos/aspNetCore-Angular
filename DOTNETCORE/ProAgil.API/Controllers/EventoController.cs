using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.API.Dto;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        public IProAgilRepository _repo { get; }
        public IMapper _mapper { get; }
        public EventoController(IProAgilRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        // GET api/evento
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _repo.GetAllEventosAsync(true);

                var results = _mapper.Map<EventoDto[]>(eventos);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falho: {ex.Message}");
            }
        }

        // GET api/evento/0
        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(EventoId, true);

                var results = _mapper.Map<EventoDto>(evento);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falho");
            }
        }

        // GET api/evento/x
        [HttpGet("getbytema/{Tema}")]
        public async Task<IActionResult> Get(string Tema)

        {
            try
            {
                var eventos = await _repo.GetAllEventosAsyncByTema(Tema, true);

                var results = _mapper.Map<EventoDto[]>(eventos);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falho");
            }
        }

        // POST api/evento
        [HttpPost]
        public async Task<IActionResult> Post(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);

                _repo.Add(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", _mapper.Map<EventoDto>(evento));
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados falhou: {ex.Message}");
            }
            return BadRequest();
        }

        // PUT api/evento
        [HttpPut("{eventoId}")]
        public async Task<IActionResult> Put(int eventoId, EventoDto model)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(eventoId, false);

                if (evento == null)
                {
                    return NotFound();
                }

                _mapper.Map(model, evento);

                _repo.Update(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", _mapper.Map<EventoDto>(evento));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falho");
            }
            return BadRequest();
        }

        // DELETE api/evento
        [HttpDelete("{eventoId}")]
        public async Task<IActionResult> Delete(int eventoId)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(eventoId, false);

                if (evento == null)
                {
                    return NotFound();
                }

                _repo.Delete(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falho");
            }
            return BadRequest();
        }
    }
}