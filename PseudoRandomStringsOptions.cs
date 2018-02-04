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