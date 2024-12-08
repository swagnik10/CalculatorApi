using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET: api/calculator/add
        [HttpGet("add")]
        public IActionResult Add([FromQuery] double num1, [FromQuery] double num2)
        {
            double result = num1 + num2;
            return Ok(result);
        }

        // GET: api/calculator/subtract
        [HttpGet("subtract")]
        public IActionResult Subtract([FromQuery] double num1, [FromQuery] double num2)
        {
            double result = num1 - num2;
            return Ok(result);
        }

        // GET: api/calculator/multiply
        [HttpGet("multiply")]
        public IActionResult Multiply([FromQuery] double num1, [FromQuery] double num2)
        {
            double result = num1 * num2;
            return Ok(result);
        }

        // GET: api/calculator/divide
        [HttpGet("divide")]
        public IActionResult Divide([FromQuery] double num1, [FromQuery] double num2)
        {
            if (num2 == 0)
            {
                return BadRequest("Division by zero is not allowed.");
            }
            double result = num1 / num2;
            return Ok(result);
        }
    }
}
