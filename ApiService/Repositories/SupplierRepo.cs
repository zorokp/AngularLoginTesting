using ApiService.Data;
using ApiService.Models;
using ApiService.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Repositories {

    public class SupplierRepo : ISupplierRepo { 

        private readonly DataContext _context;
        
        public SupplierRepo(DataContext context) {
            _context = context;
        }

        public async Task<bool> AddSupplierAsync(Supplier entity) {
            try {
                await _context.Supplier.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;

            } catch (Exception ex) {

                throw;
            }
        }

        public async Task<bool> UpdateSupplierAsync(Supplier supplier) {
            var currentRecord = await _context.Supplier.FirstOrDefaultAsync(x => x.Id == supplier.Id);
            if(currentRecord != null) {
                currentRecord.Address = supplier.Address;
                currentRecord.AddressId = supplier.AddressId;
                currentRecord.Id = supplier.Id;
                currentRecord.Name = supplier.Name;
                _context.Attach(currentRecord).State = EntityState.Modified;
                var res = await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId) {
            var supplierRecord = await _context.Supplier.FirstOrDefaultAsync(x => x.Id == supplierId);
            if (supplierRecord != null) {
                await DeleteAddressRecordAsync(supplierRecord);
                await DeleteSupplierRecordAsync(supplierRecord);
                
                var res = await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private async Task<int> DeleteAddressRecordAsync(Supplier supplierRecord) {
            var currentAddressRecord = await _context.Address.FirstOrDefaultAsync(a => a.Id == supplierRecord.AddressId);
            if (currentAddressRecord != null) {
               _context.Attach(currentAddressRecord).State = EntityState.Deleted;                
            }
            return 0;
        }

        private Task<int> DeleteSupplierRecordAsync(Supplier supplierRecord) {
            _context.Attach(supplierRecord).State = EntityState.Deleted;
            return Task.FromResult(0);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync() {
            var qryResult = await _context.Supplier.Include(a=>a.Address).ToListAsync();
            return qryResult;
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
