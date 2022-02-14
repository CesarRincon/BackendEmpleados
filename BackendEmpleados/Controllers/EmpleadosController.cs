using BackendEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {

        private readonly ApplicationDBContext _dbContext;

        public EmpleadosController(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        // GET: api/<EmpleadosController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            try
            {
                var listEmpleados = await _dbContext.Empleado.ToListAsync();
                return Ok(listEmpleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmpleadosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Empleados empleado)
        {
            try
            {
                _dbContext.Add(empleado);
                await _dbContext.SaveChangesAsync();
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Empleados empleado)
        {
            try
            {
                if(id != empleado.Id)
                {
                    return NotFound();
                }

                _dbContext.Update(empleado);
                await _dbContext.SaveChangesAsync();
                return Ok(new { message = "El empleado fue actualizado con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var empleado = await _dbContext.Empleado.FindAsync(id);

                if(empleado == null)
                {
                    return NotFound();
                }

                _dbContext.Empleado.Remove(empleado);
                await _dbContext.SaveChangesAsync();
                return Ok(new { message = "Empleado eliminado con exito!"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
