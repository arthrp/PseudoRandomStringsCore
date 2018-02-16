using CommandLine;

[Verb("string", HelpText = "Generate random string")]
class StringOptions {
    [Option('l', "length", HelpText = "Length of the generated string")]
    public int Length {get; set;}
}

[Verb("email", HelpText = "Generate random email")]
class EmailOptions {
    [Option('l', "length", HelpText = "Length of the email")]
    public int TotalLength {get; set;}
}

[Verb("name", HelpText = "Generate random name")]
class NameOptions 
{
    [Option('t', "type", Default = NameTypeEnum.All, HelpText = "Type of the generated name")]
    public NameTypeEnum NameType {get; set;}
}

[Verb("number", HelpText = "Generate random positive integer in defined range")]
class NumberOptions
{
    [Value(0, MetaName = "Minimun value", Required = true)]
    public int Min {get; set;}

    [Value(1, MetaName = "Max value", Required = true)]
    public int Max {get; set;}
}