using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Homework.Models;
using Homework.JsonSerial;
using Homework.Models.ViewModels;

namespace Homework.Controllers
{
    public class MainController : Controller
    {
        //[get]Get All Users
        [HttpGet]
        public ActionResult Users()
        {
            List<User>? users = Serializer.ReadUser(); 
            return View(users);
        }

        //[post]Create new user
        [HttpPost]
        public string CreateUser(string name, string surname, DateTime birthDate)
        {
            List<User>? users = Serializer.ReadUser();
            users.Add(new User() {Id = users.Count + 1, Name = name, Surname = surname, BirthDate = birthDate});
            Serializer.WriteUser(users);
            return $"User {name} was created!";
        }

        //[get]Create new user
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        //[get]Get all services and types
        [HttpGet]
        public IActionResult Services(int? userId)
        {
            List<UserViewModel> users = Serializer.ReadUser()
                .Select(c => new UserViewModel() { Id = c.Id, Name = c.Name, Surname = c.Surname }).ToList();
            users.Insert(0, new UserViewModel() { Id = 0, Name = "Все пользователи" });
            List<Service> services = Serializer.ReadService();

            ServicesViewModel viewModel = new() { Users = users, Services = Serializer.ReadService() };

            if (userId != null)
                viewModel.Services = services.Where(s => s.CreatorId == userId).ToList();
            return View(viewModel);
        }

        //[post]Create new service
        [HttpPost]
        public string CreateService(string title, string info, int creatorId)
        {
            List<Service>? services = Serializer.ReadService();
            services.Add(new Service() {Id = services.Count + 1, Title = title, CreatedDate = DateTime.Now, Info = info, CreatorId = creatorId});
            Serializer.WriteService(services);
            return $"Service {title} was created!";
        }

        //[get]Create new user
        [HttpGet]
        public ActionResult CreateService()
        {
            List<UserViewModel> users = Serializer.ReadUser()
                .Select(c => new UserViewModel() { Id = c.Id, Name = c.Name, Surname = c.Surname }).ToList();
            
            return View(users);
        }

        //[get]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult DeleteUser(int id)
        {
            return View();
        }

        // GET: MainController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MainController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MainController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MainController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
