// let calculate i =
//     if i % 3 = 0 && i % 5 = 0 then "FizzBuzz"
//     elif i % 3 = 0 then "Fizz"
//     elif i % 5 = 0 then "Buzz"
//     else i |> string
//
// [ 1..15 ]
// |> List.map calculate
// |> List.iter (printfn "%s")


let calculateMatching i =
    match (i % 3, i % 5) with
    | (0, 0) -> "FizzBuzz"
    | (0, _) -> "Fizz"
    | (_, 0) -> "Buzz"
    | _ -> i |> string

[ 1..15 ]
|> List.map calculateMatching
|> List.iter (printfn "%s")

let calculateMatching2 i =
    match (i % 3 = 0, i % 5 = 0) with
    | (true, true) -> "FizzBuzz"
    | (true, _) -> "Fizz"
    | (_, true) -> "Buzz"
    | _ -> i |> string

[ 1..15 ]
|> List.map calculateMatching2
|> List.iter (printfn "%s")


// With active pattern matching

// int -> int -> unit option
let (|IsDivisibleBy|_|) divisor n =
    if n % divisor = 0 then Some() else None

let calculateActivePattern i =
    match i with
    | IsDivisibleBy 3 & IsDivisibleBy 5 & IsDivisibleBy 7 -> "FizzBuzzBazz"
    | IsDivisibleBy 3 & IsDivisibleBy 5 -> "FizzBuzz"
    | IsDivisibleBy 3 & IsDivisibleBy 7 -> "FizzBazz"
    | IsDivisibleBy 5 & IsDivisibleBy 7 -> "BuzzBazz"
    | IsDivisibleBy 3 -> "Fizz"
    | IsDivisibleBy 5 -> "Buzz"
    | IsDivisibleBy 7 -> "Bazz"
    | _ -> i |> string
// Lots of typing, potentially error prone


// less readable, but less error prone
// let calcuate n =
//     [ (3, "Fizz"); (5, "Buzz"); (7, "Bazz") ]
//     |> List.map (fun (divisor, result) -> if n % divisor = 0 then result else "")
//     |> List.reduce (+)
//     |> fun input -> if input = "" then string n else input
//
// [ 1..15 ]
// |> List.map calculate
// |> List.iter (printfn "%s")



let calculate mapping n =
    mapping
    |> List.map (fun (divisor, result) -> if n % divisor = 0 then result else "")
    |> List.reduce (+)
    |> fun input -> if input = "" then string n else input

[ 1..15 ]
|> List.map (calculate [ (3, "Fizz"); (5, "Buzz") ])
|> List.iter (printfn "%s")
