using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using ModeloDeDatos;
using ModeloDeNegocio;
using System.Web.Mvc;

namespace CapaDeServicios
{
    public class Servicios
    {
        public void Start()
        {

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<ConveridorColecciones<Nota>, ToINotasFromNotas<Nota>>(Lifestyle.Singleton);
            container.Register<ConveridorColecciones<Notas>, ToNotasFromINotas>(Lifestyle.Singleton);

            container.Register<ConveridorColecciones<Tag>, ToITagsFromTags<Tag>>(Lifestyle.Singleton);
            container.Register<ConveridorColecciones<Tags>, ToTagsFromITags>(Lifestyle.Singleton);

            container.Register<ConveridorColecciones<Categoria>, ToICategoriasFromCategorias<Categoria>>(Lifestyle.Singleton);
            container.Register<ConveridorColecciones<Categorias>, ToCategoriasFromICategorias>(Lifestyle.Singleton);

            container.Register<IFactoryDatos<INotas>, FactoryNota>(Lifestyle.Singleton);
            container.Register<IFactoryDatos<ICategorias>, FactoryCategoria>(Lifestyle.Singleton);
            container.Register<IFactoryDatos<ITags>, FactoryTag>(Lifestyle.Singleton);

            container.Register<ICrud<ICategorias>, CategoriasDAO>(Lifestyle.Singleton);
            container.Register<ICrud<ITags>, TagsDAO>(Lifestyle.Singleton);
            container.Register<ICrud<INotas>, NotasDAO>(Lifestyle.Singleton);

       

            container.RegisterMvcControllers(System.Reflection.Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

    }
}
