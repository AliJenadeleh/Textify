const int ChunkSize = 2000;
if (args.Length != 3)
    Console.WriteLine("Textify needs exacly 3 arguments");
else
{
    string command = args[0];
    string source = args[1];
    string target = args[2];

    if (command.Equals("-t", StringComparison.OrdinalIgnoreCase))
    {
        var prepare = new TextifyPrepare(ChunkSize, source, target);

        if (await prepare.Prepare())
        {
            await new TextifyHelper(prepare).TextifyAsync();
        }
    }
    else if (command.Equals("-t1", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("*********************Start*Textify***************************");
        var prepare = new TextifyPrepare(-1, source, target);

        if (await prepare.Prepare())
        {
            await new TextifyHelper(prepare).TextifyAsync();
        }
    }
    else if (command.Equals("-ut", StringComparison.OrdinalIgnoreCase))
    {
        var prepare = new UnTextifyPrepare(source, target);
        if (prepare.Prepare())
        {
            await new UnTextifyHelper(prepare).UnTextifyAsync();
        }
    }
    else
    {
        Console.WriteLine("Command is not valid");
    }
}