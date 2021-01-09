using ApiService.Models;
using ApiService.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiService.Controllers {

    [Authorize]
    [Route("api/User")]
    [ApiController]
    public class UserApiController : ControllerBase {

        IUserRepo _repo;
        IMapper _mapper;

        public UserApiController(IUserRepo repo, IMapper mapper) {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id) {
            var user = await _repo.GetUser(id);
            //return Ok(user);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers() {
            var users = await _repo.GetUsers();
            var usersDto = _mapper.Map<IEnumerable<UserDetailDto>>(users);
            return Ok(usersDto);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdatUser(int id, UserForUpdateDto userForUpdateDto) {
        //    if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
        //        return Unauthorized();

        //    var userFromRepo = await _repo.GetUser(id);
        //    _mapper.Map(userForUpdateDto, userFromRepo);

        //    if (await _repo.SaveAll())
        //        return NoContent();

        //    throw new Exception($"Error! Updating user with id {id} failed on save!");
        //}

    }
}
