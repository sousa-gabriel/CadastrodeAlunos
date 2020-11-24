using Microsoft.AspNetCore.Mvc;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        public AlunoController()
        {
            
        }
         //Rota com Get Passando Parametros
        [HttpGet("{AlunoId}")]
        public IActionResult Get(int AlunoId)
        {
            return Ok();
        }


        //Rota de Post
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        //Rota Put
        [HttpPut("{AlunoId}")]
        public IActionResult Put(int AlunoId)
        {
            return Ok();
        }
        //Rota de Delete
        [HttpDelete("{AlunoId}")]
        public IActionResult Delete(int AlunoId)
        {
            return Ok();
        }
    }
}