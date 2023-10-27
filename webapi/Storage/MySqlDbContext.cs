using Microsoft.EntityFrameworkCore;
using CopilotChat.WebApi.Models.Storage;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CopilotChat.WebApi.Storage;

public class MySqlDbContext : DbContext
{
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
    {
    }

    public DbSet<ChatSession> ChatSession { get; set; }
    public DbSet<ChatMessage> ChatMessage { get; set; }
    public DbSet<MemorySource> MemorySource { get; set; }
    public DbSet<ChatParticipant> ChatParticipant { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatMessage>()
            .Property(c => c.TokenUsage)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<Dictionary<string, int>>(v))
            .HasMaxLength(5000);

        modelBuilder.Entity<ChatSession>()
            .Property(e => e.EnabledPlugins)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<HashSet<string>>(v))
            .HasMaxLength(5000);

        modelBuilder.Ignore<CitationSource>();
    }
}