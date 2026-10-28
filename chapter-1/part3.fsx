type RegisteredCustomer = { Id: string }

type UnregisteredCustomer = { Id: string }

type Customer =
    | Eligible of RegisteredCustomer
    | Registered of RegisteredCustomer
    | Guest of UnregisteredCustomer

let calculateTotal customer spend =
    let discount =
        match customer with
        | Eligible _ when spend >= 100.0M -> spend * 0.1M
        | _ -> 0.0M

    spend - discount


let john = Eligible { Id = "John" }
let mary = Eligible { Id = "Mary" }
let richard = Registered { Id = "Richard" }
let sarah = Guest { Id = "sarah" }

// a' -> a' -> bool (' means generic)
let areEqual expected actual = expected = actual

let assertJohn = areEqual 90.0M (calculateTotal john 100.0M)
let assertMary = areEqual 99.0M (calculateTotal mary 99.0M)
let assertRichard = areEqual 100.0M (calculateTotal richard 100.0M)
let assertSarah = areEqual 100.0M (calculateTotal sarah 100.0M)
