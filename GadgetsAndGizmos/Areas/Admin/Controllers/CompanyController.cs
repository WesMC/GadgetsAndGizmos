using GadgetsAndGizmos.DataAccessLayer.Repository.IRepository;
using GadgetsAndGizmos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetsAndGizmos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Company company = new Company();

            if (id != null)
            {
                company = _unitOfWork.Company.Get(id.GetValueOrDefault());

                if(company == null)
                {
                    return NotFound();
                }
            }

            return View(company);
        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = _unitOfWork.Company.GetAll();

            if (companies != null)
            {
                return Json(new { data = companies });
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                // Create new company
                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                }

                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(company);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Company company = _unitOfWork.Company.Get(id);

            if (company == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Company.Remove(company);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Company was deleted successfully" });
        }

        #endregion
    }
}
