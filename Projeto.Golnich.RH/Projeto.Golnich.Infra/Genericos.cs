using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Golnich.Infra
{
    public class Genericos
    {
        private IConfiguration _configuration;
        public Genericos(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Conexao BuscaConexao()
        {
            return new Conexao(new DbContextOptionsBuilder<Conexao>().UseSqlServer(_configuration.GetConnectionString("StringDeConexao")).Options);
        }
    }
}
