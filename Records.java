// java --enable-preview --source 15 Records.java

import java.util.*;
import static java.util.Map.entry;

class Records {
    public static void main(String[] args) {
        var headers = new HashMap<>(Map.ofEntries(
            entry("Accept", "text/html,application/whatever"),
            entry("User-Agent", "ContextFreeDemo/0.0.1 (like Gecko ;)")
        ));
        var request = new Request("https://rescue.org/", headers);
        System.out.println(request.hashCode());
        System.out.println(request);
        headers.put("User-Agent", "Mozilla/5.0");
        System.out.println(request.hashCode());
        System.out.println(request);
    }
}

record Request(String url, Map<String, String> headers) {
    Request {
        if (url.indexOf(':') < 0) throw new RuntimeException("No scheme"); 
    }

    String scheme() {
        return url.substring(0, url.indexOf(':'));
    }
}
