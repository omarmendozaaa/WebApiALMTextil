using AutoMapper;
using WebApiALMTextil.DTO.LoginDTO;
using WebApiALMTextil.Entities;

namespace WebApiALMTextil.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<ContactoClienteDTO, ContactoCliente>();
            CreateMap<EmpresaDTO, Empresa>();
            ////////////////////////////////////////////////////////////////////////////
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<ContactoClienteDTO, ContactoCliente>().ReverseMap();
            CreateMap<EmpresaDTO, Empresa>().ReverseMap();
        }
    }
}