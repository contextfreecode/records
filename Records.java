// java --enable-preview --source 15 Records.java

import java.time.*;
import java.util.*;
import static java.lang.System.out;
import static java.util.Map.entry;

class Records {
    public static void main(String[] args) {
        // var headers = new HashMap<>(Map.ofEntries(
        //     entry("Accept", "text/html"),
        //     entry("User-Agent", "ContextFreeDemo/0.0.1 (like Gecko ;)")
        // ));
        // var request = new DetailRequest(
        //     new Request("https://rescue.org/"),
        //     headers
        // );
        // out.println(request.hashCode());
        // out.println(request);
        // headers.put("User-Agent", "Mozilla/5.0");
        // out.println(request.hashCode());
        // out.println(request);
        // out.println(DetailRequest.class.getSuperclass());
    }
}

record Employee(String name, LocalDate hireDate, Map<String, String> headers) {
    Employee {
        if (name == null) throw new RuntimeException("No name"); 
        if (hireDate == null) throw new RuntimeException("No hireDate"); 
        if (headers == null) headers = Collections.emptyMap();
    }

    Employee(String name, LocalDate hireDate) {
        this(name, hireDate, null);
    }

    public int yearsEmployed() {
        return LocalDate.now().getYear() - hireDate.getYear();
    }
}

record DetailEmployee(Employee employee, Map<String, String> detail) {}
