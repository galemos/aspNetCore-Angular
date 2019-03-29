using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        public IProAgilRepository _repo { get; }
        public PalestranteController(IProAgilRepository repo)
        {
            _repo = repo;

        }

        // GET api/palestrante/0
        [HttpGet("{palestranteId}")]
        public async Task<IActionResult> Get(int palestranteId)
        {
            try
            {
                var results = await _repo.GetPalestranteAsyncById(palestranteId, true);

                return Ok(results);                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falho");
            }
        }

        // GET api/palestrante/x
        [HttpGet("{nome}")]
        public async Task<IActionResult> Get(string nome)

        {
            try
            {
                var results = await _repo.GetAllPalestrantesAsyncByName(nome, true);

                return Ok(results);                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falho");
            }
        }

        // POST api/palestrante
        [HttpPost]
        public async Task<IActionResult> Post(Palestrante model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync()){
                    return Created($"/api/palestrante/{model.Id}", model);
                }               
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falho");
            }
            return BadRequest();
        }

        // PUT api/palestrante
        [HttpPut]
        public async Task<IActionResult> Put(int palestranteId, Palestrante model)
        {
            try
            {
                var palestrante = await _repo.GetPalestranteAsyncById(palestranteId, false);

                if(palestrante == null){
                    return NotFound();
                }

                _repo.Update(model);

                if(await _repo.SaveChangesAsync()){
                    return Created($"/api/palestrante/{model.Id}", model);
                }               
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falho");
            }
            return BadRequest();
        }

        // DELETE api/palestrante
        [HttpDelete]
        public async Task<IActionResult> Delete(int palestranteId)
        {
            try
            {
                var palestrante = await _repo.GetPalestranteAsyncById(palestranteId, false);
                
                if(palestrante == null){
                    return NotFound();
                }

                _repo.Delete(palestrante);

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