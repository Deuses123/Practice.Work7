using Practice.Work7;



var a = new Methods("a", "b");
var b = new Methods("a", "b");
Console.WriteLine(b==a);
Console.WriteLine(a.Equals(b) + "\n");


var c = new Methods("c", "d");
var d = new Methods("d", "d");

Console.WriteLine(c!=d);
Console.WriteLine(!c.Equals(d));