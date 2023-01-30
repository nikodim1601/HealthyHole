using AutoMapper;
using HealthyHole.Application.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using HealthyHole.Application.Commands.EmployeeCommands;
using HealthyHole.Application.Queries;
using HealthyHole.Domain;
using HealthyHole.WebAPI.DTOModels;

namespace HealthyHole.WebAPI.Controllers
{
    /// <summary>
    /// Отдел кадров.
    /// </summary>
    [Route("api/[controller]")]
    public class PersonalDepartmentController : BaseController
    {
        /// <summary>
        /// Возвращает список всех работников.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<EmployeeList>> GetAll()
        {
            try
            {
                var query = new GetEmployeesQuery();
                var employeeList = await Mediator.Send(query);
                // Тут баг. В обьекте в свойстве EmployeeId есть значение, а в ответе null.
                return Ok(employeeList);
            }
            catch (Exception e)
            {
                // Тут должны быть человеческие логи...
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Возвращает список всех должностей.
        /// </summary>
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

        /// <summary>
        /// Возвращает список работников по выбранной должности.
        /// </summary>
        [HttpGet("{Position}")]
        public async Task<ActionResult<EmployeeList>> GetAllWith([FromRoute] GetEmployeesDto getEmployeesDto)
        {
            try
            {
                var query = Mapper.Map<GetEmployeesQuery>(getEmployeesDto);
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Создает работника.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            try
            {
                var command = Mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
                var employee = await Mediator.Send(command);

                return Ok(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Изменяет работника.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            try
            {
                var command = Mapper.Map<UpdateEmployeeCommand>(updateEmployeeDto);

                var employee = await Mediator.Send(command);

                return Ok(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Удаляет работника.
        /// </summary>
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