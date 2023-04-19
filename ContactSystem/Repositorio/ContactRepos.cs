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

    }
}
