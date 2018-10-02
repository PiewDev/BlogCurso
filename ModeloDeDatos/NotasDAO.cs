using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDatos
{
    public interface INotas
    {
        int Id { get; set; }
        string Titulo { get; set; }
        string Cuerpo { get; set; }
        string Autor { get; set; }
        DateTime FechaCreacion { get; set; }
        DateTime? FechaModificacion { get; set; }
        DateTime FechaBaja { get; set; }
        bool Estado { get; set; }
        List<Tags> Tags { get; set; }

    }

    public class NotasDAO<TNota> : ICrud<TNota> where TNota: class, INotas, new()
    {
        public int Crear(TNota Modelo)
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
                Tags = Modelo.Tags,
                Titulo = Modelo.Titulo  
            };
                       
            contexto.Notas.Add(nuevaNota);
            contexto.SaveChanges();

            return nuevaNota.id;
        }

        public int Actualizar(TNota Modelo)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            var nota = contexto.Notas.Where(x => x.id == Modelo.Id).FirstOrDefault();
            nota.Cuerpo = Modelo.Cuerpo;
            nota.FechaModificacion = DateTime.Now;
            nota.Tags = Modelo.Tags;
            nota.Titulo = Modelo.Titulo;

            contexto.SaveChanges();
            return Modelo.Id;
        }

        public void Eliminar(int Id)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            var nota = contexto.Notas.Where(x => x.id == Id).FirstOrDefault();
            nota.FechaBaja = DateTime.Now;
            nota.Estado = false;
            contexto.SaveChanges();
        }

        public List<TNota> Listar(int Max = 10)
        {
            blogkinexoEntities contexto = new blogkinexoEntities();
            var results = contexto.Notas.Where(x => x.Estado == true).Take(Max);
            List<TNota> notasInt = new List<TNota>();

            foreach (var nota in results)
            {
                var nuevaNota = new TNota();
                nuevaNota.Autor = nota.Autor;
                nuevaNota.Cuerpo = nota.Cuerpo;
                nuevaNota.FechaCreacion = nota.FechaCreacion;
                nuevaNota.FechaModificacion = nota.FechaModificacion;
                nuevaNota.Tags = nota.Tags.ToList();
                nuevaNota.Titulo = nota.Titulo;
                nuevaNota.Id = nota.id;

                notasInt.Add(nuevaNota);
            }

            return notasInt;
        }
    }
}
