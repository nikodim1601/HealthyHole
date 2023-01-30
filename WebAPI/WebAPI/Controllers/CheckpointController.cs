using System;
using System.Threading.Tasks;
using AutoMapper;
using HealthyHole.Application.Commands.CheckpointCommands;
using HealthyHole.WebAPI.DTOModels;
using HealthyHole.WebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthyHole.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CheckpointController : BaseController
    {
        private readonly IMapper _mapper;
    
        public CheckpointController(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        [HttpPost]
        [Route("StartShift")]
        public async Task<ActionResult<Unit>> StartShift([FromBody] StartShiftDTO startShiftDto)
        {
            try
            {
                var command = _mapper.Map<StartShiftCommand>(startShiftDto);
                await Mediator.Send(command);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        [Route("EndShift")]
        public async Task<ActionResult<Unit>> EndShift([FromBody] EndShiftDTO endShiftDto )
        {
            try
            {
                var command = _mapper.Map<EndShiftCommand>(endShiftDto);
                await Mediator.Send(command);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
    }
}