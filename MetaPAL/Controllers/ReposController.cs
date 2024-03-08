using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetaPAL.Controllers
{
    public class ReposController : Controller
    {
        // GET: ReposController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReposController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReposController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReposController/Create
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

        // GET: ReposController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReposController/Edit/5
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

        // GET: ReposController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReposController/Delete/5
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
