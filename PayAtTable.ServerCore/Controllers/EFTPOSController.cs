using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PayAtTable.Server.Data;
using PayAtTable.Server.Models;
using PayAtTable.ServerCore.Data.Interface;
using System.Threading.Tasks;

namespace PayAtTable.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EftposController : ControllerBase
    {
        private readonly IEftposRepository eftposRepository;
        private readonly ILogger<EftposController> log;

        public EftposController(IEftposRepository eftposRepository, ILogger<EftposController> log)
        {
            this.eftposRepository = eftposRepository;
            this.log = log;
        }

        [HttpPost, Route("commands")]
        [ProducesResponseType(typeof(PatResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PatResponse>> CreateEftposCommand([FromBody] PatRequest commandRequest)
        {
            await Task.CompletedTask; // remove when async calls are added

            // Extract the eftpos command from the request
            if (commandRequest == null || commandRequest.EftposCommand == null)
            {
                return BadRequest("PATRequest.EftposCommand==NULL");
            }

            try
            {
                return Ok(new PatResponse { EftposCommand = eftposRepository.CreateEftposCommand(commandRequest.EftposCommand) });
            }
            catch (InvalidRequestException ex)
            {
                log.LogError("InvalidRequestException in POST ~/api/eftpos/commands.", ex);
                return BadRequest();
            }
            catch (ResourceNotFoundException ex)
            {
                log.LogError("InvalidRequestException in POST ~/api/eftpos/commands.", ex);
                return NotFound();
            }
        }
    }
}
