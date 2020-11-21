// java --enable-preview --source 15 Records.java

import java.time.*;
import java.util.*;
import static java.lang.System.out;
import static java.util.Map.entry;

class Records {
    public static void main(String[] args) {
        var alice = new Employee("Alice", LocalDate.of(2000, 1, 1));
        var alice2 = new Employee(alice.name(), LocalDate.of(2010, 1, 1));
        var alice3 = new Employee(alice2.name(), alice.hireDate());
        out.println(alice);
        out.println(alice.hashCode());
        out.println(alice2.hashCode());
        out.println(alice3.hashCode());
        out.println(alice.equals(alice2));
        out.println(alice.equals(alice3));
        // var detail = new HashMap<>(Map.ofEntries(
        //     entry("Accept", "text/html"),
        //     entry("User-Agent", "ContextFreeDemo/0.0.1 (like Gecko ;)")
        // ));
        // var request = new DetailRequest(
        //     new Request("https://rescue.org/"),
        //     detail
        // );
        // out.println(request.hashCode());
        // out.println(request);
        // detail.put("User-Agent", "Mozilla/5.0");
        // out.println(request.hashCode());
        // out.println(request);
        // out.println(DetailRequest.class.getSuperclass());
    }
}

// Remember: https://docs.oracle.com/en/java/javase/15/docs/api/java.base/java/time/LocalDate.html#withYear(int)

record Employee(String name, LocalDate hireDate, Map<String, String> detail) {
    Employee {
        if (name == null) throw new RuntimeException("No name"); 
        if (hireDate == null) throw new RuntimeException("No hireDate"); 
        if (detail == null) detail = Collections.emptyMap();
    }

    Employee(String name, LocalDate hireDate) {
        this(name, hireDate, null);
    }

    public int yearsEmployed() {
        return LocalDate.now().getYear() - hireDate.getYear();
    }
}

record DetailEmployee(Employee employee, Map<String, String> detail) {}
