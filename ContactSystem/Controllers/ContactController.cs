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

        public IActionResult Edit(int id)
        {
            ContactModel contato =  _contactRepos.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Delete(int id)
        {
            ContactModel contato = _contactRepos.ListarPorId(id);
            return View(contato);;
        }

        public IActionResult Apagar(int id) //Passar pro post a model que eu quero 
        {
            _contactRepos.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public  IActionResult Create(ContactModel contact) //Passar pro post a model que eu quero 
        {
            _contactRepos.Add(contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(ContactModel contact) //Passar pro post a model que eu quero 
        {
            _contactRepos.Atualizar(contact);
            return RedirectToAction("Index");
        }



    }
}
