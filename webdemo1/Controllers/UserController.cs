using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System;
using webdemo1.Models;
using webdemo1;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace webdemo1.Controllers
{
    public class UserController : Controller
    {

        DatabaseOperations op=new DatabaseOperations();
        public IActionResult Index()
        {
            List<CreateUser> users = op.GetUsers();
            return View(users);
        }

        public IActionResult DeleteUser(string id)
        {
            op.DeleteUser(id);
            return RedirectToAction("Index");
        }

        //public IActionResult EditUser(string id)
        //{
        //    op.UpdateUser(id,);
        //}

        public IActionResult UserDetails(string id)
        {
            CreateUser user=op.GetSingleUser(id);
            return View(user);
        }
        

        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Login(UserData logindata)
        {
            if(logindata != null)
            {
               
                if (op.ValidatedUser(logindata)) {
                    return RedirectToAction("Index");
                }
                
            }
            
            return View("InvalidUser");
        }

        public IActionResult RegisterUser()
        {
            return View();
        }


        [HttpPost]
        public IActionResult RegisterUser(CreateUser userData)
        {
            op.InsertUser(userData);
            return View("Login");
        }

        public IActionResult InvalidUser()
        {
            return View();
        }


        //public CreateUser GetSingleUser(string userName)
        //{
        //    SqlConnection cn
        //}

        //public List<CreateUser> GetUser(string userName)
        //{

        //}
    }
}
