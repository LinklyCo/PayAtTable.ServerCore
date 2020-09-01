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
    public class OrdersController : ControllerBase
    {
        protected readonly IOrderRepository OrderRepository;
        private readonly ILogger<OrdersController> log;

        public OrdersController(IOrderRepository OrderRepository, ILogger<OrdersController> log)
        {
            this.OrderRepository = OrderRepository;
            this.log = log;
        }

        [ProducesResponseType(typeof(PatResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet, Route("{id}")]
        public async Task<ActionResult<PatResponse>> GetOrder([FromRoute] string id)
        {
            await Task.CompletedTask; // remove when async calls are added

            try
            {
                return Ok(new PatResponse() { Order = OrderRepository.GetOrder(id) });
            }
            catch (InvalidRequestException ex)
            {
                log.LogError($"InvalidRequestException in GET ~/api/orders/{id}", ex);
                return BadRequest();
            }
            catch (ResourceNotFoundException ex)
            {
                log.LogError($"ResourceNotFoundException in GET ~/api/orders/{id}", ex);
                return NotFound();
            }
        }

        [ProducesResponseType(typeof(PatResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet, Route("{id}/receipt")]
        public async Task<IActionResult> GetOrderCustomerReceipt([FromRoute] string id, [FromQuery] string receiptOptionId = null)
        {
            await Task.CompletedTask; // remove when async calls are added

            var option = receiptOptionId ?? string.Empty;

            try
            {
                return Ok(new PatResponse() { Receipt = OrderRepository.GetCustomerReceiptFromOrderId(id, option) });
            }
            catch (InvalidRequestException ex)
            {
                log.LogError($"InvalidRequestException in GET ~/api/orders/{id}/receipt?receiptOptionId={option}", ex);
                return BadRequest();
            }
            catch (ResourceNotFoundException ex)
            {
                log.LogError($"ResourceNotFoundException in GET ~/api/orders/{id}/receipt?receiptOptionId={option}", ex);
                return NotFound();
            }
        }
    }
}
