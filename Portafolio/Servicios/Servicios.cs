namespace Portafolio.Servicios
{
    public class ServicioSingleton
    {
        public ServicioSingleton()
        {
            obtenerGuid = Guid.NewGuid();
        }

        public Guid obtenerGuid { get; set; }   

    }

    public class ServicioScoped
    {
        public ServicioScoped()
        {
            obtenerGuid = Guid.NewGuid();
        }

        public Guid obtenerGuid { get; set; }

    }

    public class ServicioTransient
    {
        public ServicioTransient()
        {
            obtenerGuid = Guid.NewGuid();
        }

        public Guid obtenerGuid { get; set; }

    }
}
