//using GameStore.Domain.Abstract;
//using GameStore.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GameStore.Domain.Concrete
//{
//    public class EFCompanyRepository : ICompanyRepository
//    {
//        EFDbContext db = new EFDbContext();
//        public void Create(Company company)
//        {
//            db.Companies.Add(company);
//            db.SaveChanges();
//        }

//        public void Delete(int id)
//        {
//            var company = db.Companies.Where(x => x.Id == id).FirstOrDefault();
//            db.Companies.Remove(company);
//            db.SaveChanges();
//        }

//        //public Page<Company> Get(int page, int pageSize)
//        //{
//        //    double count = db.Companies.Count();
//        //    var pages = count % pageSize;
//        //    if (pages == 0)
//        //    {
//        //        pages = count / pageSize;
//        //    }
//        //    else
//        //    {
//        //        pages = (int)(count / pageSize) + 1;
//        //    }
//        //    return new Page<Company>
//        //    {
//        //        Items = db.Companies.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
//        //        countPages = (int)pages
//        //    };
//        //}

//        public void Update(Company company)
//        {
//            var company1 = db.Companies.Where(x => x.Id == company.Id).FirstOrDefault();
//            company1.Name = company.Name;
//            company1.Address = company.Address;
//            db.SaveChanges();
//        }
//    }
//}
