using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zxcvbn;  
namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class PasswardController : Controller
    {
           
        // GET: PasswardController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PasswardController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PasswardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PasswardController/Create
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

        // GET: PasswardController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PasswardController/Edit/5
        [HttpPost("check_strengh")] 
        public int check_straingh([FromBody] string passward )
        {
            if (passward == null)
                return -1;
            var result = Zxcvbn.Core.EvaluatePassword(passward);
            return result.Score;         
        }

        // GET: PasswardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PasswardController/Delete/5
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
