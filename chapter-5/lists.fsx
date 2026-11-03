let items = [ (1, 0.25M); (5, 0.25M); (1, 2.25M); (1, 125M); (7, 10.9M) ]

// let sum items =
//     items
//     |> List.map (fun (q, p) -> decimal q * p)
//     |> List.sum

let sum items =
    items
    |> List.sumBy (fun (q, p) -> decimal q * p)

[ 1..10 ]
|> List.fold (fun acc v -> acc + v) 0

// folder           -> initial value -> input list -> output value
// ('a -> 'b -> 'a) -> 'a            -> 'b list    -> 'a

// or
[ 1..10 ] |> List.fold (+) 0


let getTotal items =
    items
    |> List.fold (fun acc (q, p) -> acc + decimal q * p) 0M

let total = getTotal items


let getTotal2 items =
    (0M, items)
    ||> List.fold (fun acc (q, p) -> acc + decimal q * p)

let total2 = getTotal2 items
