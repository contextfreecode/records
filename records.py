from dataclasses import dataclass, field, replace
from datetime import date
from typing import Mapping, NamedTuple, Optional, TypedDict


def main():
    # alice = Employee("Alice", date(2000, 1, 1))
    alice = Employee(name="Alice", hire_date=date(2000, 1, 1))
    alice2 = replace(alice, hire_date=date(2010, 1, 1))
    alice3 = replace(alice2, hire_date=alice.hire_date)
    # alice2 = alice._replace(hire_date=date(2010, 1, 1))
    # alice3 = alice2._replace(hire_date=alice.hire_date)
    # alice2 = {**alice, "hire_date": date(2010, 1, 1)}
    # alice3 = alice2 | {"hire_date": alice["hire_date"]}

    print(alice)
    print(alice2)
    print(alice3)

    print(hash(alice))
    print(hash(alice2))
    print(hash(alice3))

    print(alice == alice2)
    print(alice == alice3)
    print(alice < alice2)

    # print(DetailEmployee(**alice.__dict__, favorites={}))


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


main()
