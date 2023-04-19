using ContactSystem.Models;
using ContactSystem.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactSystem.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepos _contactRepos;

        public ContactController(IContactRepos contactRepos)
        {
            _contactRepos = contactRepos;
        }

   
        public IActionResult Index()
        {
            List<ContactModel> contatos = _contactRepos.BuscarTodos();

            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult Create(ContactModel contact) //Passar pro post a model que eu quero 
        {
            _contactRepos.Add(contact);
            return RedirectToAction("Index");
        }

        public IActionResult Deletar(ContactModel contact) //Passar pro post a model que eu quero 
        {
            _contactRepos.Add(contact);
            return RedirectToAction("Index");
        }
    }
}
