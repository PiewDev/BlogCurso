using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ModeloDeDatos
{
    
    public class TagsDAO : ICrud<ITags>
    {
        private ITagsFactory Factory;
        private ConveridorColecciones<Notas> Converter;

        //CONSTRUCTOR
        public TagsDAO(ITagsFactory Factory, ConveridorColecciones<Notas> Converter)
        {
            this.Converter = Converter;
            this.Factory = Factory;
        }


        public int Crear(ITags Modelo)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            Tags nuevaTag = new Tags()
            {
                Nombre = Modelo.Nombre
                
            };

            contexto.Tags.Add(nuevaTag);
            contexto.SaveChanges();

            return nuevaTag.Id;
        }

        public int Actualizar(ITags Modelo)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            var tag = contexto.Tags.Where(x => x.Id == Modelo.Id).FirstOrDefault();
            tag.Nombre = Modelo.Nombre;
            tag.Notas = Converter.Convertir(Modelo.Notas);
           
            contexto.SaveChanges();
            return Modelo.Id;
        }

        public void Eliminar(int Id)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            var tag = contexto.Tags.Where(x => x.Id == Id).FirstOrDefault();
            tag.Estado = false;
            contexto.SaveChanges();
        }

        public List<ITags> Listar(int Max = 10)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            var results = contexto.Tags.Where(x => x.Estado == true).Take(Max).ToList();
            List<ITags> tagsInt = new List<ITags>();

            foreach (var tag in results)
            {
                var nuevatag = this.Factory.NuevaTag();
                nuevatag.Id = tag.Id;
                nuevatag.Nombre = tag.Nombre;
                nuevatag.Estado = tag.Estado;
                nuevatag.Notas = Converter.Convertir(tag.Notas.ToList()).Cast<INotas>().ToList();
                tagsInt.Add(nuevatag);
            }

            return tagsInt;
        }
    }
}
