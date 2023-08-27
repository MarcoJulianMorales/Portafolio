using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<ProyectoDTO> obtenerProyectos();
    }
    public class RepositorioProyectos: IRepositorioProyectos
    {
        public  List<ProyectoDTO> obtenerProyectos()
        {
            return new List<ProyectoDTO> {
                new ProyectoDTO { title = "Exela", description = "software developer", imageUrl = "/exela.jpg", link = "https://www.exelatech.com/" },
                new ProyectoDTO { title = "Exela", description = "configuration analyst", imageUrl = "/exela.jpg", link = "https://www.exelatech.com/" },
                new ProyectoDTO { title = "Cantera", description = "software developer", imageUrl = "/cantera.png", link = "https://canteradigital.io/" },
                new ProyectoDTO { title = "Google", description = "software developer", imageUrl = "/google.png", link = "https://www.google.com/?hl=es" },
            };
        }
    }
}
