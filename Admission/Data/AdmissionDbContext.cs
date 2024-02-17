using Microsoft.EntityFrameworkCore;
using Admission.Models;
namespace Admission.Data
{
    public class AdmissionDbContext : DbContext
    {
        public AdmissionDbContext(DbContextOptions<AdmissionDbContext> options) : base(options)
        {
            
        }

        public DbSet<TbAdmission> Admissions { get; set; }
    }
}
