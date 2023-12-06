using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnswerGetter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerGetterController : ControllerBase
    {
        private readonly ILogger<AnswerGetterController> _logger;
        private readonly HttpClient _httpClient;

        public AnswerGetterController(ILogger<AnswerGetterController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            // Получение адреса из конфигурации
            var apiUrl = "ApiUrl";

            // Логирование
            _logger.LogInformation($"ApiAnswerGetter: Handling GET request, sending request to {apiUrl}");

            // Отправка запроса к ApiAnswerSender
            var response = await _httpClient.GetStringAsync(apiUrl);

            return response;
        }
    }
}
