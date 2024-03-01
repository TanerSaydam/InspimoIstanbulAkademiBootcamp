using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Microsoft.EntityFrameworkCore;

namespace BenchMark.ConsoleApp;

[Config(typeof(Config))]
public class BenchMarkService
{
    ApplicationDbContext context = new();

    public class Config : ManualConfig
    {
        public Config()
        {
            SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default.WithRatioStyle(BenchmarkDotNet.Columns.RatioStyle.Trend);
        }
    }

    [Benchmark(Baseline = true)]
    public async Task IncludeAsync()
    {
        var response = await context.Personels
            .AsNoTracking()
            .Include(p=> p.Profession)
            .Select(s=> new
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                IdentityNumber = s.IdentityNumber
            })
            .ToListAsync();
    }

    [Benchmark]
    public async Task JoinAsync()
    {
        var response = await 
                        (from personel in context.Personels
                        join profession in context.Professions on personel.ProfessionId equals profession.Id
                        select new
                        {
                            Id = personel.Id,                            
                            FirstName = personel.FirstName,                            
                            LastName = personel.LastName,
                            IdentityNumber = personel.IdentityNumber,
                        }).ToListAsync();
    }
}
