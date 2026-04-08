using MehQ.Core.Interfaces;

namespace MehQ.Infrastructure.Parsers;

public class FileParserFactory
{
    private readonly IReadOnlyList<IFileParser> _parsers;

    public FileParserFactory(IEnumerable<IFileParser> parsers)
    {
        _parsers = parsers.ToList();
    }

    public IFileParser? GetParser(string filePath)
    {
        var extension = Path.GetExtension(filePath).ToLowerInvariant();
        return _parsers.FirstOrDefault(p => p.SupportedExtensions.Contains(extension));
    }
}
