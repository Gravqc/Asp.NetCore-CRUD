using Book_CRUD.Data;
using Book_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_CRUD.Controllers
{
    /*
 * The CategoryController class handles HTTP requests related to the 'Category' entity.
 * It interacts with the database context to perform CRUD operations on 'Category' data.
 */
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        // Constructor initializes the controller with the database context.
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        // Returns the list of categories to be displayed on the Index view.
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        // GET: Renders the Create view for creating a new category.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Processes the submission of the Create form, adding a new category.

        [HttpPost]
        [ValidateAntiForgeryToken] //Forgery validation (not necessary but good to have)
        public IActionResult Create(Category obj)
        {
            // Custom server-side validation: Checks if 'Name' and 'DisplayOrder' are equal.
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and DisplayOrder cannot be equal");
            }
            // Checks if the model is valid and then adds the new category to the database.
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully!!! ";
                return RedirectToAction("Index");
            }
            // If the model is invalid, reloads the Create view with the current data to show errors.
            return View(obj);
        }

        // GET: Renders the Create view for creating a new category.
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);

            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        // POST: Processes the submission of the Create form, adding a new category.

        [HttpPost]
        [ValidateAntiForgeryToken] //Forgery validation (not necessary but good to have)
        public IActionResult Edit(Category obj)
        {
            // Custom server-side validation: Checks if 'Name' and 'DisplayOrder' are equal.
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and DisplayOrder cannot be equal");
            }
            // Checks if the model is valid and then adds the new category to the database.
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully!!! ";
                return RedirectToAction("Index");
            }
            // If the model is invalid, reloads the Create view with the current data to show errors.
            return View(obj);
        }

        //Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        // POST: Processes the submission of the Create form, adding a new category.

        [HttpPost]
        [ValidateAntiForgeryToken] //Forgery validation (not necessary but good to have)
        public IActionResult Delete(Category obj)
        {
            /*No need for model validation as this is an existing object
            // Custom server-side validation: Checks if 'Name' and 'DisplayOrder' are equal.
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and DisplayOrder cannot be equal");
            }
            */
            // Checks if the model is valid and then adds the new category to the database.
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully!!! ";
                return RedirectToAction("Index");
            }
            // If the model is invalid, reloads the Create view with the current data to show errors.
            return View(obj);
        }
    }
}
