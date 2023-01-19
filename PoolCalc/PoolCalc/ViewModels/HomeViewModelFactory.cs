using PoolCalc.ViewModels;
using PoolCalc.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolCalc.ViewModels
{
    public class HomeViewModelFactory : IHomeViewModelFactory
    {

        public HomeViewModelFactory()
        {
        }


        public HomeViewModel Create()
        {
            var model = new HomeViewModel();
            return model;
        }
    }
}
