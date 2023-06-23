using AutoMapper;
using Domain.Entities;
using Poo_AS.Domain.DTOs;
using Poo_AS.Domain.Entities;
using Poo_AS.Domain.ViewModels;

namespace WebApi.Configuration
{
    public class AutoMapperDTOs : Profile
    {
        public AutoMapperDTOs()
        {
            CreateMap<Autor, AutorDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<Livro, LivroDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<Usuario, UsuarioDTO>().PreserveReferences().MaxDepth(0);

        }
    }

    public class AutoMapperViewModels : Profile
    {
        public AutoMapperViewModels()
        {
            CreateMap<AutorViewModel, Autor>();
            CreateMap<LivroViewModel, Livro>();
            CreateMap<UsuarioViewModel, Usuario>();
        
        }
    }
}