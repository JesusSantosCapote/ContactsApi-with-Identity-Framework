namespace DataAccess.Entitys
{
    public class ContactEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Owner { get; set; }
        public UserEntity OwnerUser { get; set; }
    }
}
