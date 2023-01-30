using System;
using System.Threading.Tasks;
using HealthyHole.Application.Commands.CheckpointCommands;
using HealthyHole.WebAPI.DTOModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthyHole.WebAPI.Controllers
{
    /// <summary>
    /// КППшка.
    /// </summary>
    [Route("api/[controller]")]
    public class CheckpointController : BaseController
    {
        /// <summary>
        /// Начинает смену.
        /// </summary>
        [HttpPost]
        [Route("StartShift")]
        public async Task<ActionResult<Unit>> StartShift([FromBody] StartShiftDto startShiftDto)
        {
            try
            {
                var command = Mapper.Map<StartShiftCommand>(startShiftDto);
                await Mediator.Send(command);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
        
        /// <summary>
        /// Завершает смену.
        /// </summary>
        [HttpPost]
        [Route("EndShift")]
        public async Task<ActionResult<Unit>> EndShift([FromBody] EndShiftDto endShiftDto )
        {
            try
            {
                var command = Mapper.Map<EndShiftCommand>(endShiftDto);
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