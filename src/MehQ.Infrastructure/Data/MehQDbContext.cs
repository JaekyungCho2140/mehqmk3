using MehQ.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MehQ.Infrastructure.Data;

public class MehQDbContext : DbContext
{
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TranslationDocument> Documents => Set<TranslationDocument>();
    public DbSet<TranslationMemory> TranslationMemories => Set<TranslationMemory>();
    public DbSet<TmEntry> TmEntries => Set<TmEntry>();
    public DbSet<TermBase> TermBases => Set<TermBase>();
    public DbSet<Term> Terms => Set<Term>();

    public MehQDbContext(DbContextOptions<MehQDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(e =>
        {
            e.HasKey(p => p.Id);
            e.HasMany(p => p.Documents).WithOne(d => d.Project).HasForeignKey(d => d.ProjectId);
            e.HasMany(p => p.TranslationMemories).WithMany();
            e.HasMany(p => p.TermBases).WithMany();
        });

        modelBuilder.Entity<TranslationDocument>(e =>
        {
            e.HasKey(d => d.Id);
            e.HasMany(d => d.Segments).WithOne(s => s.Document).HasForeignKey(s => s.DocumentId);
        });

        modelBuilder.Entity<Segment>(e =>
        {
            e.HasKey(s => s.Id);
            e.Ignore(s => s.SourceTags);
            e.Ignore(s => s.TargetTags);
        });

        modelBuilder.Entity<TranslationMemory>(e =>
        {
            e.HasKey(tm => tm.Id);
            e.HasMany(tm => tm.Entries).WithOne(entry => entry.TranslationMemory).HasForeignKey(entry => entry.TranslationMemoryId);
        });

        modelBuilder.Entity<TmEntry>(e =>
        {
            e.HasKey(entry => entry.Id);
            e.HasIndex(entry => entry.Source);
        });

        modelBuilder.Entity<TermBase>(e =>
        {
            e.HasKey(tb => tb.Id);
            e.HasMany(tb => tb.Terms).WithOne(t => t.TermBase).HasForeignKey(t => t.TermBaseId);
        });

        modelBuilder.Entity<Term>(e =>
        {
            e.HasKey(t => t.Id);
        });
    }
}
