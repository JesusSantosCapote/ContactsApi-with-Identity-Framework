using DataAccess.Entitys;

namespace DataAccess.Repositories
{
    public interface IUserRepository
    {
        public Task<UserEntity> GetUserByNameAsync(string username);
    }
}
