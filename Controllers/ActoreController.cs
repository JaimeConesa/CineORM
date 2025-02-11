using CineORM.Clases;
using CineORM.Models;
using System.Collections.Generic;
using System.Linq;

namespace CineORM.Negocio
{
    public sealed class ActoresController : CineContexto<Actore, CineContext>
    {
        public ActoresController() { }

        // Obtener todos los actores
        public List<Actore> ListadoActores()
        {
            return (from a in Actores select a).ToList();
        }

        // Obtener actores filtrados por nacionalidad
        public List<Actore> ObtenerActoresPorNacionalidad(string nacionalidad)
        {
            return (from a in Actores where a.Nacionalidad == nacionalidad select a).ToList();
        }

        // Agregar un nuevo actor
        public void AgregarActor(Actore actor)
        {
            this.Add(actor);
        }

        // Eliminar un actor por ID
        public void EliminarActor(int idActor)
        {
            var actor = (from a in Actores where a.Id == idActor select a).FirstOrDefault();
            if (actor != null)
            {
                this.Remove(actor);
            }
        }

        // Actualizar datos de un actor
        public void ActualizarActor(int idActor, string nuevoNombre)
        {
            var actor = (from a in Actores where a.Id == idActor select a).FirstOrDefault();
            if (actor != null)
            {
                actor.Nombre = nuevoNombre;
                this.Update(actor);
            }
        }
    }
}
