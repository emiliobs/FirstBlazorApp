using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsDBContext _context = new StudentsDBContext();


        [HttpGet]
        public IEnumerable<StudentMasters> GetStudentMasters()
        {
            return _context.StudentMasters;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentMasters([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await _context.StudentMasters.FindAsync(id);
            if (student.Equals(id))
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, StudentMasters student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StdId)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch 
            {
                return NotFound();
                         
            }

            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentMasters student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StudentMasters.Add(student);

            try
            {
                await _context.SaveChangesAsync();

            }
            catch
            {

                return NotFound();
            }

            return CreatedAtAction("GetStudentMasters", new { id = student.StdId }, student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await _context.StudentMasters.FindAsync(id);
            if (student.Equals(null))
            {
                return NotFound();
            }

            _context.StudentMasters.Remove(student);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {

                return BadRequest(ModelState);
            }

            return Ok(student);
        }
    }
}