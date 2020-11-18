from dataclasses import dataclass, field, replace
from typing import Mapping, NamedTuple, Optional


def main():
    headers = {
        "Accept": "text/html",
        "User-Agent": "ContextFreeDemo/0.0.1 (like Gecko ;)",
    }
    request = DetailRequest(url="https://rescue.org/", headers=headers)
    print(request)
    print(request.scheme())
    # request.timeout_seconds = 30.0
    # print(hash(request))
    timeout_request = replace(request, timeout_seconds=30.0)
    print(timeout_request)
    # Tuple.
    request_tuple = RequestTuple(url="https://rescue.org/")
    # request_tuple = DetailRequestTuple(url="https://rescue.org/", headers=headers)
    print(request_tuple)
    print(request_tuple._replace(url="other:there"))
    print(request_tuple.scheme())


@dataclass(frozen=True)
class Request:
    url: str
    timeout_seconds: Optional[float] = None

    def __post_init__(self):
        assert ":" in self.url

    def scheme(self):
        return self.url[0:self.url.index(":")]


@dataclass(frozen=True)
class DetailRequest(Request):
    headers: Mapping[str, str] = field(default_factory=dict)


class RequestTuple(NamedTuple):
    url: str
    timeout_seconds: Optional[float] = None

    def scheme(self):
        return self.url[0:self.url.index(":")]


class DetailRequestTuple(RequestTuple):
    headers: Mapping[str, str]


main()
