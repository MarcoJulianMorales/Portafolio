using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Servicios
{
    public interface IServicioEmailSendGrid
    {
        Task enviar(ContactoDTO contacto);
    }
    public class ServicioEmailSendGrid : IServicioEmailSendGrid
    {
        private readonly IConfiguration configuration;

        public ServicioEmailSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task enviar(ContactoDTO contacto)
        {
            var apikey = configuration.GetValue<string>("SEND_GRID_API_KEY");
            var email = configuration.GetValue<string>("SEND_GRID_FROM");
            var nombre = configuration.GetValue<string>("SEND_GRID_NOMBRE");

            var cliente = new SendGridClient(apikey);
            var from = new EmailAddress(email, nombre);
            var to = new EmailAddress(email, nombre);
            var subject = $"El cliente {contacto.email} quiere contactarte";

            var mensajeTextoPlano = contacto.mensaje;
            var contenidoHtml = @$"De: {contacto.nombre} - 
                                   Email: {contacto.email}
                                   Mensaje: {contacto.mensaje}";

            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTextoPlano, contenidoHtml);
            var respuesta = await cliente.SendEmailAsync(singleEmail);
        }
    }
}
