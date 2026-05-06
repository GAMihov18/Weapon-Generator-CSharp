using GameCore;
using System.Text.Json;

Rarity common = new Rarity(
	"Common", 
	0, 
	0, 
	0, 
	0, 
	0, 
	0, 
	0);

var json = JsonSerializer.Serialize(common);

Console.WriteLine(json);
File.WriteAllText("test.json", json);

var inputClassText = File.ReadAllText("test.json");
Console.WriteLine(inputClassText);

Console.WriteLine(JsonSerializer.Deserialize<Rarity>(inputClassText));



