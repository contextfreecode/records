use chrono::prelude::*;
use std::collections::hash_map::DefaultHasher;
use std::hash::*;

fn main() {
    let alice = Employee {
        name: "Alice", hire_date: Utc.ymd(2000, 1, 1),
    };
    let alice2 = Employee {
        hire_date: Utc.ymd(2010, 1, 1), ..alice
    };
    let alice3 = Employee {
        hire_date: alice.hire_date, ..alice2
    };

    dbg!(&alice);
    dbg!(&alice2);
    dbg!(&alice3);

    dbg!(hash_calc(&alice));
    dbg!(hash_calc(&alice2));
    dbg!(hash_calc(&alice3));

    dbg!(alice == alice2);
    dbg!(alice == alice3);
    dbg!(alice < alice2);

    // // Mutable
    // let mut betty = Employee { ..alice3 };
    // betty.name = "Betty";
    // dbg!(betty);
}

// #[derive(Copy, Clone, Debug, Eq, Hash, Ord, PartialEq, PartialOrd)]
// struct EmployeeTuple<'a>(&'a str, Date<Utc>);

#[derive(Copy, Clone, Debug, Eq, Hash, Ord, PartialEq, PartialOrd)]
pub struct Employee<'a> {
    name: &'a str,
    hire_date: Date<Utc>,
}

impl<'a> Employee<'a> {
    pub fn years_employed(&self) -> i32 {
        Utc::today().year() - self.hire_date.year()
    }
}

#[derive(Clone, Debug, Eq, Hash, Ord, PartialEq, PartialOrd)]
struct DetailEmployee<'a> {
    employee: Employee<'a>,
    color: &'a str,
}

fn hash_calc<Hashable: Hash>(hashable: &Hashable) -> u64 {
    let mut hasher = DefaultHasher::new();
    hashable.hash(&mut hasher);
    hasher.finish()
}
