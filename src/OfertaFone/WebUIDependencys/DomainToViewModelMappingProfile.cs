using AutoMapper;
using OfertaFone.Domain.Entities;

namespace OfertaFone.WebUI.WebUIDependencys
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoEntity, ViewModels.Produto.CreateViewModel>().ReverseMap();
            CreateMap<ProdutoEntity, ViewModels.Produto.EditViewModel>().ReverseMap();
            CreateMap<ProdutoEntity, ViewModels.Produto.IndexTableViewModel>().ReverseMap();

            CreateMap<ProdutoEntity, ViewModels.Vitrine.DetailsViewModel>().ReverseMap();
            CreateMap<ProdutoEntity, ViewModels.Vitrine.IndexViewModel>().ReverseMap();

            CreateMap<Usuario, ViewModels.Account.EditProfileViewModel>().ReverseMap();
            CreateMap<Usuario, ViewModels.Account.RegisterViewModel>().ReverseMap();
        }
    }
}
