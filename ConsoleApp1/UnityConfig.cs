using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;
using GameStore.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ConsoleApp1
{
    public static class UnityConfig
    {
        public static UnityContainer container = new UnityContainer();
        public static void Init()
        {
            container.RegisterType<IGameRepository, DapperGameRepository>();
            container.RegisterType<IGameQuaries, EFGameQuaries>();
        }
    }
}
