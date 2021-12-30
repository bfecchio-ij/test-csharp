using Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DbInitializer
{
    public class DbInitializer
    {

        public static void Initialize(CandidatoDbContext context)
        {
            var criado = context.Database.EnsureCreated();

            if (criado)
            {
                return;   
            }

            context.Database.EnsureCreated();

        }
    }
}
