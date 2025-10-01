using ManytoManyWithoutJunction.DTO;

namespace ManytoManyWithoutJunction.Interfaces
{
    public interface IDoctorService
    {
        Task<GetDocDTO>? Add(CreateDocDTO doctorDTO);
        Task<IEnumerable<GetDocDTO>> GetAllDoc();
    }
}
