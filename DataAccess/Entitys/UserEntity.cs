using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entitys
{
    public class UserEntity: IdentityUser
    {
        public ICollection<ContactEntity> AssociatedContacts { get; set; }
    }
}
