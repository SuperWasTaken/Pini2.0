//--- Example Use of PINI in your CS code
using PINI;
Pini ini = new("example.pini");
if(ini.GetSection("MySection", out var s))
{
    Console.WriteLine("Sucess");
    s.PrintContents();

    Console.WriteLine(" ");
    s.GetInstace("MyInstance",out var inst);
    foreach(var item in inst.ActiveKeys) 
    {
        Console.WriteLine("KeyName: " + item.name);
        Console.WriteLine("Value: " + item.value);
        Console.WriteLine($"Arguments");
        foreach(var arg in item.args) 
        {
            Console.WriteLine(arg);
        }
    }


    // To Get a single key 

    
}
else 
{
    Console.WriteLine("Failed :(");
}