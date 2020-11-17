using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json;

var headers = new Dictionary<string, string>{
    {"Accept", "text/html,application/whatever"},
    {"User-Agent", "ContextFreeDemo/0.0.1 (like Gecko ;)"},
// }.ToImmutableDictionary();
};
var request = new TimeoutRequest {
    Url = "https://rescue.org/",
    Headers = headers,
};
request.Validate();
Console.WriteLine(request.GetHashCode());
Console.WriteLine(JsonSerializer.Serialize(request));
// Change headers.
headers["User-Agent"] = "Mozilla/5.0";
Console.WriteLine(request.GetHashCode());
Console.WriteLine(JsonSerializer.Serialize(request));
// Create new record.
var timeoutRequest = request with { TimeoutSeconds = 30.0 };
Console.WriteLine(timeoutRequest.GetHashCode());
Console.WriteLine(JsonSerializer.Serialize(timeoutRequest));
Console.WriteLine(request == timeoutRequest);
// Change existing record.
request.TimeoutSeconds = 30.0;
Console.WriteLine(request.GetHashCode());
Console.WriteLine(JsonSerializer.Serialize(request));
Console.WriteLine(request == timeoutRequest);
Console.WriteLine(object.ReferenceEquals(request, timeoutRequest));

record Request(
    string? Url = null,
    IDictionary<string, string>? Headers = null
) {
    public string Url { get; init; } = null!;
    public IDictionary<string, string>? Headers { get; init; } = null!;

    public void Validate() {
        if (!Url.Contains(':')) throw new ArgumentException("No scheme");
        // Console.WriteLine(request);
    }

    public string Scheme() => Url.Substring(0, Url.IndexOf(':'));
}

record TimeoutRequest(
    string? Url = null,
    IDictionary<string, string>? Headers = null,
    double? TimeoutSeconds = null
) : Request(Url, Headers) {
    public double? TimeoutSeconds { get; set; }
}
