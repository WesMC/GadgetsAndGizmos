using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GadgetsAndGizmos.DataAccessLayer.Repository.IRepository;
using GadgetsAndGizmos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GadgetsAndGizmos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            ProductType productType = new ProductType();

            // If ID not null, get the category
            if (id != null)
            {
                productType = _unitOfWork.ProductType.Get(id.GetValueOrDefault());

                if (productType == null)
                {
                    return NotFound();
                }
            }

            return View(productType);
        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.ProductType.GetAll();

            if (allObj != null)
            {
                return Json(new { data = allObj });
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                // Create new category
                if (productType.Id == 0)
                {
                    _unitOfWork.ProductType.Add(productType);
                }
                else
                {
                    _unitOfWork.ProductType.Update(productType);
                }
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(productType);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.ProductType.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.ProductType.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "ProductType was deleted successfully" });
        }


        #endregion
    }
}