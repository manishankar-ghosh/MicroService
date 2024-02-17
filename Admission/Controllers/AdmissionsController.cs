using Admission.Data;
using Admission.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
//Mani
namespace Admission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(TbAdmission[]), 200)]
    public class AdmissionsController(AdmissionDbContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAddStudents()
        {
            var result = await _context.Admissions.ToListAsync();

            return Ok(result);
        }

        [HttpGet("{studentId:int}")]
        [ProducesResponseType(typeof(TbAdmission), 200)]
        public async Task<IActionResult> GetStudentById(int studentId)
        {
            var result = await _context.Admissions.FirstOrDefaultAsync(x => x.StudentId == studentId);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TbAdmission), 200)]
        [ProducesResponseType(typeof(BadRequest), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Add(TbAdmission admission)
        {
            if (admission == null)
            {
                return BadRequest("Please supply the required details");
            }

            admission.DOA = DateTime.UtcNow;
            _context.Admissions.Add(admission);
            await _context.SaveChangesAsync();

            return Ok(admission);
        }

        [HttpPut]
        [ProducesResponseType(typeof(NoContent), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(TbAdmission admission)
        {
            if (admission == null)
            {
                return BadRequest("Please supply the required details");
            }

            if (admission.StudentId == 0)
            {
                return BadRequest("StudentId not found in the request");
            }

            _context.Admissions.Update(admission);
            int recordsAffected = await _context.SaveChangesAsync();
            if(recordsAffected == 0)
            {
                return NoContent();
            }

            return Ok(recordsAffected);
        }

        [HttpDelete("{StudentId:int}/delete")]
        [ProducesResponseType(typeof(TbAdmission), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequest), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NotFound), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int studentId)
        {
            if (studentId == 0)
            {
                return BadRequest("StudentId can't be 0");
            }

            var admission = new TbAdmission { StudentId = studentId };
            int recordsAffected = await _context.Admissions.Where(x => x.StudentId == studentId).ExecuteDeleteAsync();

            if (recordsAffected == 0)
            {
                return NotFound($"StudentId = {admission.StudentId} not found in the db");
            }

            return Ok();
        }
    }
}
