using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Models.Interfaces {
    public interface ISupplierRepo {
        public Task<bool> AddSupplierAsync(Supplier entity);
        public Task<bool> UpdateSupplierAsync(Supplier entity);
        public Task<IEnumerable<Supplier>> GetSuppliersAsync();
        public Task<bool> DeleteSupplierAsync(int id);
    }
}
