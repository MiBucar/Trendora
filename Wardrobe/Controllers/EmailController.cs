using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;
using SendGrid;
using Wardrobe.Models.ViewModels;

namespace Wardrobe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly string SendGridApiKey = "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";

        [HttpPost("sendemail")]
        public async Task<IActionResult> SendEmail([FromBody] string subscribeEmail)
        {
            try
            {
                var client = new SendGridClient(SendGridApiKey);
                var from = new EmailAddress("mislavbucar@gmail.com", "Mislav Bučar");
                var to = new EmailAddress(subscribeEmail);
                var subject = "Trendora Newsletter";
                var plainTextContent = "Thank you for subscribing, check out my LinkedIn displayed on the website!";
                var htmlContent = "" + "<p>Thank you for checking out my project! Check out my LinkedIn https://www.linkedin.com/in/mislav-bu%C4%8Dar-19740323b/!</p>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                var response = await client.SendEmailAsync(msg);

                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return Ok("Email sent successfully");
                }
                else
                {
                    return BadRequest($"Failed to send email. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return BadRequest($"Failed to send email: {ex.Message}");
            }
        }
    }
}