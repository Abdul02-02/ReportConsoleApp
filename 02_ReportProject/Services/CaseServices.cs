using _02_ReportProject.Context;
using _02_ReportProject.Form;
using _02_ReportProject.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _02_ReportProject.Services;

internal class CaseServices
{
    private readonly DataContext _context = new DataContext();
    public async Task<IEnumerable<Case>> GetAllAsync()
    {
        return await _context.Cases.Include(x => x.Client).ToListAsync();
    }

    public async Task<Case> GetAsynsc(string Status)
    {
        var Case = await _context.Cases.Include(x => x.Client).FirstOrDefaultAsync(x => x.Status == Status);
        if (Case != null)
            return Case;
        return null!;
    }

    public async Task<Case> CreateAsync(RegistrationForm form)
    {

        var Case = new Case()
        {
            Description = form.Description,
            Time = form.Time,
            Status = form.Status,
        };

        _context.Add(Case);
        await _context.SaveChangesAsync();

        return Case;
    }
}
