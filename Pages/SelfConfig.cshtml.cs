using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Projekt_IOP.Pages;

public class SelfConfigModel : PageModel
{
    private readonly ILogger<SelfConfigModel> _logger;

    public SelfConfigModel(ILogger<SelfConfigModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

