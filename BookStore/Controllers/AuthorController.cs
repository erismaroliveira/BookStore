using BookStore.Filters;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [RoutePrefix("autores")]
    [LogActionFilter()]
    public class AuthorController : Controller
    {
        [Route("listar")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("criar")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Route("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}