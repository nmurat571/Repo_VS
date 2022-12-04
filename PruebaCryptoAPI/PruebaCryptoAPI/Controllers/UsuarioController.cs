using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaCryptoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuarioController>/5
        //[HttpGet("{id}")] indica que el id es REQUERIDO
        [HttpGet("{numero1}/{numero2}")] //varios params se separan con /
        //siempre devolvemos string
        public string Get(int numero1, int numero2)
        {
            try
            {
                string numero;
                if(numero2 > 0)
                {
                    numero = (numero1 / numero2).ToString();
                }
                else 
                {
                    numero = "No se puede hacer esa división";
                }
                return numero;
            }
            catch(Exception ex) 
            {
                return ex.Message;
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
