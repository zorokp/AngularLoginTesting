using ApiService.Data;
using ApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Repositories {

    public interface ISupplierRepo {
        public Task<bool> AddSupplierAsync(Supplier entity); 
    }

    public class SupplierRepo : ISupplierRepo { 

        private readonly DataContext _context;
        
        public SupplierRepo(DataContext context) {
            _context = context;
        }

        public async Task<bool> AddSupplierAsync(Supplier entity) {
            try {
                await _context.Suppliers.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;

            } catch (Exception ex) {

                throw;
            }
        }

        //public async Task<bool> AddAsync<T>(T entity) where T: class {
        //    try {
                
        //        var toAdd = entity;
        //        await _context.Suppliers.AddAsync(toAdd);
        //        await _context.SaveChangesAsync();
        //        return true;

        //    } catch (Exception ex) {

        //        throw;
        //    }
        //}


    }
}
