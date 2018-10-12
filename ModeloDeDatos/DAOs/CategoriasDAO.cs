using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ModeloDeDatos
{   
    public class CategoriasDAO : ICrud<ICategorias>
    {       
        private ICategoriasFactory Factory;
        private ConveridorColecciones<Notas> Converter;

        //CONSTRUCTOR
        public CategoriasDAO(ICategoriasFactory Factory, ConveridorColecciones<Notas> Converter)
        {
            this.Factory = Factory;
            this.Converter = Converter;
        }

        

        public int Crear(ICategorias Modelo)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            Categorias nuevaCategoria = new Categorias()
            {
                Descripcion = Modelo.Descripcion,
                Estado = true,
                Nombre = Modelo.Nombre,
                Notas =this.Converter.Convertir(Modelo.Notas)

            };

            contexto.Categorias.Add(nuevaCategoria);
            contexto.SaveChanges();

            return nuevaCategoria.Id;
        }

        public int Actualizar(ICategorias Modelo)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            var categoria = contexto.Categorias.Where(x => x.Id == Modelo.Id).FirstOrDefault();
            categoria.Descripcion = Modelo.Descripcion;
            categoria.Nombre = Modelo.Nombre;
            categoria.Notas = this.Converter.Convertir(Modelo.Notas);
            contexto.SaveChanges();
            return Modelo.Id;
        }

        public void Eliminar(int Id)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            var categoria = contexto.Categorias.Where(x => x.Id == Id).FirstOrDefault();
            categoria.Estado = false;
            contexto.SaveChanges();
        }

        public List<ICategorias> Listar(int Max = 10)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            var results = contexto.Categorias.Where(x => x.Estado == true).Take(Max).ToList();
            List<ICategorias> categoriasInt = new List<ICategorias>();

            foreach (var nota in results)
            {
                var nuevaCategoria = Factory.NuevaCategoria();
                nuevaCategoria.Descripcion = nota.Descripcion;
                nuevaCategoria.Estado = nota.Estado;
                nuevaCategoria.Id = nota.Id;
                nuevaCategoria.Nombre = nota.Nombre;
                nuevaCategoria.Notas = this.Converter.Convertir(nota.Notas.ToList()).Cast<INotas>().ToList();

               categoriasInt.Add(nuevaCategoria);
            }

            return categoriasInt;
        }

       
    }
}
