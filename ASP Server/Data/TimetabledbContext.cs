using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ASP_Server.Models;

namespace ASP_Server.Data
{
    public partial class TimetabledbContext : DbContext
    {
        public TimetabledbContext(DbContextOptions<TimetabledbContext> options) : base(options)
        {
        }

        public DbSet<Classroom>? Classrooms { get; set; }
        public DbSet<Discipline>? Disciplines { get; set; }
        public DbSet<LessonTime>? LessonTimes { get; set; }
        public DbSet<LessonType>? LessonTypes { get; set; }
        public DbSet<Professor>? Professors { get; set; }
        public DbSet<StudyGroup>? StudyGroups { get; set; }
        public DbSet<Timetable>? Timetables { get; set; }
        public DbSet<WeekDay>? WeekDays { get; set; }
        public DbSet<WeekParity>? WeekParities { get; set; }
    }
}
