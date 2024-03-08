using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetaPAL.Controllers
{
    public class SampleMetaDataController : Controller
    {
        // GET: SampleMetaDataController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SampleMetaDataController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SampleMetaDataController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SampleMetaDataController/Create
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

        // GET: SampleMetaDataController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SampleMetaDataController/Edit/5
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

        // GET: SampleMetaDataController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SampleMetaDataController/Delete/5
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
