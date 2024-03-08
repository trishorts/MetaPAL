using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetaPAL.Controllers
{
    public class ExperimentsController : Controller
    {
        // GET: Experiments
        public ActionResult Index()
        {
            return View();
        }

        // GET: Experiments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Experiments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Experiments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Experiments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Experiments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Experiments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Experiments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
