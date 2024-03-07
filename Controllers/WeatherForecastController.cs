using Microsoft.AspNetCore.Mvc;

namespace numapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly string filePath = "mensajes.txt"; // Ruta del archivo de texto donde se guardarán los mensajes

        [HttpPost]
        public async Task<IActionResult> GuardarMensaje([FromBody] Mensaje mensaje)
        {
            try
            {
                // Construye el mensaje a escribir en el archivo
                string mensajeGuardado = $"From: {mensaje.From}\nTo: {mensaje.To}\nText: {mensaje.Text}\nMediaUrls: {string.Join(",", mensaje.MediaUrls)}\n";

                // Escribe el mensaje en el archivo de texto
                await System.IO.File.AppendAllTextAsync(filePath, mensajeGuardado);

                return Ok("Mensaje guardado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar el mensaje: {ex.Message}");
            }
        }

        public class Mensaje
        {
            public string From { get; set; }
            public string To { get; set; }
            public string Text { get; set; }
            public string[] MediaUrls { get; set; }
        }
    }
}
