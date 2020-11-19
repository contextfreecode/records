// java --enable-preview --source 15 Records.java

import java.util.*;
import static java.lang.System.out;
import static java.util.Map.entry;

class Records {
    public static void main(String[] args) {
        var headers = new HashMap<>(Map.ofEntries(
            entry("Accept", "text/html"),
            entry("User-Agent", "ContextFreeDemo/0.0.1 (like Gecko ;)")
        ));
        var request = new DetailRequest(
            new Request("https://rescue.org/"),
            headers
        );
        out.println(request.hashCode());
        out.println(request);
        headers.put("User-Agent", "Mozilla/5.0");
        out.println(request.hashCode());
        out.println(request);
        out.println(DetailRequest.class.getSuperclass());
    }
}

record Request(String url, Double timeout, Map<String, String> headers) {
    Request {
        if (url.indexOf(':') < 0) throw new RuntimeException("No scheme"); 
    }

    Request(String url) {
        this(url, (Map<String, String>)null);
    }

    Request(String url, Double timeout) {
        this(url, timeout, Collections.emptyMap());
    }

    Request(String url, Map<String, String> headers) {
        this(url, null, headers);
    }

    String scheme() {
        return url.substring(0, url.indexOf(':'));
    }
}

record DetailRequest(Request request, Map<String, String> headers) {}
