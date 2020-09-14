using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.DAL.Interfaces;
using Pomodoro.Dtos;
using System.Collections.Generic;

namespace Pomodoro.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PomodoroUserDto>> GetAllUsers()
        {
            var users = _mapper.Map<List<PomodoroUserDto>>(_userService.GetAllUsers());

            return new JsonResult(users);
        }

        [HttpGet("{id}")]
        public ActionResult<PomodoroUserDto> GetUser(int id)
        {
            var user = _mapper.Map<PomodoroUserDto>(_userService.GetUserById(id));

            return new JsonResult(user);
        }
    }
}
