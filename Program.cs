using System;

var person = new Person { FirstName = "Hi", LastName = "There" };
Console.WriteLine($"Hello to {person}");

record Person {
    public string FirstName { get; init; }
    public string LastName { get; init; }
}
