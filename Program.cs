using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json;

var headers = new Dictionary<string, string>{
    {"Accept", "text/html,application/whatever"},
    {"User-Agent", "ContextFreeDemo/0.0.1 (like Gecko ;)"},
// }.ToImmutableDictionary();
};
var request = new DetailRequest {
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
var DetailRequest = request with { TimeoutSeconds = 30.0 };
Console.WriteLine(DetailRequest.GetHashCode());
Console.WriteLine(JsonSerializer.Serialize(DetailRequest));
Console.WriteLine(request == DetailRequest);
// Change existing record.
request.TimeoutSeconds = 30.0;
Console.WriteLine(request.GetHashCode());
Console.WriteLine(JsonSerializer.Serialize(request));
Console.WriteLine(request == DetailRequest);
Console.WriteLine(object.ReferenceEquals(request, DetailRequest));

record Request(
    string? Url = null,
    double? TimeoutSeconds = null
) {
    public string Url { get; init; } = null!;
    public double? TimeoutSeconds { get; set; }

    public void Validate() {
        if (!Url.Contains(':')) throw new ArgumentException("No scheme");
        // Console.WriteLine(request);
    }

    public string Scheme() => Url.Substring(0, Url.IndexOf(':'));
}

record DetailRequest(
    string? Url = null,
    double? TimeoutSeconds = null,
    IDictionary<string, string>? Headers = null
) : Request(Url, TimeoutSeconds) {
    public IDictionary<string, string>? Headers { get; init; } = null!;
}
