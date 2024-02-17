using Attendance.Data;
using Attendance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Attendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController(AttendanceDbContext _context) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(TbAttendance[]), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Attendances.ToListAsync();

            return Ok(result);
        }

        [HttpGet("{studentId:int}")]
        [ProducesResponseType(typeof(TbAttendance), 200)]
        public async Task<IActionResult> GetById(int studentId)
        {
            var result = await _context.Attendances.FirstOrDefaultAsync(x => x.StudentId == studentId);   

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TbAttendance), 200)]
        [ProducesResponseType(typeof(Exception), (int)(HttpStatusCode.BadRequest))]
        public async Task<IActionResult> Add(TbAttendance attendance)
        {
            if (attendance == null)
            {
                return BadRequest();
            }

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return Ok(attendance);
        }

        [HttpPut]
        [ProducesResponseType(typeof(NoContent), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(TbAttendance attendance)
        {
            if(attendance == null)
            {
                return BadRequest();
            }

            int recordsAffected =  await _context.Attendances.Where(x => x.StudentId == attendance.StudentId)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.AttendancePercentage, x => attendance.AttendancePercentage));

            if(recordsAffected == 0)
            {
                return NoContent();
            }

            return Ok(recordsAffected);
        }

        [HttpDelete("{studentId:int}/delete")]
        public async Task<IActionResult> Delete(int studentId)
        {
            if(studentId == 0)
            {
                return BadRequest("StudentId can't be 0");
            }

            var recordsAffected = await _context.Attendances.Where(x => x.StudentId == studentId).ExecuteDeleteAsync();
            if(recordsAffected == 0)
            {
                return BadRequest($"StudentId = {studentId} not found in db");
            }

            return Ok(recordsAffected);
        }
    }
}
