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
            try
            {
                bool apagado = _contactRepos.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemErro"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops,  não conseguimos apagar seu contato.";
                }

                return RedirectToAction("Index");
            }
            catch(System.Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamente, detalhe do erro:{e.Message} .";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public  IActionResult Create(ContactModel contact) //Passar pro post a model que eu quero 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepos.Add(contact);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contact);

            }
            catch(System.Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro:{e.Message} .";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContactModel contact) //Passar pro post a model que eu quero 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepos.Atualizar(contact);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Edit", contact);

            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar seu contato, tente novamente, detalhe do erro:{e.Message} .";
                return RedirectToAction("Index");
            }
        }

    }
}
