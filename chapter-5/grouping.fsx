let myList = [ 1; 2; 3; 4; 5; 7; 6; 5; 4; 3 ]

// How many of each item?
// int list -> (int * int list) list
let gbResult = myList |> List.groupBy (fun x -> x)

// List of unique items
// int list -> int list
let unique items =
    items
    |> List.groupBy (fun x -> x)
    |> List.map (fun (x, _) -> x)

let myUnique = unique myList

let uniqueIdiomatic items =
    items |> List.distinct

let myUniqueIdiomatic = uniqueIdiomatic myList

let uniqueSet items =
    items |> Set.ofList

let setResult = uniqueSet myList
