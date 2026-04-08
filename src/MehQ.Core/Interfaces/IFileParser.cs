using MehQ.Core.Models;

namespace MehQ.Core.Interfaces;

public interface IFileParser
{
    string[] SupportedExtensions { get; }
    Task<IReadOnlyList<Segment>> ParseAsync(string filePath, CancellationToken ct = default);
    Task SaveAsync(string filePath, IReadOnlyList<Segment> segments, CancellationToken ct = default);
}
