using Microsoft.AspNetCore.Mvc;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        public ProfessorController()
        {
            
        }
        //criando minhas rotas Get/Post/Delete/Put
        //Rota Get
        [HttpGet]
        public IActionResult Get()
        {
           return Ok(); 
        }

        //Rota com Get Passando Parametros
        [HttpGet("{ProfessorId}")]
        public IActionResult Get(int ProfessorId)
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
        [HttpPut("{ProfessorId}")]
        public IActionResult Put(int ProfessorId)
        {
            return Ok();
        }
        //Rota de Delete
        [HttpDelete("{ProfessorId}")]
        public IActionResult Delete(int ProfessorId)
        {
            return Ok();
        }
    }
}