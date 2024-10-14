using System.IO.Compression;

public static class GZipHelper
{
    private const int Buffer_Size = 2048;
    public static async Task<byte[]> Zip(this byte[] Input)
    {
        var msInput = new MemoryStream(Input);
        var msOutput = new MemoryStream();
        var giz = new GZipStream(msOutput, CompressionMode.Compress, false);

        giz.Write(Input, 0, Input.Length);
        //await msInput.CopyToAsync(giz);
        await giz.FlushAsync();

        return msOutput.ToArray();
    }

    public static async Task<byte[]> UnZip(this byte[] Input)
    {
        var msInput = new MemoryStream(Input);
        var msOutput = new MemoryStream();
        var giz = new GZipStream(msInput, CompressionMode.Decompress, false);

        await giz.CopyToAsync(msOutput);
        await giz.FlushAsync();

        return msOutput.ToArray();
    }

}