import java.time.*;
import java.util.*;

import static java.lang.System.out;

class Records {
    public static void main(String[] args) {
        var alice = new Employee("Alice", LocalDate.of(2000, 1, 1));
        var alice2 = new Employee(
            alice.name(), alice.hireDate().withYear(2010)
        );
        var alice3 = new Employee(alice2.name(), alice.hireDate());

        out.println(alice);
        out.println(alice2);
        out.println(alice3);

        out.println(alice.hashCode());
        out.println(alice2.hashCode());
        out.println(alice3.hashCode());

        out.println(alice.equals(alice2));
        out.println(alice.equals(alice3));
        // out.println(alice.compareTo(alice2));

        // out.println(Employee.class.getSuperclass());
    }
}

record Employee(String name, LocalDate hireDate, String color) {
    Employee {
        if (name == null) throw new RuntimeException("No name"); 
        if (hireDate == null) throw new RuntimeException("No hireDate"); 
    }

    Employee(String name, LocalDate hireDate) {
        this(name, hireDate, null);
    }

    public int yearsEmployed() {
        return LocalDate.now().getYear() - hireDate.getYear();
    }
}

record DetailEmployee(Employee employee, String color) {}
