using Ninject;
using Shop.BLL.Modules;
using Shop.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UI.Infrastructure
{
    public class ViewModelLocator
    {
        private IKernel container;
        public ViewModelLocator()
        {
            container = new StandardKernel(new ShopModule());
        }

        public MainViewModel MainViewModel => container.Get<MainViewModel>();
    }
}
