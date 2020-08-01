using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GadgetsAndGizmos.DataAccessLayer.Repository.IRepository;
using GadgetsAndGizmos.Models;
using GadgetsAndGizmos.Utilities;
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
                // Continue Work Here
                var parameter = new Dapper.DynamicParameters();
                parameter.Add("@Id", id);

                var objFromDb = _unitOfWork.SP_Call.OneRecord<Category>(StaticDetails.Proc_Category_Get, parameter);
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
            var allObj = _unitOfWork.SP_Call.ListOneTable<Category>(StaticDetails.Proc_Category_GetAll, null);

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
                var parameter = new Dapper.DynamicParameters();
                parameter.Add("@Name", category.Name);

                if (category.ParentId != null)
                    parameter.Add("@ParentId", category.ParentId);
                else
                    parameter.Add("@ParentId", null);

                // Create new category
                if (category.Id == 0)
                {
                    _unitOfWork.SP_Call.Execute(StaticDetails.Proc_Category_Create, parameter);
                }
                else
                {
                    parameter.Add("@Id", category.Id);
                    _unitOfWork.SP_Call.Execute(StaticDetails.Proc_Category_Update, parameter);;
                }
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var parameter = new Dapper.DynamicParameters();
            parameter.Add("@Id", id);

            var objFromDb = _unitOfWork.SP_Call.OneRecord<Category>(StaticDetails.Proc_Category_Get, parameter);

            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" }) ;
            }

            _unitOfWork.SP_Call.Execute(StaticDetails.Proc_Category_Delete, parameter);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Category was deleted successfully" });
        }


        #endregion
    }
}