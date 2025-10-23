using System.Text;
using System.Text.Json;
using TiendaWeb.Models;

namespace TiendaWeb.Services
{
    public class ProductoService
    {
        private readonly HttpClient _http;

        public ProductoService(HttpClient http)
        {
            _http = http;
            // 🔗 Asegúrate que este puerto sea el de tu API TiendaAPI (ajústalo si cambia)
            _http.BaseAddress = new Uri("https://localhost:44314/api/");
        }

        // ✅ Obtener todos los productos
        public async Task<List<Producto>> GetAllAsync()
        {
            var resp = await _http.GetAsync("productos");
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Producto>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        // ✅ Obtener un producto por ID
        public async Task<Producto?> GetByIdAsync(int id)
        {
            var resp = await _http.GetAsync($"productos/{id}");
            if (!resp.IsSuccessStatusCode) return null;
            var json = await resp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Producto>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // ✅ Crear un nuevo producto
        public async Task CreateAsync(Producto p)
        {
            var json = JsonSerializer.Serialize(p);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resp = await _http.PostAsync("productos", content);
            resp.EnsureSuccessStatusCode();
        }

        // 🟡 Actualizar un producto existente
        public async Task UpdateAsync(Producto p)
        {
            var json = JsonSerializer.Serialize(p);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resp = await _http.PutAsync($"productos/{p.Id}", content);
            resp.EnsureSuccessStatusCode();
        }

        // 🔴 Eliminar un producto
        public async Task DeleteAsync(int id)
        {
            var resp = await _http.DeleteAsync($"productos/{id}");
            resp.EnsureSuccessStatusCode();
        }
    }
}
