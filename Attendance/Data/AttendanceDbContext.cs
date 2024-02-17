using Attendance.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance.Data
{
    public class AttendanceDbContext : DbContext
    {
        public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options) : base(options)
        {
            
        }

        public DbSet<TbAttendance> Attendances { get; set; }
    }
}
