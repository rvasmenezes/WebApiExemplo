using Lider.DPVAT.APIModelo.Application;
using Lider.DPVAT.APIModelo.Application.Interfaces;
using Lider.DPVAT.APIModelo.Domain.Interfaces;
using Lider.DPVAT.APIModelo.Domain.Interfaces.Repository;
using Lider.DPVAT.APIModelo.Domain.Interfaces.Services;
using Lider.DPVAT.APIModelo.Domain.Services;
using Lider.DPVAT.APIModelo.Infra.Data.Context;
using Lider.DPVAT.APIModelo.Infra.Data.Repositories;
using Lider.DPVAT.APIModelo.Infra.Data.UnityOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lider.DPVAT.APIModelo.Infra.CrossCutting.IOC
{
    public class IOC
    {
        //LogSimilaridadeSinistro
        public void InjecaoAppService(IServiceCollection services)
        {
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ExampleAPIProjectContext>();
        }

        public void InjecaoDomain(IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
        }

        public void InjecaoRepository(IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
