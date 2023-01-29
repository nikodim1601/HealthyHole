using AutoMapper;
using HealthyHole.Application.Commands.Emploee;
using HealthyHole.Application.Queries.Models;
using HealthyHole.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Domain;
using HealthyHole.Application.Queries;

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
                var query = new GetEmployeesQuery();
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception e)
            {
                // Тут должны быть человеческие логи...
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        [Route("GetPositions")]
        public async Task<ActionResult<string>> GetPositions()
        {
            try
            {
                var positions = Constants.GetJsonPositions();
                return Ok(positions);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Position}")]
        public async Task<ActionResult<EmploeesList>> GetAllWith([FromRoute] GetEmployeesDTO getEmployeesDto)
        {
            try
            {
                var query = _mapper.Map<GetEmployeesQuery>(getEmployeesDto);
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmploeeDTO createEmployeeDto)
        {
            try
            {
                var command = _mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
                var employee = await Mediator.Send(command);

                return Ok(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateEmploeeDTO updateEmployeeDto)
        {
            try
            {
                var command = _mapper.Map<UpdateEmployeeCommand>(updateEmployeeDto);

                var employee = await Mediator.Send(command);

                return Ok(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{employeeId:guid}")]
        public async Task<ActionResult<Guid>> Delete(Guid employeeId)
        {
            try
            {
                var command = new DeleteEmployeeCommand(employeeId);
                var deletedEmployeeId = await Mediator.Send(command);

                // Я еще возвращаю ИДишник. Вдруг понадобится понять, кого удалили.
                return Ok(deletedEmployeeId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
    }
}