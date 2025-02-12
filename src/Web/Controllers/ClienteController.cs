using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

public class ClienteController : Controller
{
    private readonly HttpClient _httpClient;

    public ClienteController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("API");
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("");
        if (!response.IsSuccessStatusCode) return View(new List<ClienteViewModel>());

        var json = await response.Content.ReadAsStringAsync();
        var clientes = JsonConvert.DeserializeObject<List<ClienteViewModel>>(json);

        return View(clientes);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] ClienteViewModel cliente)
    {
        if (string.IsNullOrEmpty(cliente.Nome) || string.IsNullOrEmpty(cliente.Email))
        {
            ModelState.AddModelError(string.Empty, "Nome e Email são obrigatórios.");
            return View(cliente);
        }

        var content = new MultipartFormDataContent();

        content.Add(new StringContent(cliente.Nome), "Nome");
        content.Add(new StringContent(cliente.Email), "Email");

        if (cliente.Logotipo != null)
        {
            using var fileStream = cliente.Logotipo.OpenReadStream();
            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(cliente.Logotipo.ContentType);
            content.Add(fileContent, "Logotipo", cliente.Logotipo.FileName);
        }

        var response = await _httpClient.PostAsync("clientes", content);

        if (response.IsSuccessStatusCode)
            return RedirectToAction("Index");

        ModelState.AddModelError(string.Empty, "Erro ao cadastrar cliente.");
        return View(cliente);
    }

    // Outros métodos...
}
