using ApiService.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Repositories {

    public interface ILoadentRepo<T> where T : ILoadentEntity {
        Task<bool> AddAsync<T>(T entity) where T: class;
        bool Delete(T entity);
        bool Update(T entity, Func<T, bool> predicate);
        // https://stackoverflow.com/questions/11143602/possible-ways-to-use-func-t-bool-while-using-a-linq-repository
        //IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetList(Func<T, bool> predicate);
        T Get(Guid Id);
    }

}
