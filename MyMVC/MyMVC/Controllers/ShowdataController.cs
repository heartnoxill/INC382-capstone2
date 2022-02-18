using Microsoft.AspNetCore.Mvc;
using MyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MyMVC.Controllers
{
    public class ShowdataController : Controller
    {
        private MyIdeaContext db;
        public ShowdataController(MyIdeaContext ctx)
        {
            db = ctx;
        }
        public async Task<IActionResult> Index()
        {
            var ps = await (from p in db.MyTables
                            orderby p.Id
                            select p).ToListAsync();
            return View(ps);
        }
    }
}
