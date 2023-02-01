// See https://aka.ms/new-console-template for more information
using LivingDocParse;
using System.Text.Json;

string inputDir = null;
string outputDir = null;

if (args.Length != 2) {
    throw new Exception("Must specifiy inputDir and outputDir with FileName");
    }

inputDir = args[0];
outputDir = args[1];

//Used in debug
//var inputDir = @"C:\Users\jest\Downloads\3.1.7\New folder";
//var outputDir = @"C:\Users\jest\Downloads\3.1.7\New folder (2)\path.json";

//Parse all Json Files
var files = Directory.GetFiles(inputDir, "*.json");
//Create Empty List of executions
var ListOfRoots = new List<Rootobject>();

//Foreach File Deserialize it into a root object and add it to list
foreach (var file in files) {
    StreamReader sr = new StreamReader(file);
    string jsonString = sr.ReadToEnd();
    sr.Close();
    var item = JsonSerializer.Deserialize<Rootobject>(jsonString);
    ListOfRoots.Add(item);
    }

//Create a new empty Root Object to add just the results we want
var newJson = new Rootobject() {
    Nodes = new(),
    ExecutionResults = new(),
    CLIUserSpecFlowId = null,
    StepReports = null,
    PluginUserSpecFlowId = "<insert you guid here>",
    ExecutionTime = DateTime.Now,
    };
//Create new Empty list of Executionresults
var exlist = new List<Executionresult>();
//For Each Execution add all the Executionresult to a single list
foreach (var item in ListOfRoots) {
    exlist.AddRange(item.ExecutionResults);
    }

//itterate over the single list
for (int i = 0; i < exlist.Count; i++) {
    //Find if scenario name is within the list more that once
    var scenarios = exlist.FindAll(x => x.ScenarioTitle == exlist[i].ScenarioTitle);
    if (scenarios.Count > 1) {
        // Find all the instances of pass and failure for each scenario
        var fails = scenarios.FindAll(x => x.Status != "OK");
        var passes = scenarios.FindAll(x => x.Status == "OK");

        //If there is a pass and failures remove the failures otherwise keep all the items in the list to show actual failures
        if (passes.Count > 0 && fails.Count > 0) {
            foreach (var fail in fails) {
                Console.WriteLine($"Removing Extra Failed run for Test : {fail.ScenarioTitle}");
                exlist.Remove(fail);
                }
            }
        }
    }

//add the list with just extra tests runs removed
newJson.ExecutionResults.AddRange(exlist);

//output the new execution to a json file
var options = new JsonSerializerOptions { WriteIndented = true };
string json = JsonSerializer.Serialize(newJson, options);
File.WriteAllText(outputDir, json);

//used to breakpoint
Console.WriteLine("Cleaned up JSON from extra runs");