using AutoMapper;
using HealthyHole.Application.Commands.Emploee;
using HealthyHole.Application.Queries;
using HealthyHole.Application.Queries.Models;
using HealthyHole.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HealthyHole.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PersonalDepartmentController : BaseController
    {
        private readonly IMapper _mapper;

        public PersonalDepartmentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EmploeesList>> GetAll()
        {
            var query = new GetEmploeesQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            return Created("", 1);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmploeeDTO createEmploeeDTO)
        {
            var command = _mapper.Map<CreateEmploeeCommand>(createEmploeeDTO);
            var emploeeId = await Mediator.Send(command);

            return Ok(emploeeId);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateEmploeeDTO updateEmploeeDTO)
        {
            var command = _mapper.Map<UpdateEmploeeCommand>(updateEmploeeDTO);
            var emploeeId = await Mediator.Send(command);

            return Ok(emploeeId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid emploeeId)
        {
            var command = new DeleteEmploeeCommand(emploeeId);
            var deletedEmploeeId = await Mediator.Send(command);

            return Ok(deletedEmploeeId);
        }
    }
}
