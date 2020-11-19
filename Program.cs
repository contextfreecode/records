﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json;
using static System.Console;

#pragma warning disable CS0162, CS8321
void LoadTest() {
    var count = 100000000;
    if (true) {
        var structs = new RequestStruct[count];
        for (int i = 0; i < structs.Length; i += 1) {
            structs[i].Url = "https://rescue.org/";
        }
    } else {
        var records = new Request[count];
        for (int i = 0; i < records.Length; i += 1) {
            records[i] = new Request { TimeoutSeconds = 30.0 };
        }
    }
    Console.ReadLine();
}
#pragma warning restore CS0162, CS8321

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
WriteLine(request.GetHashCode());
WriteLine(JsonSerializer.Serialize(request));
// Change headers.
headers["User-Agent"] = "Mozilla/5.0";
WriteLine(request.GetHashCode());
WriteLine(JsonSerializer.Serialize(request));
// Create new record.
var timeoutRequest = request with { TimeoutSeconds = 30.0 };
WriteLine(timeoutRequest.GetHashCode());
WriteLine(JsonSerializer.Serialize(timeoutRequest));
WriteLine(request == timeoutRequest);
// Change existing record.
request.TimeoutSeconds = 30.0;
WriteLine(request.GetHashCode());
WriteLine(JsonSerializer.Serialize(request));
WriteLine(request == timeoutRequest);
WriteLine(object.ReferenceEquals(request, timeoutRequest));

WriteLine(typeof(Request).BaseType);
WriteLine(new RequestStruct { Url = "https://rescue.org/" });

record Request(
    string? Url = null,
    double? TimeoutSeconds = null
) {
    public string Url { get; init; } = Url!;
    public double? TimeoutSeconds { get; set; } = TimeoutSeconds;

    public void Validate() {
        if (!Url.Contains(':')) throw new ArgumentException("No scheme");
        // WriteLine(request);
    }

    public string Scheme() => Url.Substring(0, Url.IndexOf(':'));
}

record DetailRequest(
    string? Url = null,
    double? TimeoutSeconds = null,
    IDictionary<string, string>? Headers = null
) : Request(Url, TimeoutSeconds) {
    public IDictionary<string, string>? Headers { get; init; } = Headers!;
}

struct RequestStruct {
    public string Url { get; set; }
    public double? TimeoutSeconds { get; init; }

    public void Validate() {
        if (!Url.Contains(':')) throw new ArgumentException("No scheme");
        // WriteLine(request);
    }

    public string Scheme() => Url.Substring(0, Url.IndexOf(':'));
}

record Square {
    public char Row { get; init; }
    public int Col { get; init; }
}
