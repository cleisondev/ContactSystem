using ContactSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactSystem.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) //Padrao de construtor
        {
        }

        //Criação da tabela no banco
        //Informar qual classe deriva os dados
        public DbSet<ContactModel> Contatos { get; set; }


    }
}
