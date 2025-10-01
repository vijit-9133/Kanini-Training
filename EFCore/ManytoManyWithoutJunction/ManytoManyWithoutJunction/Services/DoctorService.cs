using ManytoManyWithoutJunction.DTO;
using ManytoManyWithoutJunction.Interfaces;
using ManytoManyWithoutJunction.Models;
using ManytoManyWithoutJunction.Repository;

namespace ManytoManyWithoutJunction.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly DocRepo _repo;
        public DoctorService(DocRepo repo)
        {
            _repo = repo;
        }
        public async Task<GetDocDTO> Add(CreateDocDTO doctorDTO)
        {
            var doc = new Doctor
            {
                Name = doctorDTO.Name,
                Specialty = doctorDTO.Specialty,
               
            };
            await _repo.Add(doc);
            return new GetDocDTO
            {
                Name = doc.Name,
                Specialty = doc.Specialty,
                Patients = new List<string>()
            };
        }

        public async Task<IEnumerable<GetDocDTO>> GetAllDoc()
        {
            var doc = await _repo.GetAll();
            return doc.Select(d => new GetDocDTO
            {
                Name = d.Name,
                Specialty = d.Specialty,
                Patients = d.Patients?.Select(p => p.Name).ToList()
            });
        }
    }
}
