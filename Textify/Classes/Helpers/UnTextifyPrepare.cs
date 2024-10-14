public class UnTextifyPrepare(string SourceDir, string DestFile)
{
    private readonly string SourceDir = SourceDir;
    private readonly string _destFile = DestFile;

    public bool Prepare()
    {
        if (Directory.Exists(SourceDir))
        {

            if (File.Exists(_destFile))
            {
                Console.WriteLine($"{_destFile} already exists.");
                return false;
            }

            return true;
        }

        Console.WriteLine("Source Directory NotFound!!");
        return false;
    }

    public string SourceDirectory => SourceDir;
    public string DestFile => _destFile;
}