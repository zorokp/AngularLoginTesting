using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Repositories {

    public interface ILoadentEntity {
        Guid Id { get; set; }
    }

    public interface ILoadentRepo<T> where T : ILoadentEntity {
        bool Add<T>(T entity) where T: class;
        bool Delete(T entity);
        bool Update(T entity, Func<T, bool> predicate);
        // https://stackoverflow.com/questions/11143602/possible-ways-to-use-func-t-bool-while-using-a-linq-repository
        //IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetList(Func<T, bool> predicate);
        T Get(Guid Id);
    }

    public class Supplier : ILoadentEntity {
        public virtual Guid Id { get; set; }
        public virtual int SupplierId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
    }

    //public interface IPORepository<T> where T : POHeader {
    //    bool Add(T entity);
    //    bool Delete(T entity);
    //    bool Update(T entity, Func<T, bool> predicate);
    //    // https://stackoverflow.com/questions/11143602/possible-ways-to-use-func-t-bool-while-using-a-linq-repository
    //    //IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    //    IEnumerable<T> Find(Func<T, bool> predicate);
    //    T Get(Guid Id);
    //}

}
