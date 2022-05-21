using Ninject.Modules;
using Shop.BLL.Services;
using Shop.DAL.Context;
using Shop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Modules
{
    public class ShopModule : NinjectModule
    {
        public override void Load()
        {
            Bind<CategoryService>().To<CategoryService>();
            Bind<CategoryRepository>().To<CategoryRepository>();

            Bind<GoodService>().To<GoodService>();
            Bind<GoodRepository>().To<GoodRepository>();

            Bind<ManufactureService>().To<ManufactureService>();
            Bind<ManufactureRepository>().To<ManufactureRepository>();

            Bind<DbContext>().To<ShopContext>();
        }
    }
}
