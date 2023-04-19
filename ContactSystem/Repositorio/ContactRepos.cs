using ContactSystem.Data;
using ContactSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactSystem.Repositorio
{
    public class ContactRepos : IContactRepos 
    {
        private readonly BancoContext _bancoContext; 
        public ContactRepos(BancoContext bancoContext) //Nao pode ser acessado através dos métodos, entao criei a var private
        {
            _bancoContext = bancoContext; //Atribuindo 
        }

        public List<ContactModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContactModel Add(ContactModel contato)
        {
            //Gravar no banco de dados 
            //Inserindo no banco
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges(); //Commitando
            return contato;
        }

        public bool Deletar(ContactModel contato)
        {
            //Gravar no banco de dados 
            //Inserindo no banco
            _bancoContext.Contatos.Remove(contato);
            _bancoContext.SaveChanges(); //Commitando
            return true;
        }

        public ContactModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContactModel Atualizar(ContactModel contato)
        {
            ContactModel contatoDB = ListarPorId(contato.Id);
            if (contatoDB == null) throw new System.Exception("Houve erro na atualização do Contato");
            contatoDB.Name = contato.Name;
            contatoDB.Email = contato.Email;
            contatoDB.Cell = contato.Cell;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContactModel contatoDB = ListarPorId(id);
            if (contatoDB == null) throw new System.Exception("Houve erro na deleçao do Contato");
         
            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
