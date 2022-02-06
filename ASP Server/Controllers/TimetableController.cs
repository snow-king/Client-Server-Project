using ASP_Server.Services;
using ASP_Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Server.Controllers;

[ApiController]
[Route("[controller]")]
public class TimetableController : ControllerBase
{
    TimetableService _service;

    public TimetableController(TimetableService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Timetable> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Timetable> GetById(int id)
    {
        var timetable = _service.GetById(id);

        if (timetable is not null)
        {
            return timetable;
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Create(Timetable newTimetable)
    {
        var timetable = _service.Create(newTimetable);
        return CreatedAtAction(nameof(GetById), new { id = timetable!.IdSchedule }, timetable);
    }
}