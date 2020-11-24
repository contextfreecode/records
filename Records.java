// java --enable-preview --source 15 Records.java

import java.time.*;
import java.util.*;
import java.util.Map.Entry;
import java.util.function.*;
import java.util.stream.*;

import static java.lang.System.out;
import static java.util.Map.entry;

class Records {
    public static void main(String[] args) {
        // exploreRecords();
        exploreMaps();
    }

    static void exploreRecords() {
        var alice = new Employee("Alice", LocalDate.of(2000, 1, 1));
        var alice2 = new Employee(
            alice.name(), alice.hireDate().withYear(2010)
        );
        var alice3 = new Employee(alice2.name(), alice.hireDate());
        out.println(alice);
        out.println(alice.hashCode());
        out.println(alice2.hashCode());
        out.println(alice3.hashCode());
        out.println(alice.equals(alice2));
        out.println(alice.equals(alice3));
    }

    static void exploreMaps() {
        var favorites = new HashMap<>(Map.ofEntries(
            entry("food", "apple"),
            entry("color", "aqua")
        ));
        var favorites2 = new HashMap<>(favorites);
        favorites2.put("food", "avocado");
        // var favorites2 = ((Supplier<Map<String, String>>)() -> {
        //     var result = new HashMap<>(favorites);
        //     result.put("food", "avocado");
        //     return result;
        // }).get();
        var favorites3 = Stream
            .of(favorites2, Map.ofEntries(entry("food", favorites.get("food"))))
            .flatMap(map -> map.entrySet().stream())
            .collect(Collectors.toMap(
                Entry::getKey, Entry::getValue,
                (oldValue, newValue) -> newValue
            ));
        out.println(favorites);
        out.println(favorites2);
        out.println(favorites3);
        out.println(favorites.hashCode());
        out.println(favorites2.hashCode());
        out.println(favorites3.hashCode());
        out.println(favorites.equals(favorites2));
        out.println(favorites.equals(favorites3));
        out.println(favorites == favorites3);
    }
}

record Employee(String name, LocalDate hireDate, Map<String, String> favorites) {
    Employee {
        if (name == null) throw new RuntimeException("No name"); 
        if (hireDate == null) throw new RuntimeException("No hireDate"); 
        if (favorites == null) favorites = Collections.emptyMap();
    }

    Employee(String name, LocalDate hireDate) {
        this(name, hireDate, null);
    }

    public int yearsEmployed() {
        return LocalDate.now().getYear() - hireDate.getYear();
    }
}

record DetailEmployee(Employee employee, Map<String, String> favorites) {}
