using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entitys
{
    public class UserEntity: IdentityUser
    {
        public ICollection<ContactEntity> AssociatedContacts { get; set; }
    }
}
