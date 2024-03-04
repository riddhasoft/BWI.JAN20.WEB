using BWI.JAN20.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironmentMvc = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BWI.JAN20.WEB.Controllers
{
    public class SignupController : Controller
    {
        readonly BWIJAN20WEBContext _dbContext;
        private readonly IHostingEnvironmentMvc _hostingEnvironment;

        public SignupController(BWIJAN20WEBContext dbcontext, IHostingEnvironmentMvc hostingEnvironment)
        {
            _dbContext = dbcontext;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var users = _dbContext.User.ToList();
            return View(users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SignupModel model, IFormFile ImageFile)
        {
            //directory
            //filename
            //save
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            string filePath = Path.Combine(uploads, ImageFile.FileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                ImageFile.CopyTo(fileStream);
                model.ImageUrl = "/uploads/" + ImageFile.FileName;
            }

            if (ModelState.IsValid)
            {
                _dbContext.User.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
