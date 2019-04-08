using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.OfficeAssets.WebInterface.Data;
using CPRG214.OfficeAssets.WebInterface.Models.ViewModel;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPRG214.OfficeAssets.WebInterface.Controllers
{
    [Area("Admin")]
    public class AssetsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;

        [BindProperty]
        public AssetsViewModel AssetsVM { get; set; }

        public AssetsController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            AssetsVM = new AssetsViewModel()
            {
                AssetTypes = _db.AssetTypes.ToList(),
                Assets = new Models.Assets()
        };

        }

        public async Task<IActionResult> Index()
        {
            var assets = _db.Assets.Include(m => m.AssetTypes);


            return View(await assets.ToListAsync());
        }

        //Get : Assets Create
        public IActionResult Create()
        {
            return View(AssetsVM);
        }

        //Post : Assets Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(AssetsVM);
            }

            
            _db.Assets.Add(AssetsVM.Assets);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}