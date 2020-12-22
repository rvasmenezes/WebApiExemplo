using AutoMapper;
using Lider.DPVAT.APIModelo.Domain.DTO;
using Lider.DPVAT.APIModelo.Domain.Entities;
using Lider.DPVAT.APISimilaridade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lider.DPVAT.APIModelo.Application.AutoMapper
{
    public class DomainToDTOUsuarioMappingProfile : Profile
    {
        public DomainToDTOUsuarioMappingProfile()
        {
            CreateMap<TbUsuario, UsuarioDTO>()
           
           .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario))
           .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Nome) ? src.Nome : null))
           .ForMember(dest => dest.Login, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Login) ? src.Login : null))
           .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Senha) ? src.Senha : null))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Email) ? src.Email : null))
           .ForMember(dest => dest.FlagAtivo, opt => opt.MapFrom(src => src.FlagAtivo))
           .ForMember(dest => dest.FlagSupervisor, opt => opt.MapFrom(src => src.FlagSupervisor))
           .ForMember(dest => dest.FlagGerente, opt => opt.MapFrom(src => src.FlagGerente))
           .ForMember(dest => dest.DataAtualizacao, opt => opt.MapFrom(src => src.DataAtualizacao))
           .ForMember(dest => dest.IdUsuarioAtualizacao, opt => opt.MapFrom(src => src.IdUsuarioAtualizacao))
           .ForMember(dest => dest.CrmGerente, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.CrmGerente) ? src.CrmGerente : null))
           .ForMember(dest => dest.UfCrmGerente, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.UfCrmGerente) ? src.UfCrmGerente : null))
           .ForMember(dest => dest.FlagPrimeiroLogon, opt => opt.MapFrom(src => src.FlagPrimeiroLogon))
           .ReverseMap();
        }
    }
}
