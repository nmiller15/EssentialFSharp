let mapping = [ (3, "Fizz"); (5, "Buzz"); (7, "Bazz") ]

let fizzBuzz initialMapping n =
    let rec loop mapping acc =
        match mapping with
        | [] -> if acc = "" then string n else acc
        | head :: tail ->
            let value =
                head
                |> (fun (div, msg) -> if n % div = 0 then msg else "")

            loop tail (acc + value)

    loop initialMapping ""

[ 1..105 ]
|> List.map (fizzBuzz mapping)
|> List.iter (printfn "%s")


let fizzBuzzFold n =
    mapping
    |> List.fold
        (fun acc (div, msg) ->
            match (if n % div = 0 then msg else "") with
            | "" -> acc
            | s -> if acc = string n then s else acc + s)
        (string n)
