using ApiService.Models;
using ApiService.Models.Interfaces;
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

        [HttpPost("AddSupplier")]
        public async Task<IActionResult> Add(Supplier entity) {
            try {

                if (entity.SupplierAddress != null) {
                    entity.SupplierAddress.AddressType = "Supplier";
                }

                var res = await _repo.AddSupplierAsync(entity);
                return Ok("Record Added");

            } catch (Exception ex) {

                throw;
            }
            

        }

    }

}
