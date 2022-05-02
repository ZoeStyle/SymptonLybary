using BackEnd.Domain.Commands;
using BackEnd.Domain.Handlers;
using BackEnd.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController, Route("v1/[controller]")]
    public class DiseasesController : Controller
    {
        [HttpGet, Route(""), Authorize]
        public async Task<IActionResult> GetAll([FromServices] IDiseasesRepository repository) =>
            Ok(await repository.GetAll());

        [HttpGet, Route("{id}"), Authorize]
        public async Task<IActionResult> GetById([FromServices] IDiseasesRepository repository, string id) =>
            Ok(await repository.GetById(id));

        //[HttpPost, Route("getBySymptom"), Authorize]
        //public async Task<IActionResult> GetByName([FromServices] IDiseasesRepository repository, IEnumerable<SymptomsDTO> request) =>
        //    Ok(await repository.GetDiseasesBySymptoms(null));

        [HttpPost, Route(""), Authorize]
        public IActionResult Create([FromServices] DiseaseHandler handler, CreateDiseasesCommand request)
        {
            var result = (ResultCommand)handler.Handle(request);
            if (result.HasError)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut, Route("{id}"), Authorize]
        public IActionResult Update([FromServices] DiseaseHandler handler, UpdateDiseasesCommand request, string id)
        {
            if(id != request.Id)
                return BadRequest("The Id informed in the URL is different from the one informed in the body");

            var result = (ResultCommand)handler.Handle(request);
            if (result.HasError)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
