using System;
using System.Collections.Generic;
using static System.Console;

var alice = new Employee {
    HireDate = new (2000, 1, 1),
};
// var alice = new Employee("Alice", new (2000, 1, 1));
WriteLine(alice);
WriteLine(alice.YearsEmployed());
var alice2 = alice with {
    HireDate = new (2010, 1, 1),
};
var alice3 = alice2 with {
    HireDate = alice.HireDate,
};
WriteLine(alice == alice2);
WriteLine(alice == alice3);

var colors = new Dictionary<Employee, string> {
    {alice, "aqua"},
};
// alice.HireDate = new (2002, 2, 2);
WriteLine(colors[alice3]);

record Employee(string? Name = null, DateTime HireDate = default) {
    // public string? Name { get; init; }
    // public DateTime HireDate { get; init; }

    // TODO Validate

    public int YearsEmployed() =>
        DateTime.Now.Year - HireDate.Year;
}

// record DetailEmployee : Employee {
//     public string? Color { get; init; }
// }
