use chrono::prelude::*;
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
    dbg!(hash(&alice));
    dbg!(hash(&alice2));
    dbg!(hash(&alice3));
    dbg!(alice == alice2);
    dbg!(alice == alice3);
}

// #[derive(Debug, Eq, Hash, PartialEq)]
// struct EmployeeTuple<'a>(&'a str, Date<Utc>);

#[derive(Debug, Eq, Hash, PartialEq)]
struct Employee<'a> {
    name: &'a str,
    hire_date: Date<Utc>,
}

impl<'a> Employee<'a> {
    fn years_employed(&self) -> i32 {
        Utc::today().year() - self.hire_date.year()
    }
}

fn hash<Hashable: Hash>(hashable: &Hashable) -> u64 {
    let mut hasher = DefaultHasher::new();
    hashable.hash(&mut hasher);
    hasher.finish()
}
