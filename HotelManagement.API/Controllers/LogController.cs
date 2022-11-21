using HotelManagement.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using static HotelManagement.Utils.Log;

namespace HotelManagement.API.Controllers
{
    [ApiController]
    [Route("/api/logs")]
    public class LogController : Controller
    {
        ILogger<LogController> logger;
        public LogController(ILogger<LogController> logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult Log([FromBody] LogDetails log)
        {
            var msg = "Hotel Management logging - " + $"MESSAGE: {log.Message} - " +
                        $"FILE: {log.FileName} - " +
                        $"LEVEL: {log.Level} - " +
                        $"LINENUMBER: {log.LineNumber} - " +
                        $"TIMESTAMP: {log.Timestamp}";


            if (log.Level == LogLevelEnum.TRACE)
                logger.LogInformation(msg);
            else if (log.Level == LogLevelEnum.ERROR)
                logger.LogError(msg);
            else if (log.Level == LogLevelEnum.INFO)
                logger.LogInformation(msg);
            else if (log.Level == LogLevelEnum.DEBUG)
                logger.LogError(msg);
            else if (log.Level == LogLevelEnum.WARN)
                logger.LogWarning(msg);
            else
                logger.LogInformation(msg);

            return Ok();
        }
    }
}
