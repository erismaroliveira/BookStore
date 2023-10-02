using BookStore.Context;
using BookStore.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [RoutePrefix("livros")]
    public class LivroController : Controller
    {
        private readonly BookStoreDataContext _db = new BookStoreDataContext();

        [Route("criar")]
        public ActionResult Create()
        {
            var categorias = _db.Categorias.AsNoTracking().ToList();
            var model = new CreateBookViewModel
            {
                Nome = "",
                ISBN = "",
                CategoriaId = 0,
                CategoriaOptions = new SelectList(categorias, "Id", "Nome"),
            };

            return View(model);
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult Create(CreateBookViewModel model)
        {
            return View();
        }
    }
}