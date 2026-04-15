using System.Text.Json;
using ApiCafeteria.Models;

namespace ApiCafeteria.Services
{
    public class BebidaService
    {
        private readonly IWebHostEnvironment _env;

        public BebidaService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public List<Bebida> ObtenerBebidas()
        {
            string rutaArchivo = Path.Combine(_env.ContentRootPath, "Data", "bebidas.json");

            if (!File.Exists(rutaArchivo))
            {
                return new List<Bebida>();
            }

            string json = File.ReadAllText(rutaArchivo);

            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<Bebida>>(json, opciones) ?? new List<Bebida>();
        }

        public Bebida? ObtenerBebidaPorId(int id)
        {
            return ObtenerBebidas().FirstOrDefault(b => b.Id == id);
        }
    }
}