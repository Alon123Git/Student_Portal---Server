namespace Student_Admin_Portal.API.Models.DTO
{
    public class AddressDTO
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public Guid StudentId { get; set; }
    }
}
