using ApiService.Models;
using ApiService.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Controllers {

    [Produces("application/json")]
    [Route("api/Address")]
    [ApiController]
    public class AddressApiController : ControllerBase {

        IAddressRepo _repo;

        public AddressApiController(IAddressRepo repo) {
            _repo = repo;
        }

        [HttpPost("AddSupplier")]
        public async Task<IActionResult> Add(Address entity) {
            var res = await _repo.AddAddressAsync(entity);
            return Ok("Record Added");
        }
    }
}
  