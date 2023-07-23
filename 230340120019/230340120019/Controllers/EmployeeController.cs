using _230340120019.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _230340120019.Controllers
{
    public class EmployeeController : Controller
    {

        DBConnection db=new DBConnection();
        // GET: EmployeeController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Added()
        {
            return View();
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details()
        {
            List<Employee> emp = db.ShowAllEmp();
            return View(emp);
        }


        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                db.InsertEmployee(emp);
                return RedirectToAction(nameof(Added));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee emp=db.GetEmployee(id);
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                db.UpdateEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee emp = db.GetEmployee(id);
            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee collection)
        {
            try
            {
                db.DeleteEmp(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
