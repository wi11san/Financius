using Financius.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Financius.Pages;

public class LoginModel : PageModel
{
    [BindProperty]
    public UsuarioModel Usuario { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Aqui você deve adicionar a lógica para autenticar o usuário.
        // Exemplo simplificado:
        if (Usuario.Email == "teste@email.com" && Usuario.Senha == "teste123")
        {
            // Redirecionar para a página inicial após o login bem-sucedido.
            return RedirectToPage("/Index");
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return Page();

    }
}
