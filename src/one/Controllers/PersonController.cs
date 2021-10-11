using Microsoft.AspNetCore.Mvc;
using one.Application.Contracts;
using System;
using System.Text;
using System.Threading.Tasks;

namespace one.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("/random")]
        public async Task<ActionResult<PersonDTO>> GetRandomPerson()
        {
            return Ok(await _personService.GenerateRandomPersonAsync());
        }
    }
}