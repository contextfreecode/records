from dataclasses import dataclass, field, replace
from datetime import date
from typing import Mapping, NamedTuple, Optional


# TODO(@tjp): Update. Try positional!


def main():
    # alice = Employee("Alice", date(2000, 1, 1))
    alice = Employee(name="Alice", hire_date=date(2000, 1, 1))
    print(alice)
    alice2 = replace(alice, hire_date=date(2010, 1, 1))
    print(alice2)
    alice3 = replace(alice2, hire_date=alice.hire_date)
    print(alice3)
    print(hash(alice))
    print(hash(alice2))
    print(hash(alice3))
    print(alice == alice2)
    print(alice == alice3)
    print(alice < alice2)
    favorites = {"color": "aqua", "food": "apple"}
    favorites2 = {**favorites, "food": "avocado"}
    favorites3 = {**favorites2, "food": favorites["food"]}
    print(favorites)
    print(favorites2)
    print(favorites == favorites2)
    print(favorites == favorites3)
    # print(favorites < favorites2)
    # print(hash(favorites))


@dataclass(frozen=True, order=True)
class Employee:
    name: str
    hire_date: date

    def __post_init__(self):
        assert self.name is not None
        assert self.hire_date is not None

    def years_employed(self):
        return date.today().year - self.hire_date.year


@dataclass(frozen=True, order=True)
class DetailEmployee(Employee):
    favorites: Mapping[str, str] = field(default_factory=dict)


class EmployeeTuple(NamedTuple):
    url: str
    timeout_seconds: Optional[float] = None

    def scheme(self):
        return self.url[0:self.url.index(":")]


class DetailEmployeeTuple(EmployeeTuple):
    favorites: Mapping[str, str]


main()
