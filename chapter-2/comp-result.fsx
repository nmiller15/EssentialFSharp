open System

type Customer =
    { Id: int
      IsVip: bool
      Credit: decimal }

// Customer -> Result<(Customer * decimal), exn>
let getPurchases customer =
    try
        // Imagine this function is fetching data from a Database
        let purchases =
            if customer.Id % 2 = 0 then
                (customer, 120M)
            else
                (customer, 80M)

        Ok purchases
    with ex ->
        Error ex

// Cusotmer * decimal -> Customer
let tryPromoteToVip purchases =
    let customer, amount = purchases

    if amount > 100M then
        { customer with IsVip = true }
    else
        customer

// Customer -> Result<Customer, exn>
let increaseCreditIfVip customer =
    try
        // Imagine this function could cause an exception
        let increase = if customer.IsVip then 100.0M else 50.0M

        Ok
            { customer with
                Credit = customer.Credit + increase }
    with ex ->
        Error ex

// Specific map function
// let map
//     (tryPromoteToVip: Customer * decimal -> Customer)
//     (result: Result<Customer * decimal, exn>)
//     : Result<Customer, exn> =
//     match result with
//     | Ok x -> Ok(tryPromoteToVip x)
//     | Error ex -> Error ex

// Generalized map function
// ('a -> 'b) -> Result<'a, 'c> -> Result<'b, 'c>
// let map (f: 'a -> 'b) (result: Result<'a, 'c>) : Result<'b, 'c> =
//     match result with
//     | Ok x -> Ok(f x)
//     | Error ex -> Error ex

// Implicit generalized map function
// ('a -> 'b) -> Result<'a, 'c> -> Result<'b, 'c>
let map f result =
    match result with
    | Ok x -> Ok(f x)
    | Error ex -> Error ex


// Specific bind function
// (Customer -> Result<Customer, exn>) -> Result<Customer, exn> -> Result<Customer, exn>
// let bind
//     (increaseCreditIfVip: Customer -> Result<Customer, exn>)
//     (result: Result<Customer, exn>)
//     : Result<Customer, exn> =
//     match result with
//     | Ok x -> increaseCreditIfVip x
//     | Error ex -> Error ex

// Generic bind function
// ('a -> Result<'b, 'c>) -> Result<'a, 'c> -> Result<'b, 'c>
// let bind (f: 'a -> Result<'b, 'c>) (result: Result<'a, 'c>) : Result<'b, 'c> =
//     match result with
//     | Ok x -> f x
//     | Error ex -> Error ex

// Implicit generic bind function
// ('a -> Result<'b, 'c>) -> Result<'a, 'c> -> Result<'b, 'c>
let bind f result =
    match result with
    | Ok x -> f x
    | Error ex -> Error ex



// Original
// let upgradeCustomer customer =
//     customer
//     |> getPurchases
//     |> fun result ->
//         match result with
//         | Ok x -> Ok(tryPromoteToVip x)
//         | Error ex -> Error ex
//     |> fun result ->
//         match result with
//         | Ok x -> increaseCreditIfVip x
//         | Error ex -> Error ex

// Simplified
// let upgradeCustomer customer =
//     customer
//     |> getPurchases
//     |> function
//         | Ok x -> Ok(tryPromoteToVip x)
//         | Error ex -> Error ex
//     |> function
//         | Ok x -> increaseCreditIfVip x
//         | Error ex -> Error ex

// Simplified with map
// let upgradeCustomer customer =
//     customer
//     |> getPurchases
//     |> map tryPromoteToVip // Result needs unpacked AND passed in a new Result
//     |> function // Result needs unpacked, function already returns a Result
//         | Ok x -> increaseCreditIfVip x
//         | Error ex -> Error ex

// Simplified with bind
let upgradeCustomer customer =
    customer
    |> getPurchases
    |> map tryPromoteToVip // Result needs unpacked AND passed in a new Result
    |> bind increaseCreditIfVip // Result needs unpacked, function already returns a Result

let upgradeCustomerProcedural customer =
    let purchaseResult = getPurchases customer
    let promotedResult = map tryPromoteToVip purchaseResult
    let increaseResult = bind increaseCreditIfVip promotedResult
    increaseResult


let upgradeCustomerBuiltin customer =
    customer
    |> getPurchases
    |> Result.map tryPromoteToVip
    |> Result.bind increaseCreditIfVip


let customerVIP = { Id = 1; IsVip = true; Credit = 0M }
let customerSTD = { Id = 2; IsVip = false; Credit = 100M }

let assertVIP =
    upgradeCustomer customerVIP = Ok { Id = 1; IsVip = true; Credit = 100M }

let assertSTDtoVIP =
    upgradeCustomer customerSTD = Ok { Id = 2; IsVip = true; Credit = 200M }

let assertSTD =
    upgradeCustomer
        { customerSTD with
            Id = 3
            Credit = 50.0M } = Ok { Id = 3; IsVip = false; Credit = 100M }
