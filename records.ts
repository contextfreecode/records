/*
function main2() {
    let alice = #{ name: "Alice", hireYear: 2000 };
    // alice.hireYear = 2010;
    // console.log(yearsEmployed(alice));
    let alice2 = #{ ...alice, hireYear: 2010 };
    let alice3 = #{ ...alice, hireYear: 2000 };
    // if tuples, then alice === alice3
    // https://github.com/tc39/proposal-record-tuple#usage-in-mapsetweakmapweakset
}

// This one -> https://rickbutton.github.io/record-tuple-playground/#eyJjb250ZW50IjoibGV0IGFsaWNlID0gI3sgbmFtZTogXCJBbGljZVwiLCBoaXJlWWVhcjogMjAwMCB9O1xubGV0IGFsaWNlMiA9ICN7IC4uLmFsaWNlLCBoaXJlWWVhcjogMjAxMCB9O1xubGV0IGFsaWNlMyA9ICN7IC4uLmFsaWNlLCBoaXJlWWVhcjogMjAwMCB9O1xuY29uc29sZS5sb2coYWxpY2UgPT09IGFsaWNlMik7XG5jb25zb2xlLmxvZyhhbGljZSA9PT0gYWxpY2UzKTtcbiIsInN5bnRheCI6Imhhc2giLCJkb21Nb2RlIjpmYWxzZX0=

// https://rickbutton.github.io/record-tuple-playground/#eyJjb250ZW50IjoibGV0IGFsaWNlID0gI3sgbmFtZTogXCJBbGljZVwiLCBoaXJlWWVhcjogMjAwMCB9O1xubGV0IGFsaWNlMiA9ICN7IC4uLmFsaWNlLCBoaXJlWWVhcjogMjAxMCB9O1xubGV0IGFsaWNlMyA9ICN7IC4uLmFsaWNlLCBoaXJlWWVhcjogMjAwMCB9O1xuY29uc29sZS5sb2coYWxpY2UgPT09IGFsaWNlMik7XG5jb25zb2xlLmxvZyhhbGljZSA9PT0gYWxpY2UzKTtcbmNvbnNvbGUubG9nKGFsaWNlIDwgYWxpY2UyKTtcblxubGV0IGdyZWV0aW5ncyA9IG5ldyBNYXAoW1thbGljZSwgXCJIaSFcIl1dKTtcbmNvbnNvbGUubG9nKGdyZWV0aW5ncyk7XG5jb25zb2xlLmxvZyhncmVldGluZ3NbYWxpY2UzXSk7XG4iLCJzeW50YXgiOiJoYXNoIiwiZG9tTW9kZSI6ZmFsc2V9
// https://rickbutton.github.io/record-tuple-playground/#eyJjb250ZW50IjoibGV0IGFsaWNlID0gI3sgbmFtZTogXCJBbGljZVwiLCBoaXJlWWVhcjogMjAwMCB9O1xubGV0IGFsaWNlMiA9ICN7IC4uLmFsaWNlLCBoaXJlWWVhcjogMjAxMCB9O1xubGV0IGFsaWNlMyA9ICN7IC4uLmFsaWNlMiwgaGlyZVllYXI6IDIwMDAgfTtcbmNvbnNvbGUubG9nKGFsaWNlID09PSBhbGljZTIpO1xuY29uc29sZS5sb2coYWxpY2UgPT09IGFsaWNlMyk7XG5jb25zb2xlLmxvZyhhbGljZSA8IGFsaWNlMik7XG5cbmxldCBncmVldGluZ3MgPSBuZXcgTWFwKCk7XG5ncmVldGluZ3NbYWxpY2VdID0gXCJIaSFcIjtcbmNvbnNvbGUubG9nKGdyZWV0aW5ncyk7XG5jb25zb2xlLmxvZyhncmVldGluZ3NbYWxpY2UzXSk7XG4iLCJzeW50YXgiOiJoYXNoIiwiZG9tTW9kZSI6ZmFsc2V9

let alice = #{ name: "Alice", hireYear: 2000 };
let alice2 = #{ ...alice, hireYear: 2010 };
let alice3 = #{ ...alice, hireYear: 2000 };
console.log(alice === alice2);
console.log(alice === alice3);
console.log(alice < alice2);

let greetings = new Map([[alice, "Hi!"]]);
console.log(greetings);
console.log(greetings[alice3]);

let greetings = new Map();
greetings[alice] = "Hi!";
console.log(greetings);
console.log(greetings[alice3]);
*/

function main() {
    let alice = { name: "Alice", hireYear: 2000 } as Readonly<Employee>;
    // alice.hireYear = 2010;
    console.log(yearsEmployed(alice));
    let alice2 = { ...alice, hireYear: 2010 } as Readonly<Employee>;
    let alice3 = { ...alice, hireYear: 2000 } as Readonly<Employee>;
    // if tuples, then alice === alice3
    // https://github.com/tc39/proposal-record-tuple#usage-in-mapsetweakmapweakset
}

interface Employee {
    name: String;
    hireYear: number;
}

function yearsEmployed(employee: Employee) {
    return new Date().getUTCFullYear() - employee.hireYear;
}

interface DetailEmployee extends Employee {
    favorites: { [key: string]: string; }
}

type ReadonlyEmployee = Readonly<Employee>;

main()
