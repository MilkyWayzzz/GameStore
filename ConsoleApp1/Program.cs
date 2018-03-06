using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ConsoleApp1
{
    class Program 
    {
        private static IGameRepository repo;
        private static IGameQuaries quary;
        static void Main()
        {
            UnityConfig.Init();
            repo = UnityConfig.container.Resolve<IGameRepository>();
            quary = UnityConfig.container.Resolve<IGameQuaries>();
            string[] students = { "Vlad", "Sergey", "Marina", "Yana", "Olya", "Bogdan" };


            //var selectName = students.Where(s => s.ToUpper().StartsWith("M"));
            //var selectName = students.Where(s => s == "Vlad").OrderBy(s=>s);
            //var selectName = db.Games.ToList();
            Console.WriteLine("Добавить : +");
            Console.WriteLine("Удалить : -");
            Console.WriteLine("Изменить : *");
            Console.WriteLine("Просмотреть : /");
            string x = Console.ReadLine();


            switch (x)
            {
                case "+":
                    Console.WriteLine("Введите название");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите цену");
                    decimal price = decimal.Parse( Console.ReadLine());
                    Console.WriteLine("Введите ID");
                    var companyId = int.Parse(Console.ReadLine());
                    
                    Game game = new Game() { Name = name, Price = price, CompanyId=companyId };
                    repo.Create(game);
                    Console.WriteLine("Все ОК");
                    break;
                case "-":
                    Console.WriteLine("Введите Id");
                    int id2 = int.Parse(Console.ReadLine());
                    repo.Delete(id2);
                    Console.WriteLine("Удалено");
                    break;
                case "*":
                    Console.WriteLine("Введите название");
                    string name2 = Console.ReadLine();
                    Console.WriteLine("Введите цену");
                    decimal price2 = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Введите Id");
                    int id3 = int.Parse(Console.ReadLine());

                    Game game2 = new Game() { Name = name2, Price = price2, GameId = id3 };
                    repo.Update(game2);
                    Console.WriteLine("Заменено");
                    break;
                case "/":
                    Console.WriteLine("Введите номер страницы:");
                    int page = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите количество записей на странице:");
                    int pageSize = int.Parse(Console.ReadLine());
                    var model = quary.Get(page, pageSize);
                    foreach (var item in model.Games)
                    {
                        Console.WriteLine("Game name : {0}, Game Id : {1}, Game Price: {2}, Game Category : {3}",item.Name,item.GameId,item.Price,item.Category);
                    }
                    Console.WriteLine("Страниц всего: "+model.PagingInfo.TotalPages);
                    break;
                default:
                    Console.WriteLine("Вы не выбрали значение");
                    break;
            }

            //foreach (var item in selectName)
            //{
            //    Console.WriteLine(item.Name);
            //}
            Console.ReadKey();
            Main();
        } 

       
    }
}
