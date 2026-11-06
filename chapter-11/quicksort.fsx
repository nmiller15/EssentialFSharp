let rec qsort input =
    match input with
    | [] -> []
    | head :: tail ->
        let smaller, larger = List.partition (fun n -> head >= n) tail
        List.concat [ qsort smaller; [ head ]; qsort larger ]

[ 5; 9; 5; 2; 7; 9; 1; 1; 3; 5 ]
|> qsort
|> printfn "%A"


// List.partition: using a predicate, divide a list into two lists, one that satisfies the predicate and one that does not.
// List.concat:    flatten a list of lists into a single list.
