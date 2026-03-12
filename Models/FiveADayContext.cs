using FruitAndVegApp;
using Microsoft.EntityFrameworkCore;

public class FiveADayContext : DbContext
{
    public FiveADayContext(DbContextOptions<FiveADayContext> options)
        : base(options)
    {


    }

    public DbSet<FiveADay> FiveADays { get; set; } = null!;
}