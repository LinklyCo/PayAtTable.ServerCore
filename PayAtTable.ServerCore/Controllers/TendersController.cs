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
    [Route("api/[Controller]")]
    public class TendersController : ControllerBase
    {
        private readonly ITenderRepository tenderRepository;
        private readonly ILogger<TendersController> log;

        public TendersController(ITenderRepository tenderRepository, ILogger<TendersController> log)
        {
            this.tenderRepository = tenderRepository;
            this.log = log;
        }

        [ProducesResponseType(typeof(PatResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<ActionResult<PatResponse>> CreateTender([FromBody] PatRequest tenderRequest)
        {
            await Task.CompletedTask; // remove when async calls are added

            // Extract the tender from the request
            if (tenderRequest == null || tenderRequest.Tender == null)
            {
                log.LogError("TenderRequest.Tender==NULL in POST ~/api/tenders.");
                return BadRequest();
            }

            try
            {
                return Created("", new PatResponse { Tender = tenderRepository.CreateTender(tenderRequest.Tender) });
            }
            catch (InvalidRequestException ex)
            {
                log.LogError("InvalidRequestException in POST ~/api/tenders.", ex);
                return BadRequest();
            }
            catch (ResourceNotFoundException ex)
            {
                log.LogError("ResourceNotFoundException in POST ~/api/tenders.", ex);
                return NotFound();
            }
        }

        [ProducesResponseType(typeof(PatResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateTender([FromRoute] string id, [FromBody] PatRequest tenderRequest)
        {
            await Task.CompletedTask; // remove when async calls are added

            // Extract the tender from the request
            if (tenderRequest == null || tenderRequest.Tender == null)
            {
                log.LogError("TenderRequest.Tender==NULL in PUT ~/api/tenders.");
                return BadRequest();
            }

            // Validate the tender id
            if (!tenderRequest.Tender.Id.Equals(id))
            {
                log.LogError("tenderRequest.Tender.Id != param id in PUT ~/api/tenders.");
                return BadRequest();
            }

            try
            {
                return Ok(new PatResponse { Tender = tenderRepository.UpdateTender(tenderRequest.Tender) });
            }
            catch (InvalidRequestException ex)
            {
                log.LogError("InvalidRequestException in PUT ~/api/tenders.", ex);
                return BadRequest();
            }
            catch (ResourceNotFoundException ex)
            {
                log.LogError("ResourceNotFoundException in PUT ~/api/tenders.", ex);
                return NotFound();
            }
        }
    }
}
