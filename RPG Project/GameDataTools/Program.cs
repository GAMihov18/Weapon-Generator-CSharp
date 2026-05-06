using System.CommandLine;
using System.CommandLine.Parsing;

class Program
{
	static int Main(string[] args)
	{
		
		RootCommand rootCommand = new("Commands for modifying the game data of the game");

		
		#if DEBUG
		AddDebugCommands(rootCommand);
		#endif
		
		
		
		rootCommand.Parse(args).Invoke();
		return 0;
	}
	
#if DEBUG
	static void AddDebugCommands(RootCommand rootCommand)
	{
		Command listCommandsCommand = new("list", "List all available commands");
		
		listCommandsCommand.SetAction(_ =>
		{
			PrintCommandTree(rootCommand);
		});
		
		Command commandsCommand = new("commands", "Contains subcommands for work with commands");
		commandsCommand.Add(listCommandsCommand);



		Command debugCommand = new("debug", "Debug commands");
		debugCommand.Add(commandsCommand); 
		
		
		rootCommand.Add(debugCommand);
	}
	static void PrintCommandTree(Command command, int depth = 0)
	{
		var indent = new string(' ', depth * 2);

		Console.WriteLine($"{indent}{command.Name}");

		if (!string.IsNullOrWhiteSpace(command.Description))
			Console.WriteLine($"{indent}  {command.Description}");
		
		if (command.Arguments.Count > 0)
			foreach (var argument in command.Arguments)
				Console.WriteLine($"{indent}  * {argument.Name} {argument.Description}");
		if (command.Options.Count > 0)
			foreach (var option in command.Options)
				Console.WriteLine($"{indent}  <> {option.Name} {option.Description}");
		
		Console.WriteLine();
		foreach (var subcommand in command.Subcommands)
			PrintCommandTree(subcommand, depth + 1);
	}
#endif
	
}