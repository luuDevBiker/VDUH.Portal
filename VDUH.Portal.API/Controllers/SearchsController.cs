using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using VDUH.Portal.API.ViewModels;

namespace VDUH.Portal.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SearchsController : ControllerBase {
        private readonly string apiUrl = "http://10.150.1.22:2026/Services/MedicalRecordResultApiVdhu.svc";
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel viewModel)
        {
            using HttpClient client = new HttpClient();
            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl + "/login", content);
                response.EnsureSuccessStatusCode();

                return Ok(await response.Content.ReadAsStringAsync());
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] UserPasswordViewModel viewModel)
        {
            using HttpClient client = new HttpClient();
            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl + "/change-password", content);
                response.EnsureSuccessStatusCode();

                return Ok(await response.Content.ReadAsStringAsync());
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] UserPasswordViewModel viewModel)
        {
            using HttpClient client = new HttpClient();
            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl + "/reset-password", content);
                response.EnsureSuccessStatusCode();

                return Ok(await response.Content.ReadAsStringAsync());
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost("histories")]
        public async Task<IActionResult> Histories([FromBody] GetHistoriesViewModel viewModel)
        {
            using HttpClient client = new HttpClient();
            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl + "/histories", content);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return Ok(result);
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("history")]
        public async Task<IActionResult> History(string key)
        {
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + "/history?id="+key);
                response.EnsureSuccessStatusCode();

                return Ok(await response.Content.ReadAsStringAsync());
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("heal")]
        public async Task<IActionResult> Heal()
        {
            try
            {
                return Ok(Task.FromResult("API HEAL"));
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
