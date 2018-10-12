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
        private IFactoryDatos<ICategorias> Factory;
        

        //CONSTRUCTOR
        public CategoriasDAO(IFactoryDatos<ICategorias> Factory)
        {
            this.Factory = Factory;
            
        }

        public int Crear(ICategorias Modelo)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            Categorias nuevaCategoria = new Categorias()
            {
                Descripcion = Modelo.Descripcion,
                Estado = true,
                Nombre = Modelo.Nombre,               
                

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
                var nuevaCategoria = Factory.NuevaInstancia();
                nuevaCategoria.Descripcion = nota.Descripcion;
                nuevaCategoria.Estado = nota.Estado;
                nuevaCategoria.Id = nota.Id;
                nuevaCategoria.Nombre = nota.Nombre;
                

               categoriasInt.Add(nuevaCategoria);
            }

            return categoriasInt;
        }

       
    }
}
