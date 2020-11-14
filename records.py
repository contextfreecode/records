from dataclasses import dataclass
from typing import NamedTuple


def main():
    pass


@dataclass
class Hi:
    first: str


class Hi2(NamedTuple):
    first: str


# a = Hi(first="Tom")
# b = Hi("Tom")
# print(a)
# print(a == b)
# print(a is b)
# # c = {a: 1}

# d = Hi2(first="Tom")
# e = Hi2("Tom")
# print(d)
# print(d == e)
# print(d is e)
# f = {d: 1}
# print(f)

main()
