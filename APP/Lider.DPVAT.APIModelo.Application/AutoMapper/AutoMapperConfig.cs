using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lider.DPVAT.APIModelo.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToDTOUsuarioMappingProfile>();
            });
        }
    }
}
