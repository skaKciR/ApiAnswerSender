using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnswerCaller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerGetterController : ControllerBase
    {
        private readonly ILogger<AnswerGetterController> _logger;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public AnswerGetterController(ILogger<AnswerGetterController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
           
            var apiUrl = _configuration["ApiUrl"];
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, apiUrl);

            _logger.LogInformation($"Исходящий запрос: {DateTime.UtcNow} {requestMessage.Method} {requestMessage.RequestUri}");

            _logger.LogInformation($"Попытка обращения к: {requestMessage.RequestUri}");


            var response = await _httpClient.GetStringAsync(apiUrl);
            _logger.LogInformation($"Ответ получен: {response}");

            return response;
        }
    }

}
