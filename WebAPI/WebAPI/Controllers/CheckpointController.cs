using System;
using System.Threading.Tasks;
using AutoMapper;
using HealthyHole.Application.Queries;
using HealthyHole.Application.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthyHole.WebAPI.Controllers
{
    // [Route("api/[controller]")]
    // public class CheckpointController : BaseController
    // {
    //     private readonly IMapper _mapper;
    //
    //     public CheckpointController(IMapper mapper)
    //     {
    //         _mapper = mapper;
    //     }
    //     
    //     [HttpGet("{employeeId:guid}")]
    //     [Route("StartShift")]
    //     public async Task<ActionResult<EmploeesList>> StartShift(Guid employeeId)
    //     {
    //         try
    //         {
    //             var query = new GetEmployeesQuery();
    //             var vm = await Mediator.Send(query);
    //             return Ok(vm);
    //         }
    //         catch (Exception e)
    //         {
    //             Console.WriteLine(e);
    //             return BadRequest(e.Message);
    //         }
    //     }
    //     
    //     [HttpGet("{employeeId:guid}")]
    //     [Route("EndShift")]
    //     public async Task<ActionResult<EmploeesList>> EndShift(Guid employeeId)
    //     {
    //         try
    //         {
    //             var query = new GetEmployeesQuery();
    //             var vm = await Mediator.Send(query);
    //             return Ok(vm);
    //         }
    //         catch (Exception e)
    //         {
    //             Console.WriteLine(e);
    //             return BadRequest(e.Message);
    //         }
    //     }
    // }
}