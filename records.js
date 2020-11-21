function main() {
    let alice = #{ name: "Alice", hireYear: 2000 };
    let alice2 = #{ ...alice, hireYear: 2010 };
    let aliceDetail = #{ ...alice, detail: #{ food: "apple" } };
}
