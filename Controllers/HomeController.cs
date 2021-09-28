using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApp.Models;
using System.Data;


namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        static IList<Student> studentList = new List<Student>{
                new Student() { student_id = 1, Name = "John", batch = 18 } ,
                new Student() { student_id = 2, Name = "Steve",  batch = 21 } ,
                new Student() { student_id = 3, Name = "Bill",  batch = 25 } ,
                new Student() { student_id = 4, Name = "Ram" , batch = 20 } ,
                new Student() { student_id = 5, Name = "Ron" , batch = 31 } ,
                new Student() { student_id = 4, Name = "Chris" , batch = 17 } ,
                new Student() { student_id = 4, Name = "Rob" , batch = 19 }
            };

        public ActionResult Todo()
        {
            return View(studentList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(String Id)
        {
           
                int IDD = int.Parse(Id);
                var findTodo = studentList.Where(s=>s.student_id == IDD).FirstOrDefault( );
                studentList.Remove(findTodo);
                return RedirectToAction(nameof(Todo));
            
            
            
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var findTodo = studentList.Where(s => s.student_id == Id).FirstOrDefault();
            return View(findTodo);



        }


        public ActionResult Edit(int Id)
        {
            var std  = studentList.Where(s => s.student_id == Id).FirstOrDefault();
            return View(std);
        }
        [HttpPost]
        public ActionResult Edit(Student Std )
        {
            var del_std = studentList.Where(s=> s.student_id == Std.student_id).FirstOrDefault();
            studentList.Remove(del_std);
            studentList.Add(Std);
            return RedirectToAction("Todo");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student Std)
        {
          
            studentList.Add(Std);
            return RedirectToAction("Todo");
        }

    }
}