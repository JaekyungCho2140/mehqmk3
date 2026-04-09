using MehQ.Core.Interfaces;
using MehQ.Core.Models;
using MehQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MehQ.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly MehQDbContext _db;

    public ProjectRepository(MehQDbContext db) => _db = db;

    public async Task<Project?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _db.Projects
            .Include(p => p.Documents).ThenInclude(d => d.Segments)
            .Include(p => p.TranslationMemories)
            .Include(p => p.TermBases)
            .FirstOrDefaultAsync(p => p.Id == id, ct);

    public async Task<IReadOnlyList<Project>> GetAllAsync(CancellationToken ct = default)
        => await _db.Projects.OrderByDescending(p => p.UpdatedAt).ToListAsync(ct);

    public async Task<Project> AddAsync(Project project, CancellationToken ct = default)
    {
        _db.Projects.Add(project);
        await _db.SaveChangesAsync(ct);
        return project;
    }

    public async Task UpdateAsync(Project project, CancellationToken ct = default)
    {
        project.UpdatedAt = DateTime.UtcNow;
        _db.Projects.Update(project);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var project = await _db.Projects.FindAsync([id], ct);
        if (project != null)
        {
            _db.Projects.Remove(project);
            await _db.SaveChangesAsync(ct);
        }
    }
}
