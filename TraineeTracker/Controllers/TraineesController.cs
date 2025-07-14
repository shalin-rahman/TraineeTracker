using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeTracker.DTOs;

namespace TraineeTracker.Controllers
{
    [ApiController]
    [Route("api/trainees")]
    public class TraineesController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        public TraineesController(AppDbContext ctx) => _ctx = ctx;

        [HttpPost]
        public async Task<IActionResult> Add(TraineeCreateDto dto)
        {
            Trainee t = dto.Type switch
            {
                "Fresher" => new Fresher(),
                "Intern" => new Intern(),
                _ => null
            };
            if (t == null) return BadRequest("Invalid Type");
            // assign fields...
            _ctx.Trainees.Add(t);
            await _ctx.SaveChangesAsync();
            return Ok(new { t.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _ctx.Trainees.ToListAsync();
            return Ok(list.Select(t => new {
                t.TraineeId,
                t.Name,
                t.Technology,
                t.Type,
                t.Module1Score,
                t.Module2Score,
                t.ProjectCompleted,
                t.FeedbackScore
            }));
        }
    }
}
