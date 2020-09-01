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
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsRepository settingsRepository;
        private readonly ILogger<SettingsController> log;

        public SettingsController(ISettingsRepository settingsRepository, ILogger<SettingsController> log)
        {
            this.log = log;
            this.settingsRepository = settingsRepository;

            log.LogDebug("SettingsController created");
        }

        [ProducesResponseType(typeof(PatResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<PatResponse>> GetSettings()
        {
            await Task.CompletedTask; // remove when async calls are added

            try
            {
                return Ok(new PatResponse { Settings = settingsRepository.GetSettings() });
            }
            catch (InvalidRequestException ex)
            {
                log.LogError("InvalidRequestException in GET ~/api/settings.", ex);
                return BadRequest();
            }
            catch (ResourceNotFoundException ex)
            {
                log.LogError("ResourceNotFoundException in GET ~/api/settings.", ex);
                return NotFound();
            }
        }
    }
}
