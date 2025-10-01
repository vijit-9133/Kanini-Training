using ManytoManyWithoutJunction.Models;
using Microsoft.EntityFrameworkCore;

namespace ManytoManyWithoutJunction.Repository
{
    public class DocRepo : Interfaces.IDoctorRepo<Doctor>
    {
        private readonly Data.DocPatDbContext _context;
        public DocRepo(Data.DocPatDbContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Add(Doctor entity)
        {
            _context.Doctors.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
             return await _context.Doctors
                .Include(d => d.Patients)
                .ToListAsync();
        }
    }
}
