using ApiService.Data;
using ApiService.Models;
using ApiService.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Repositories {
    public class AddressRepo : IAddressRepo {

        private readonly DataContext _context;
        public AddressRepo(DataContext context) {
            _context = context;
        }

        public async Task<bool> AddAddressAsync(Address entity) {
            try {
                await _context.Address.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;

            } catch (Exception ex) {

                throw;
            }
        }
    }
}
