using BusinessLogic.DTO;
using BusinessLogic.Result;

namespace BusinessLogic.Services
{
    public interface IContactService
    {
        public Task<Result<ContactDetailDto>> GetContactAsync(Guid id, string username);
        public Task<Result<List<ContactDetailDto>>> GetAllContactsAsync(string username);
        public Task<Result<ContactDetailDto>> AddContactAsync(ContactDto contact, string username);
        public Task<Result<ContactDetailDto>> DeleteAsync(Guid id, string username);
        public Task<Result<ContactDetailDto>> UpdateContactAsync(Guid id, ContactDto contact, string username);

    }
}
