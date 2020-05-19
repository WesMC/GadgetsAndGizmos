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
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Category category = new Category();

            // If ID not null, get the category
            if(id != null)
            {
                category = _unitOfWork.Category.Get(id.GetValueOrDefault());

                if (category == null)
                {
                    return NotFound();
                }
            }

            return View(category);
        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Category.GetAll();

            if (allObj != null)
            {
                return Json(new { data = allObj });
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if(ModelState.IsValid)
            {
                // Create new category
                if (category.Id == 0)
                {
                    _unitOfWork.Category.Add(category);
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Category.Get(id);

            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" }) ;
            }

            _unitOfWork.Category.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Category was deleted successfully" });
        }


        #endregion
    }
}