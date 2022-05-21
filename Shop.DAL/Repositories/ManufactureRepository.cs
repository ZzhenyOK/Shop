using Shop.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Repositories
{
    public class ManufactureRepository : GenericRepository<Manufacture>
    {
        public ManufactureRepository(DbContext context) : base(context)
        {
        }
    }
}
