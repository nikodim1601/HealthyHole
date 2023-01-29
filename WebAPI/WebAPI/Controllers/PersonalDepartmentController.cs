using AutoMapper;
using HealthyHole.Application.Commands.Emploee;
using HealthyHole.Application.Queries;
using HealthyHole.Application.Queries.Models;
using HealthyHole.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebAPI;

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
            try
            {
                var query = new GetEmploeesQuery();
                var vm = await Mediator.Send(query);
                return Ok(vm);       
            }
            catch (Exception e)
            {
                // Тут должны быть человеческие логи...
                Console.WriteLine(e);
                return BadRequest(CONSTANTS.BAD_REQUEST_MESSAGE);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmploeeDTO createEmployeeDTO)
        {
            try
            {
                var command = _mapper.Map<CreateEmployeeCommand>(createEmployeeDTO);
                var employee = await Mediator.Send(command);

                return Ok(employee);    
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(CONSTANTS.BAD_REQUEST_MESSAGE);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateEmploeeDTO updateEmployeeDTO)
        {
            try
            {
                var command = _mapper.Map<UpdateEmployeeCommand>(updateEmployeeDTO);
            
                var employee = await Mediator.Send(command);

                return Ok(employee);   
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(CONSTANTS.BAD_REQUEST_MESSAGE);
            }
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
