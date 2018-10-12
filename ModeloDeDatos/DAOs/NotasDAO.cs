using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ModeloDeDatos
{
    
    public class NotasDAO: ICrud<INotas>
    {
        private INotasFactory Factory;
        private ConveridorColecciones<Tags> TagConverter;
        private ConveridorColecciones<Categorias> CategoriaConverter;


        //CONSTRUCTOR
        public NotasDAO(INotasFactory Factory, ConveridorColecciones<Tags> TagConverter, ConveridorColecciones<Categorias> CategoriaConverter)
        {
            this.Factory = Factory;
            this.CategoriaConverter = CategoriaConverter;
            this.TagConverter = TagConverter;
 
        }

       
        public int Crear(INotas Modelo)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            Notas nuevaNota = new Notas()
            {
                Autor = Modelo.Autor,
                Cuerpo = Modelo.Cuerpo,
                Estado = true,
                FechaBaja = null,
                FechaCreacion = DateTime.Now,
                FechaModificacion = null,
                Tags = this.TagConverter.Convertir(Modelo.Tags),
                Titulo = Modelo.Titulo,
                Categorias = this.CategoriaConverter.Convertir(Modelo.Categorias)
        };
                       
            contexto.Notas.Add(nuevaNota);
            contexto.SaveChanges();

            return nuevaNota.Id;
        }

        public int Actualizar(INotas Modelo)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            var nota = contexto.Notas.Where(x => x.Id == Modelo.Id).FirstOrDefault();
            nota.Cuerpo = Modelo.Cuerpo;
            nota.FechaModificacion = DateTime.Now;
            nota.Tags = this.TagConverter.Convertir(Modelo.Tags);
            nota.Titulo = Modelo.Titulo;
            nota.Categorias = this.CategoriaConverter.Convertir(Modelo.Categorias);
            contexto.SaveChanges();
            return Modelo.Id;
        }

        public void Eliminar(int Id)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            var nota = contexto.Notas.Where(x => x.Id == Id).FirstOrDefault();
            nota.FechaBaja = DateTime.Now;
            nota.Estado = false;
            contexto.SaveChanges();
        }

        public List<INotas> Listar(int Max = 10)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            var results = contexto.Notas.Where(x => x.Estado == true).Take(Max).ToList();
            List<INotas> notasInt = new List<INotas>();

            foreach (var nota in results)
            {
                var nuevaNota = this.Factory.NuevaNota();
                nuevaNota.Autor = nota.Autor;
                nuevaNota.Cuerpo = nota.Cuerpo;
                nuevaNota.FechaCreacion = nota.FechaCreacion;
                nuevaNota.FechaModificacion = nota.FechaModificacion;
                nuevaNota.Tags = this.TagConverter.Convertir(nota.Tags.ToList()).Cast<ITags>().ToList(); 
                nuevaNota.Titulo = nota.Titulo;
                nuevaNota.Id = nota.Id;
                nuevaNota.Categorias = this.CategoriaConverter.Convertir(nota.Categorias.ToList()).Cast<ICategorias>().ToList();

                notasInt.Add(nuevaNota);
            }

            return notasInt;
        }
    }
}
