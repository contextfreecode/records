from dataclasses import dataclass, replace
from typing import Mapping, NamedTuple, Optional


def main():
    headers = {
        "Accept": "text/html,application/whatever",
        "User-Agent": "ContextFreeDemo/0.0.1 (like Gecko ;)",
    }
    request = TimeoutRequest(url="https://rescue.org/", headers=headers)
    print(request)
    print(request.scheme())
    # request.timeout_seconds = 30.0
    # print(hash(request))
    timeout_request = replace(request, timeout_seconds=30.0)
    print(timeout_request)
    # Tuple.
    request_tuple = RequestTuple(url="https://rescue.org/", headers=headers)
    # request_tuple = TimeoutRequestTuple(url="https://rescue.org/", headers=headers, timeout_seconds=30.0)
    print(request_tuple)
    print(request_tuple._replace(url="other:there"))


@dataclass(frozen=True)
class Request:
    url: str
    headers: Mapping[str, str]

    def __post_init__(self):
        assert ":" in self.url

    def scheme(self):
        return self.url[0:self.url.index(":")]


@dataclass(frozen=True)
class TimeoutRequest(Request):
    timeout_seconds: Optional[float] = None


class RequestTuple(NamedTuple):
    url: str
    headers: Mapping[str, str]


class TimeoutRequestTuple(RequestTuple):
    timeout_seconds: Optional[float] = None


main()
