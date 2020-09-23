using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Base.Domain.Intefaces.Servicos;
using Base.Aplicacao.Servicos;
using Base.Aplicacao.Interfaces;
using Base.Domain.Servicos;
using Base.Domain.Intefaces.Repositorios;
using Base.Infra.Repositorios;
using System.Collections;
using System.Collections.Generic;

namespace Base.Core.Ioc
{
    public class DependenceInjector
    {
        public static void Registrar(IServiceCollection svcCollection)
        {
            IEnumerable<System.Reflection.Assembly> assemblies = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories)
                .Select(s => System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(s));

            svcCollection.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(classes =>
            classes.NotInNamespaces("Base.Domain.Entidades")
            .NotInNamespaces("Base.Aplicacao.DTO")
            .NotInNamespaces("Base.Web.Controllers"), publicOnly: true)
            .AsImplementedInterfaces()
            .WithTransientLifetime()
            );

           
        }
    }
}
