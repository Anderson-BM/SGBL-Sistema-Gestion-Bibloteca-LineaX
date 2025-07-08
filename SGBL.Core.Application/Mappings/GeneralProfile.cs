using AutoMapper;
using SGBL.Core.Application.Dtos.Account;
using SGBL.Core.Application.ViewModels.Author;
using SGBL.Core.Application.ViewModels.Genero;
using SGBL.Core.Application.ViewModels.Libro;
using SGBL.Core.Application.ViewModels.Prestamo;
using SGBL.Core.Application.ViewModels.User;
using SGBL.Core.Domain.Entities;

namespace SGBL.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region LibroProfile
            CreateMap<Libro, LibroViewModel>()
                .ForMember(x => x.AuthorName, opt => opt.Ignore())
                .ForMember(x => x.GeneroName, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Libro, SaveLibroViewModel>()
                .ForMember(x => x.Author, opt => opt.Ignore())
                .ForMember(x => x.Genero, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Author, opt => opt.Ignore())
                .ForMember(x => x.Genero, opt => opt.Ignore());
            #endregion

            #region AutorProfile
            CreateMap<Author, AuthorViewModel>()
                .ForMember(x => x.LibrosQuantity, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Author, SaveAutorViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Libro, opt => opt.Ignore());
            #endregion

            #region GeneroProfile
            CreateMap<Genero, GeneroViewModel>()
                .ForMember(x => x.LibrosQuantity, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Genero, SaveGeneroViewModel>()
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Libro, opt => opt.Ignore());
            #endregion

            #region UserProfile
            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();
            #endregion



            #region PrestamoProfile
            CreateMap<Prestamo, SavePrestamoViewModel>()
                 .ReverseMap()
                 .ForMember(x => x.Created, opt => opt.Ignore())
                 .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                 .ForMember(x => x.LastModified, opt => opt.Ignore())
                 .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                 .ForMember(x => x.Libro, opt => opt.Ignore())
                 .ForMember(x => x.Usuario, opt => opt.Ignore());

            CreateMap<Prestamo, PrestamoViewModel>()
                .ForMember(dest => dest.TituloLibro, opt => opt.MapFrom(src => src.Libro.Name))
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.Usuario.Name))
                .ReverseMap()
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Libro, opt => opt.Ignore())
                .ForMember(x => x.Usuario, opt => opt.Ignore());
            #endregion

        }
    }
}
