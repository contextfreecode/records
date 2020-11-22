use chrono::prelude::*;
use im::*;
use std::collections::hash_map::DefaultHasher;
use std::hash::*;

fn main() {
    let alice = Employee {
        name: "Alice",
        hire_date: Utc.ymd(2000, 1, 1),
    };
    dbg!(&alice);
    dbg!(alice.years_employed());
    let alice2 = Employee {
        hire_date: Utc.ymd(2010, 1, 1),
        ..alice
    };
    dbg!(&alice2);
    let alice3 = Employee {
        hire_date: alice.hire_date,
        ..alice2
    };
    dbg!(hash_calc(&alice));
    dbg!(hash_calc(&alice2));
    dbg!(hash_calc(&alice3));
    dbg!(alice == alice2);
    dbg!(alice == alice3);
    dbg!(alice < alice2);
    // Mutable
    let mut bob = Employee { ..alice3 };
    bob.name = "Bob";
    dbg!(bob);
    // Hash
    let detail = hashmap! {"food" => "apple"};
    let detail2 = detail.update("food", "avocado");
    let detail3 = detail.update("food", "apple");
    dbg!(&detail);
    dbg!(&detail2);
    dbg!(hash_calc(&detail));
    dbg!(hash_calc(&detail2));
    dbg!(hash_calc(&detail3));
    dbg!(detail == detail2);
    dbg!(detail == detail3);
    dbg!(detail < detail2);
    dbg!(hash_calc(&EmployeeDetail {
        employee: alice,
        detail,
    }));
    dbg!(hash_calc(&EmployeeDetail {
        employee: alice,
        detail: detail2,
    }));
    dbg!(hash_calc(&EmployeeDetail {
        employee: alice,
        detail: detail3,
    }));
    // let detail2 = {
    //     let mut clone = detail.clone();
    //     clone.insert("food", "avocado");
    //     clone
    // };
    // dbg!(&detail2);
}

// #[derive(Copy, Clone, Debug, Eq, Hash, Ord, PartialEq, PartialOrd)]
// struct EmployeeTuple<'a>(&'a str, Date<Utc>);

#[derive(Copy, Clone, Debug, Eq, Hash, Ord, PartialEq, PartialOrd)]
struct Employee<'a> {
    name: &'a str,
    hire_date: Date<Utc>,
}

impl<'a> Employee<'a> {
    fn years_employed(&self) -> i32 {
        Utc::today().year() - self.hire_date.year()
    }
}

#[derive(Clone, Debug, Eq, Hash, Ord, PartialEq, PartialOrd)]
struct EmployeeDetail<'a> {
    employee: Employee<'a>,
    detail: HashMap<&'a str, &'a str>,
}

fn hash_calc<Hashable: Hash>(hashable: &Hashable) -> u64 {
    let mut hasher = DefaultHasher::new();
    hashable.hash(&mut hasher);
    hasher.finish()
}

// fn replace<'a, Key, Value>(
//     map: &'a Map<Key, Value>,
//     items: &'a dyn IntoIterator<Item = (Key, Value), IntoIter = Iter<'a, Key, Value>>,
// ) -> &'a Map<Key, Value> {
//     let result = map.clone();
//     result.extend(items);
//     result
// }
