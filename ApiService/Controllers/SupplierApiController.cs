using ApiService.Models;
using ApiService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Controllers {

    [Produces("application/json")]
    [Route("api/Supplier")]
    [ApiController]
    public class SupplierApiController : ControllerBase {

        //ILoadentRepo<Supplier> _repo;
        ISupplierRepo _repo;
        public SupplierApiController(ISupplierRepo repo) {
            _repo = repo;
        }

        [HttpPost("PostSupplier")]
        public async Task<IActionResult> Add(Supplier supplier) {
            var supp = new Supplier() {
                Address = "123 Lee St.",
                Name = "First Supplier"
            };

            var res = await _repo.AddSupplierAsync(supplier);
            if(res == true) {

            }

            return Ok("Record Added");

        }

    }

}
