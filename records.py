from dataclasses import dataclass


@dataclass
class Hi:
    first: str


a = Hi(first="Tom")
b = Hi(first="Tom")
print(a == b)
print(a is b)
