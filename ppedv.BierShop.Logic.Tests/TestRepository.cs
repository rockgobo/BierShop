using ppedv.BierShop.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ppedv.BierShop.Model;

namespace ppedv.BierShop.Logic.Tests
{
    class TestRepository : IRepository
    {
        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query<T>() where T : Entity
        {
            if(typeof(T) == typeof(Beer))
            {
                var b1 = new Beer() { IsBock = true, Alc = 6 };
                var b2 = new Beer() { IsBock = true, Alc = 2 };
                var b3 = new Beer() { IsBock = false, Alc = 6 };

                return new[] { b1, b2, b3 }.AsQueryable().Cast<T>();
            }

            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
