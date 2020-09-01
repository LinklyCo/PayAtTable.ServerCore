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
    public class TablesController : ControllerBase
    {
        private readonly IOrderRepository OrderRepository;
        private readonly ITableRepository tableRepository;
        private readonly ILogger<TablesController> log;

        public TablesController(IOrderRepository OrderRepository, ITableRepository tableRepository, ILogger<TablesController> log)
        {
            this.OrderRepository = OrderRepository;
            this.tableRepository = tableRepository;
            this.log = log;
        }

        [ProducesResponseType(typeof(PatResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<PatResponse>> GetTables()
        {
            await Task.CompletedTask; // remove when async calls are added

            try
            {
                return Ok(new PatResponse { Tables = tableRepository.GetTables() });
            }
            catch (InvalidRequestException ex)
            {
                log.LogError("InvalidRequestException in GET ~/api/tables", ex);
                return BadRequest();
            }
            catch (ResourceNotFoundException ex)
            {
                log.LogError("ResourceNotFoundException in GET ~/api/tables", ex);
                return NotFound();
            }
        }

        [ProducesResponseType(typeof(PatResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet, Route("{id}/orders")]
        public async Task<ActionResult<PatResponse>> GetOrdersByTableId([FromRoute] string id)
        {
            await Task.CompletedTask; // remove when async calls are added

            try
            {
                return Ok(new PatResponse { Orders = OrderRepository.GetOrdersFromTable(id) });
            }
            catch (InvalidRequestException ex)
            {
                log.LogError($"InvalidRequestException in GET ~/api/tables/{id}/orders", ex);
                return BadRequest();
            }
            catch (ResourceNotFoundException ex)
            {
                log.LogError($"ResourceNotFoundException in GET ~/api/tables/{id}/orders", ex);
                return NotFound();
            }
        }
    }
}
