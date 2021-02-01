using ApiService.Models;
using ApiService.Models.Interfaces;
using ApiService.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
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

        IMapper _mapper;
        ISupplierRepo _repo;
        public SupplierApiController(ISupplierRepo repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }

        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var isDeleted = await _repo.DeleteSupplierAsync(id);
            if (isDeleted)
                return Ok("Record Deleted.");
            else
                return BadRequest("Record Not Deleted.");
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var suppliers = await _repo.GetSuppliersAsync();
            var suppliersDto = _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
            return Ok(suppliersDto);
        }

        [HttpPost("AddSupplier")]
        public async Task<IActionResult> Add(Supplier entity) {
            try {
                if (entity.Address != null) {
                    entity.Address.AddressType = "Supplier";
                    var res = await _repo.AddSupplierAsync(entity);
                    return Ok("Record Added");
                }
                return BadRequest("Supplier can not be null.");
            } catch (Exception ex) {
                throw;
            }
        }

        [HttpPut("UpdateSupplier")]
        public async Task<IActionResult> UpdateSupplier(Supplier entity) {
            try {
                if(entity != null) {
                    entity.Address.AddressType = "Supplier";
                    var res = await _repo.UpdateSupplierAsync(entity);
                    if (res)
                        return Ok("Record Updated");
                    else
                        return BadRequest("Supplier not found in system! Record not updated!");
                }
                return BadRequest("Supplier can not be null.");
            } catch (Exception ex) {
                throw;
            }
        }


    }

}
