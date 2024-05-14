using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entitys;

namespace BusinessLogic.Mapper
{
    internal class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactDto, ContactEntity>();
            CreateMap<ContactEntity, ContactDto>();
            CreateMap<ContactEntity, ContactDetailDto>();
        }
    }
}
