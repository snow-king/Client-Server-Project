using ASP_Server.Models;
using ASP_Server.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP_Server.Services;

public class TimetableService
{
    private readonly TimetabledbContext _context;

    public TimetableService(TimetabledbContext context)
    {
        _context = context;
    }

    public IEnumerable<Timetable> GetAll()
    {
        return _context.Timetables!
            .Include(p => p.LessonTime)
            .Include(p => p.WeekParity)
            .Include(p => p.WeekDay)
            .Include(p => p.Classroom)
            .Include(p => p.StudyGroup)
            .Include(p => p.Professor)
            .Include(p => p.Discipline)
            .Include(p => p.LessonType)
            .AsNoTracking()
            .ToList();
    }

    public Timetable? GetById(int id)
    {
        return _context.Timetables!
            .Include(p => p.LessonTime)
            .Include(p => p.WeekParity)
            .Include(p => p.WeekDay)
            .Include(p => p.Classroom)
            .Include(p => p.StudyGroup)
            .Include(p => p.Professor)
            .Include(p => p.Discipline)
            .Include(p => p.LessonType)
            .AsNoTracking()
            .SingleOrDefault(p => p.IdSchedule == id);
    }

    public Timetable? Create(Timetable newTimetable)
    {
        _context.Timetables!.Add(newTimetable);
        _context.SaveChanges();

        return newTimetable;
    }
}