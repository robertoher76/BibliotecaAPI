using Biblioteca.BL.Interfaces;
using Biblioteca.Entities.DTO;
using System.Net;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService services;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="services"></param>
        public LibroController(ILibroService services)
        {
            this.services = services;
        }

        // GET: api/libro
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LibroDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<LibroDto> result = (IEnumerable<LibroDto>)await this.services.GetLibrosAsync();
            return (result != null && result.Any()) ? (IActionResult)this.Ok(result) : (IActionResult)this.NoContent();
        }

        // GET api/libro/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LibroDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            LibroDto obj = (LibroDto)await this.services.GetLibroByIdAsync(id);
            return (obj != null) ? (IActionResult)this.Ok(obj) : (IActionResult)this.NoContent();
        }

        // POST api/libro/5
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(LibroDto model)
        {
            if (model == null)
            {
                return (IActionResult)this.BadRequest();
            }
            int result = await this.services.InsertLibroAsync(model);
            return (result > 0) ? (IActionResult)this.CreatedAtAction("Post", result) : (IActionResult)this.BadRequest();
        }

        // PUT api/libro/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LibroDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, LibroDto model)
        {
            if (model == null)
            {
                return (IActionResult)this.BadRequest();
            }
            LibroDto result = await this.services.UpdateLibroAsync(model);
            return (result != null) ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest();
        }

        // DELETE api/libro/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await this.services.DeleteLibroAsync(id);
            return (result) ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest();
        }
    }
}