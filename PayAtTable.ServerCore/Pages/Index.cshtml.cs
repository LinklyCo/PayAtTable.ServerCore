using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PayAtTable.ServerCore.Helpers;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace PayAtTable.ServerCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> log;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly AppSettings appSettings;
        private readonly HealthCheckService healthCheckService;


        public IndexModel(ILogger<IndexModel> log, IWebHostEnvironment webHostEnvironment, IOptions<AppSettings> appSettings, HealthCheckService healthCheckService)
        {
            this.log = log;
            this.appSettings = appSettings.Value;
            this.webHostEnvironment = webHostEnvironment;
            this.healthCheckService = healthCheckService;
        }

        public async Task OnGet()
        {
            Title = "Home";
            InformationalVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            EnvironmentName = webHostEnvironment.EnvironmentName;
            ContentRootPath = webHostEnvironment.ContentRootPath;
            SettingsPath = System.IO.Path.Combine(ContentRootPath, "appsettings.json");
            WebRootPath = webHostEnvironment.WebRootPath;
            HealthStatus = (await healthCheckService.CheckHealthAsync(CancellationToken.None)).Status.ToString();
        }

        public string Title { get; set; }
        public string InformationalVersion { get; set; }
        public string EnvironmentName { get; set; }
        public string HealthStatus { get; set; }
        public string ContentRootPath { get; set; }
        public string WebRootPath { get; set; }
        public string SettingsPath { get; set; }
    }
}
