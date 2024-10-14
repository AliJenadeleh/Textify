public class TextifyPrepare(int ChunkSize, string SourceFile, string DestDir)
{
    private readonly int chunkSize = ChunkSize;
    private readonly string SourceFile = SourceFile;
    private readonly string _destDir = DestDir;

    private byte[] SourceData = [];

    public async Task<bool> Prepare()
    {
        if (File.Exists(SourceFile))
        {
            var _SourceData = File.ReadAllBytes(SourceFile);

            SourceData = await GZipHelper.Zip(_SourceData);
            if (!Directory.Exists(_destDir))
            {
                Directory.CreateDirectory(_destDir);
            }

            return true;
        }

        Console.WriteLine("Source File NotFound!!");
        return false;
    }

    public IEnumerable<byte[]> GetChunks => SourceData.Chunk(chunkSize);

    public string DestDir => _destDir;
}