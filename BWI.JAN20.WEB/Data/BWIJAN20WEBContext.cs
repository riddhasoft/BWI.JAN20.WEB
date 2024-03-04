using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BWI.JAN20.WEB.Models;

public class BWIJAN20WEBContext : DbContext
{
    public BWIJAN20WEBContext(DbContextOptions<BWIJAN20WEBContext> options)
        : base(options)
    {
    }

    public DbSet<BWI.JAN20.WEB.Models.StudentModel> StudentModel { get; set; } = default!;
    public DbSet<BookModel> BookModel { get; set; }
    public DbSet<SignupModel> User { get; set; }
    public DbSet<BWI.JAN20.WEB.Models.StudentsBookEnrollmentModel>? StudentsBookEnrollmentModel { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("myScheema");
        base.OnModelCreating(modelBuilder);

    }
}
