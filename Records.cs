﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using static System.Console;

#pragma warning disable CS0162, CS8321
void LoadTest() {
    var count = 100000000;
    if (false) {
        var structs = new EmployeeStruct[count];
        for (int i = 0; i < structs.Length; i += 1) {
            structs[i] = new EmployeeStruct { Name = "Betty" };
        }
    } else {
        var records = new Employee[count];
        for (int i = 0; i < records.Length; i += 1) {
            records[i] = new Employee { Name = "Betty" };
        }
    }
    WriteLine("Done!");
    ReadLine();
}

void ExploreRecords() {
    // var alice = new Employee("alice", new (2000, 1, 1));
    var alice = new Employee {
        Name = "Alice",
        HireDate = new (2000, 1, 1),
    };
    alice.Validate();
    // alice.Name = "Betty";
    WriteLine(alice);
    WriteLine(alice.YearsEmployed());
    // WriteLine(typeof(Employee).BaseType);

    var alice2 = alice with { HireDate = new (2010, 1, 1) };
    var alice3 = alice2 with { HireDate = alice.HireDate };

    WriteLine(alice.GetHashCode());
    WriteLine(alice2.GetHashCode());
    WriteLine(alice3.GetHashCode());

    WriteLine(alice == alice2);
    WriteLine(alice == alice3);
    // WriteLine(alice < alice2);

    // var greetings = new Dictionary<Employee, String> {
    //     {alice, "Hi!"},
    // };
    // WriteLine(greetings[alice3]);
}
#pragma warning restore CS0162, CS8321

ExploreRecords();
// LoadTest();

// record Employee(string Name, DateTime HireDate);
record Employee(
    string? Name = default,
    DateTime HireDate = default
    // Box<DateTime>? HireDate = default
) {
    // public string Name { get; init; }  // = Name!;
    // public DateTime HireDate { get; init; } = HireDate;
    // // public Box<DateTime> HireDate { get; init; } = HireDate!;

    public void Validate() {
        if (Name is null) throw new ArgumentException("Name missing");
        if (HireDate == default) {
            throw new ArgumentException("HireDate missing");
        }
    }

    public int YearsEmployed() => DateTime.Now.Year - HireDate.Year;
    // public int YearsEmployed() => DateTime.Now.Year - HireDate.Value.Year;
}

record DetailEmployee(
    string? Name = default,
    DateTime HireDate = default,
    IReadOnlyDictionary<string, string>? Favorites = default
) : Employee(Name, HireDate) {
    public IReadOnlyDictionary<string, string>? Favorites { get; init; } =
        Favorites ?? ImmutableDictionary.Create<string, string>();
}

struct EmployeeStruct {
    public string Name { get; init; }
    public DateTime HireDate { get; init; }
}

record Box<ValueType>(ValueType Value) where ValueType : struct {
    public static implicit operator Box<ValueType>(ValueType Value)
        => new Box<ValueType>(Value);

    public override string ToString() => Value.ToString()!;
}
