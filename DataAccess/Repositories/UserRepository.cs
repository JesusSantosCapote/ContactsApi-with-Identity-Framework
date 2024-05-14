using DataAccess.DataContexts;
using DataAccess.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ContactsManagerContext _userManagerContext;
        public UserRepository(ContactsManagerContext userManagerContext) 
        {
            _userManagerContext = userManagerContext;
        }
        public async Task<UserEntity> GetUserByNameAsync(string username)
        {
            UserEntity user = await _userManagerContext.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();

            if (user is default(UserEntity)) return null;
            return user;
        }
    }
}
