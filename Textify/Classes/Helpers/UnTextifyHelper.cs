public class UnTextifyHelper(UnTextifyPrepare prepare)
{
    private readonly UnTextifyPrepare prepare = prepare;

    public async Task UnTextifyAsync()
    {
        Console.WriteLine("UnTextify Process Started.....");

        var files = Directory.GetFiles(prepare.SourceDirectory).OrderBy(a => a);
        var ms = new MemoryStream();
        foreach (var file in files)
        {
            var text = await File.ReadAllTextAsync(file);
            var bytes = Convert.FromBase64String(text);
            await ms.WriteAsync(bytes);
        }
        var uzBuffer = await GZipHelper.UnZip(ms.ToArray());

        var fs = new FileStream(prepare.DestFile, FileMode.OpenOrCreate, FileAccess.Write);
        await fs.WriteAsync(uzBuffer);
        await fs.FlushAsync();
        fs.Close();
        Console.WriteLine("UnTextify Process Done.");
    }
}