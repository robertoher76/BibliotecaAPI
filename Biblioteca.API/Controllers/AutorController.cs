using Biblioteca.BL.Interfaces;
using Biblioteca.Entities.DTO;
using System.Net;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService services;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="services"></param>
        public AutorController(IAutorService services)
        {
            this.services = services;
        }

        // GET: api/autor
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AutorDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<AutorDto> result = (IEnumerable<AutorDto>)await this.services.GetAutoresAsync();
            return (result != null && result.Any()) ? (IActionResult)this.Ok(result) : (IActionResult)this.NoContent();
        }

        // GET api/autor/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AutorDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            AutorDto obj = (AutorDto)await this.services.GetAutorByIdAsync(id);
            return (obj != null) ? (IActionResult)this.Ok(obj) : (IActionResult)this.NoContent();
        }

        // POST api/autor/5
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(AutorDto model)
        {
            if (model == null)
            {
                return (IActionResult)this.BadRequest();
            }
            int result = await this.services.InsertAutorAsync(model);
            return (result > 0) ? (IActionResult)this.CreatedAtAction("Post", result) : (IActionResult)this.BadRequest();
        }

        // PUT api/autor/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AutorDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, AutorDto model)
        {
            if (model == null)
            {
                return (IActionResult)this.BadRequest();
            }
            AutorDto result = await this.services.UpdateAutorAsync(model);
            return (result != null) ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest();
        }

        // DELETE api/autor/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await this.services.DeleteAutorAsync(id);
            return (result) ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest();
        }
    }
}