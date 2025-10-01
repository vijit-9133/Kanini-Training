namespace ManytoManyWithoutJunction.DTO
{
    public class GetDocDTO
    {
        public string? Name { get; set; }
        public string? Specialty { get; set; }
        public List<string>? Patients { get; set; }
    }
}
