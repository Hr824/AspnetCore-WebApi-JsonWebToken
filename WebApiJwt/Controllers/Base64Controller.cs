using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace WebApiJwt.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class Base64Controller : ControllerBase
    {
        //GET api/base64/convertto/{stringToConvert}
        [HttpGet("convertto/{stringToConvert}")]
        public IActionResult ConvertStringToBase64String(string stringToConvert)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(stringToConvert);
            string result = Convert.ToBase64String(byteArray);

            return Ok(result);
        }


        //GET api/base64/convertfrom/{stringToConvert}
        [HttpGet("convertfrom/{stringToConvert}")]
        public IActionResult ConvertStringFromBase64String(string stringToConvert)
        {
            byte[] byteArray = Convert.FromBase64String(stringToConvert);
            string result = Encoding.UTF8.GetString(byteArray);

            return Ok(result);
        }
    }
}