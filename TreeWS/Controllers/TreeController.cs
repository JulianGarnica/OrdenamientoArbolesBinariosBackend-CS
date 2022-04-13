using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc;

namespace TreeWS;

[ApiController]
[Route("[controller]")]
public class TreeController : Controller
{
    // GET
    [HttpPost(Name = "PostTree")]
    public ActionResult<TreeModel> CreateTodoItem(TreeModel tree)
    {
        var nuevoArbol = new Tree(tree.ListaDesordenada);
        return tree;
    }
}
