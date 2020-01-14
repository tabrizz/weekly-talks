using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeeklyTalks.Dtos;
using WeeklyTalks.Models;

namespace WeeklyTalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly db_weeklytalksContext _context;
        private IMapper _mapper;

        public EmployeesController(db_weeklytalksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees([FromQuery]int status=1)
        {
            return await _context.Employees.Where(e => e.Status == status)
                .ToListAsync();
        }

        [HttpGet("office/{id}")]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployeesByOffice(int id)
        {
            return await _context.Employees.Where(e => e.OfficeId == id).ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployees(long id)
        {
            var employees = await _context.Employees.FindAsync(id);

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployees(long id, [FromBody]CreateEmployeeDto createEmployeeDto)
        {
            if (id != createEmployeeDto.Id)
            {
                return BadRequest();
            }
            var employee = _mapper.Map<Employees>(createEmployeeDto);
            employee.CreatedAt = DateTime.Now;
            employee.UpdatedAt = DateTime.Now;
            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employees>> PostEmployees([FromBody]CreateEmployeeDto createEmployeeDto)
        {
            var employee = _mapper.Map<Employees>(createEmployeeDto);
            employee.UpdatedAt = DateTime.Now;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployees", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employees>> DeleteEmployees(long id)
        {
            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();

            return employees;
        }

        private bool EmployeesExists(long id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
