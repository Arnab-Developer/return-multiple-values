using System;
using static System.Console;

if (Service1.TryConvertToInt("100", out int num))
{
    WriteLine(num);
}

(string FirstName, string LastName) = Service1.BreakName1("Jon Doe");
WriteLine($"{FirstName} {LastName}");

Tuple<string, string> name2 = Service1.BreakName2("Jon Doe");
WriteLine($"{name2.Item1} {name2.Item2}");

NameStruct nameStruct = Service1.BreakName3("Jon Doe");
WriteLine($"{nameStruct.FirstName} {nameStruct.LastName}");

NameRecord nameRecord = Service1.BreakName4("Jon Doe");
WriteLine($"{nameRecord.FirstName} {nameRecord.LastName}");

internal static class Service1
{
    public static bool TryConvertToInt(string input, out int num) => int.TryParse(input, out num);

    public static (string, string) BreakName1(string fullName)
    {
        string[] nameParts = fullName.Split(' ');
        (string FirstName, string LastName) name = (nameParts[0], nameParts[1]);
        return name;
    }

    public static Tuple<string, string> BreakName2(string fullName)
    {
        string[] nameParts = fullName.Split(' ');
        Tuple<string, string> name = Tuple.Create(nameParts[0], nameParts[1]);
        return name;
    }

    public static NameStruct BreakName3(string fullName)
    {
        string[] nameParts = fullName.Split(' ');
        NameStruct name = new() { FirstName = nameParts[0], LastName = nameParts[1] };
        return name;
    }

    public static NameRecord BreakName4(string fullName)
    {
        string[] nameParts = fullName.Split(' ');
        NameRecord name = new(nameParts[0], nameParts[1]);
        return name;
    }
}

internal struct NameStruct
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

record NameRecord(string FirstName, string LastName);

/*
Output:

100
Jon Doe
Jon Doe
Jon Doe
Jon Doe
*/