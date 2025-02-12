using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class ClienteViewModel
{
    [BindProperty]
    public string Nome { get; set; } = string.Empty;

    [BindProperty]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    public IFormFile? Logotipo { get; set; }
}
