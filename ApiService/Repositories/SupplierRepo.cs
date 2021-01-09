using ApiService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Repositories {
    public class SupplierRepo : ILoadentRepo<Supplier> {

        private readonly DataContext _context;
        
        public SupplierRepo(DataContext context) {
            _context = context;
        }
        
        public bool Add<T>(T entity) where T: class {
            var res = _context.Add(entity);
            return true;
        }

        public bool Delete(Supplier entity) {
            throw new NotImplementedException();
        }

        public Supplier Get(Guid Id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> GetList(Func<Supplier, bool> predicate) {
            throw new NotImplementedException();
        }

        public bool Update(Supplier entity, Func<Supplier, bool> predicate) {
            throw new NotImplementedException();
        }
    }
}
