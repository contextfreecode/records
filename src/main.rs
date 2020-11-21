use chrono::prelude::*;

fn main() {
    let alice = Employee {
        name: "Alice",
        hire_date: Utc.ymd(2000, 1, 1),
    };
    dbg!(&alice);
    dbg!(alice.years_employed());
    // let other_alice = Employee {
    //     hire_year: 2010,
    //     ..alice
    // };
    // dbg!(&other_alice);
}

#[derive(Debug)]
struct Employee<'a> {
    name: &'a str,
    hire_date: Date<Utc>,
}

impl<'a> Employee<'a> {
    fn years_employed(&self) -> i32 {
        Utc::today().year() - self.hire_date.year()
    }
}
