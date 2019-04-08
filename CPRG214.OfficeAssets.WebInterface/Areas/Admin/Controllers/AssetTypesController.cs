using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.OfficeAssets.WebInterface.Data;
using CPRG214.OfficeAssets.WebInterface.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPRG214.OfficeAssets.WebInterface.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AssetTypesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AssetTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.AssetTypes.ToList());
        }

        //GET Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        //POST Create action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssetType assetTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Add(assetTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetTypes);
        }

        //GET Edit Action Method
        public async Task<IActionResult> Edit(int? id)
        {
            if(id ==null)
            {
                return NotFound();
            }

            var assetType = await _db.AssetTypes.FindAsync(id);
            if (assetType == null)
            {
                return NotFound();
            }

            return View(assetType);
        }

        //POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AssetType assetTypes)
        {
            if(id!=assetTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(assetTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetTypes);
        }

        //GET Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetType = await _db.AssetTypes.FindAsync(id);
            if (assetType == null)
            {
                return NotFound();
            }

            return View(assetType);
        }

        //GET Delete Action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetType = await _db.AssetTypes.FindAsync(id);
            if (assetType == null)
            {
                return NotFound();
            }

            return View(assetType);
        }

        //POST Delet action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTypes = await _db.AssetTypes.FindAsync(id);
            _db.AssetTypes.Remove(productTypes);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            
        }

    }
}