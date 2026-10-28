type CustomerType =
    | Registered of IsEligible: bool
    | Guest

type Customer = { Id: string; Type: CustomerType }

let calculateTotal customer spend =
    let discount =
        match customer.Type with
        | Registered(IsEligible = true) when spend >= 100.0M -> spend * 0.1M
        | _ -> 0.0M

    spend - discount


let john =
    { Id = "John"
      Type = Registered(IsEligible = true) }

let mary =
    { Id = "Mary"
      Type = Registered(IsEligible = true) }

let richard =
    { Id = "Richard"
      Type = Registered(IsEligible = false) }

let sarah = { Id = "sarah"; Type = Guest }

// a' -> a' -> bool (' means generic)
let areEqual expected actual = expected = actual

let assertJohn = areEqual 90.0M (calculateTotal john 100.0M)
let assertMary = areEqual 99.0M (calculateTotal mary 99.0M)
let assertRichard = areEqual 100.0M (calculateTotal richard 100.0M)
let assertSarah = areEqual 100.0M (calculateTotal sarah 100.0M)
