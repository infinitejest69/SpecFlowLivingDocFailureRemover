using System;
using System.IO;

namespace LivingDocParse
{
    public class Rootobject
    {
        public List<object> Nodes { get; set; }
        public DateTime ExecutionTime { get; set; }
        public DateTime GenerationTime { get; set; }
        public string PluginUserSpecFlowId { get; set; }
        public object CLIUserSpecFlowId { get; set; }
        public List<Executionresult> ExecutionResults { get; set; }
        public object StepReports { get; set; }
    }

    public class Executionresult //: IEquatable<Executionresult>
    {
        public string ContextType { get; set; }
        public string FeatureFolderPath { get; set; }
        public string FeatureTitle { get; set; }
        public string ScenarioTitle { get; set; }
        public List<string> ScenarioArguments { get; set; }
        public string Status { get; set; }
        public List<Stepresult> StepResults { get; set; }
        public List<Output1> Outputs { get; set; }
    }

    public class Stepresult
    {
        public string Duration { get; set; }
        public string Status { get; set; }
        public string Error { get; set; }
        public List<Output> Outputs { get; set; }
    }

    public class Output
    {
        public string OutputLocation { get; set; }
        public string Type { get; set; }
        public object Message { get; set; }
        public string FilePath { get; set; }
    }

    public class Output1
    {
        public string OutputLocation { get; set; }
        public string Type { get; set; }
        public object Message { get; set; }
        public string FilePath { get; set; }
    }
}