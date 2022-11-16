using System;
using Lab5.Models;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
namespace Lab5.Data
{
    public class AnswerImageDbContext : DbContext
    {
        public AnswerImageDbContext(DbContextOptions<AnswerImageDbContext> options) : base(options)
        {
        }
        public DbSet<Lab5.Models.AnswerImage> AnswerImage { get; set; }
    }
}

