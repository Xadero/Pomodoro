using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.DAL.Interfaces;
using Pomodoro.DAL.Models.Pomodoro;
using Pomodoro.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pomodoro.Controllers
{
    [Route("Pomodoros")]
    [ApiController]
    public class PomodorosController : ControllerBase
    {
        private readonly IPomodoroService _pomodoroService;
        private readonly IMapper _mapper;
        public PomodorosController(IPomodoroService pomodoroService, IMapper mapper)
        {
            _pomodoroService = pomodoroService;
            _mapper = mapper;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<PomodoroDto>> CreateNewPomodoro(PomodoroDto pomodoro)
        {
            var pomodoroModel = await _pomodoroService.CreateNewPomodoro(_mapper.Map<Pomodoros>(pomodoro));

            return new JsonResult(pomodoroModel);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<PomodoroTypeDto>> AddNewPomodoroType(PomodoroTypeDto pomodoroTypeDto)
        {
            var createdType = await _pomodoroService.CreateNewType(pomodoroTypeDto.PomodoroUserId.Value, pomodoroTypeDto.Value);
            return new JsonResult(_mapper.Map<PomodoroTypeDto>(createdType));
        }

        [Route("[action]/{pomodoroId}")]
        [HttpPut]
        public async Task<ActionResult<PomodoroDto>> CompletePomodoro(int pomodoroId)
        {
            await _pomodoroService.CompletePomodoro(pomodoroId);
            return Ok();
        }

        [Route("[action]/{pomodoroId}")]
        [HttpPut]
        public async Task<ActionResult<PomodoroDto>> CancelPomodoro(int pomodoroId)
        {
            await _pomodoroService.CancelPomodoro(pomodoroId);
            return Ok();
        }

        [Route("[action]")]
        [HttpGet("GetUserHistory/{id}")]
        public ActionResult<List<PomodoroDto>> GetUserHistory(int id)
        {
            var pomodoros = _pomodoroService.GetPomodoros(id);
            return new JsonResult(pomodoros);
        }

        [Route("[action]")]
        [HttpGet("GetPomodoroType/{id}")]
        public ActionResult<IEnumerable<PomodoroTypeDto>> GetUserPomodorType(int id)
        {
            var pomodoroTypes = _mapper.Map<List<PomodoroTypeDto>>(_pomodoroService.GetPomodoroTypes(id));

            return new JsonResult(pomodoroTypes);
        }

        [HttpGet("GetUserSettings/{id}")]
        public ActionResult<PomodoroSettingsDto> GetUserSettings(int id)
        {
            var settings = _mapper.Map<PomodoroSettingsDto>(_pomodoroService.GetUserSettings(id));

            return new JsonResult(settings);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<PomodoroSettingsDto>> UpdateSettings(PomodoroSettingsDto settings)
        {
            var newSettings = await _pomodoroService.UpdateSettings(_mapper.Map<PomodoroSettings>(settings));
            return new JsonResult(newSettings);
        }
    }
}
