using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StateManagement.Models;

namespace StateManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public HomeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cookie()
        {
            CookieModel model = new CookieModel
            {
                Adi = "Ahmet",
                Degeri = "Ayşe"
            };

            if(HttpContext.Request.Cookies.Keys.Contains("Ahmet") == false)
            {
                var options = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(10)
                };

                HttpContext.Response.Cookies.Append("Ahmet", "Ayşe", options);
            }
            else
            {
                string deger = HttpContext.Request.Cookies["Ahmet"];
            }

            return View(model);
        }

        public IActionResult QueryString(string id)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("Ahmet")) == false)
            {
                var data = HttpContext.Session.GetString("Ahmet");
            }

            QueryStringModel model = new QueryStringModel { Degeri = id };
            return View(model);
        }

        [HttpGet]
        public IActionResult HiddenField()
        {
            HiddenFieldModel model = new HiddenFieldModel
            {
                Id = 123142,
                Adi = "Ahmet",
                Yasi = 270
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult HiddenField(HiddenFieldModel model)
        {
            return View();
        }

        public IActionResult Session()
        {
            if(string.IsNullOrWhiteSpace(HttpContext.Session.GetString("Ahmet")))
            {
                HttpContext.Session.SetString("Ahmet", "The Doctor");
            }
            else
            {
                var data = HttpContext.Session.GetString("Ahmet");
            }

            return View();
        }

        public IActionResult Cache()
        {
            if (!_memoryCache.TryGetValue("Kategoriler", out List<CacheModel> list))
            {
                list = CacheModel.Listele();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30));

                _memoryCache.Set("Kategoriler", list, cacheEntryOptions);
            }

            return View(list);
        }
    }
}