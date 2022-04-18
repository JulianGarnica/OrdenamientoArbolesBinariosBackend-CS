using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc;

namespace TreeWS;

[ApiController]
[Route("[controller]")]
public class TreeController : Controller
{
    // POST
    [HttpPost(Name = "PostTree")]
    public ActionResult<string> CreateTodoItem(TreeModel tree)
    {
        Tree nuevoArbol = new Tree(tree.ListaDesordenada);
        return nuevoArbol.devolverArbol();
    }
}
