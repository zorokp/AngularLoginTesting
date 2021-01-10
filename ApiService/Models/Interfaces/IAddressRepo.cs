using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Models.Interfaces {
    public interface IAddressRepo {
        public Task<bool> AddAddressAsync(Address entiti);
    }
}
