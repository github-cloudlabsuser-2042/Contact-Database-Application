using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            // Retrieve the list of users from the userlist
            var users = userlist.ToList();

            // Pass the list of users to the Index view
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Find the user with the specified ID in the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Pass the user to the Details view
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            // Return the Create view
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Add the new user to the userlist
            userlist.Add(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Find the user with the specified ID in the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Pass the user to the Edit view
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // Find the user with the specified ID in the userlist
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return HttpNotFoundResult
            if (existingUser == null)
            {
                return HttpNotFound();
            }

            // Update the user's information with the new values
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Find the user with the specified ID in the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Pass the user to the Delete view
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Find the user with the specified ID in the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Remove the user from the userlist
            userlist.Remove(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
        // POST: User/Search
        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            // Search for users whose name or email contains the search term
            var searchResults = userlist.Where(u => u.Name.Contains(searchTerm) || u.Email.Contains(searchTerm)).ToList();

            // Pass the search results to the Search view
            var model = new SearchModel
            {
                Results = searchResults,
                SearchTerm = searchTerm
            };
            return View(model);
        }

        // GET: User/Search
        public ActionResult Search()
        {
            // Return the Search view
            var model = new SearchModel { };
            return View(model);
        }
    }
}
