public class TextifyHelper(TextifyPrepare prepare)
{
    private readonly TextifyPrepare prepare = prepare;

    public async Task TextifyAsync()
    {
        Console.WriteLine("Start Textify Process....");
        var chunks = prepare.GetChunks;
        int Index = 0;
        foreach (var chunk in chunks)
        {
            Index += 1;
            string base64 = Convert.ToBase64String(chunk);
            string outFile = Path.Combine(prepare.DestDir, string.Format("chunk{0:D9}.txt", Index));
            await File.WriteAllTextAsync(outFile, base64);

            Console.WriteLine($"Chunk[{Index}] Write into {prepare.DestDir}.");
        }
        Console.WriteLine("Textify Process Done.");
    }
}