using EJ12.DAL;
using EJ12.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EJ12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        private AppDbContext _context { get; }

        public EmpleadoController(AppDbContext context)
        {

            _context = context;


        }


        [HttpGet]
        public async Task<IEnumerable<Empleado>> GetAll()
        {

            var empleados = await _context.Empleados.ToListAsync();

            return empleados;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetById(int id)
        {

            Empleado empleado = await _context.Empleados.FindAsync(id);

            if(empleado == null)
            {

                return NotFound();

            }


            return Ok(empleado);
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Empleado empleadoXX)
        {

            if (empleadoXX == null)
            {
                NoContent();
            }

            _context.Empleados.Add(empleadoXX);
            await _context.SaveChangesAsync();


            return Created("Se creo", empleadoXX);

        }
           

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Empleado empleado) 
        {

            Empleado empleadoX = await _context.Empleados.FindAsync(id);

            if(empleadoX == null)
            {
                return NotFound();
            }


            empleadoX.Nombre = empleado.Nombre;
            empleadoX.Apellido = empleado.Apellido;
            empleadoX.Telefono = empleado.Telefono;


            await _context.SaveChangesAsync();


            return Ok(empleado);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {

            var empleado = await _context.Empleados.FindAsync(id);

            if(empleado == null)
            {
               return NotFound();
            }


            _context.Empleados.Remove(empleado);

            await _context.SaveChangesAsync();

            return Ok(empleado);
        }



    }
}
