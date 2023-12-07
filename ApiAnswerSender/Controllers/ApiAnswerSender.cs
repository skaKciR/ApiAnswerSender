using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnswerSender.Controllers
{
    [ApiController]
    public class ApiAnswerSender : ControllerBase
    {
        private readonly ILogger<ApiAnswerSender> _logger;
        private readonly IConfiguration _configuration;

        public ApiAnswerSender(ILogger<ApiAnswerSender> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("/")]
        public IActionResult Get()
        {
            var message = _configuration["Message:Body"];
            _logger.LogInformation($"К сервису обратились.Текущее значение переменной message - {message}");

            return Ok($"{message}");
        }
    }
}
