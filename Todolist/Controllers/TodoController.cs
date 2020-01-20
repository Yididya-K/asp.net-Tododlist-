using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Todolist.Models;

namespace Todolist.Controllers
{
    public class TodoController : Controller
    {
        private TodoDBEntities _db = new TodoDBEntities();

        // GET: Todo
        public ActionResult Index()
        {
            return View(_db.Todos.ToList());
        }

        // GET: Todo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Todo todoToCreate)
        {
            if (!ModelState.IsValid)
                return View();
            _db.Todos.Add(todoToCreate);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(int id)
        {
            var todoToEdit = (from t in _db.Todos
                              where t.Id == id
                              select t).First();
            return View(todoToEdit);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Edit(Todo todoToEdit) { 
            var originalTodo = (from t in _db.Todos
                                where t.Id == todoToEdit.Id
                                select t).First();
            if (!ModelState.IsValid)
                return View(originalTodo);

            _db.Entry(originalTodo).CurrentValues.SetValues(todoToEdit);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Todo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
