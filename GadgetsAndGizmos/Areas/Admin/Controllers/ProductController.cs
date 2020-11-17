using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GadgetsAndGizmos.DataAccessLayer.Repository.IRepository;
using GadgetsAndGizmos.Models;
using GadgetsAndGizmos.Models.ViewModels;
using GadgetsAndGizmos.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GadgetsAndGizmos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            // If ID not null, get product
            if (id != null)
            {
                productVM.Product = _unitOfWork.Product.Get(id.GetValueOrDefault());

                if (productVM.Product == null)
                {
                    return NotFound();
                }
            }

            return View(productVM);
        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Product.GetAll(includeProperties:"Category");

            if (allObj != null)
            {
                return Json(new { data = allObj });
            }

            return NotFound();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upsert(ProductVM productVM)
        //{
        //    if(ModelState.IsValid)
        //    { 
        //        _unitOfWork.Save();

        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(productVM);
        //}

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Product.Get(id);

            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" }) ;
            }

            _unitOfWork.Product.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Product was deleted successfully" });
        }


        #endregion
    }
}