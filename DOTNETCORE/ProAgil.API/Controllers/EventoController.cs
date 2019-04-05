using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        public IProAgilRepository _repo { get; }
        public EventoController(IProAgilRepository repo)
        {
            _repo = repo;

        }
        // GET api/evento
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllEventosAsync(true);

                return Ok(results);                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falho");
            }
        }

        // GET api/evento/0
        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId)
        {
            try
            {
                var results = await _repo.GetEventoAsyncById(EventoId, true);

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
                var results = await _repo.GetAllEventosAsyncByTema(Tema, true);

                return Ok(results);                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falho");
            }
        }

        // POST api/evento
        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync()){
                    return Created($"/api/evento/{model.Id}", model);
                }               
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falho");
            }
            return BadRequest();
        }

        // PUT api/evento
        [HttpPut]
        public async Task<IActionResult> Put(int eventoId, Evento model)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(eventoId, false);

                if(evento == null){
                    return NotFound();
                }

                _repo.Update(model);

                if(await _repo.SaveChangesAsync()){
                    return Created($"/api/evento/{model.Id}", model);
                }               
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falho");
            }
            return BadRequest();
        }

        // DELETE api/evento
        [HttpDelete]
        public async Task<IActionResult> Delete(int eventoId)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(eventoId, false);
                
                if(evento == null){
                    return NotFound();
                }

                _repo.Delete(evento);

                if(await _repo.SaveChangesAsync()){
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