// DateTime parsing

open System

let (|ValidDate|_|) (input:string) =
    match DateTime.TryParse input with
    | true, value -> Some value
    | false, _ -> None

// string -> DateTime option
let parse (input: string) =
    match input with
    | ValidDate dt -> printfn "%A" dt
    | _ -> printfn $"'%s{input}' is not a valid date"


parse "2019-12-20"
parse "Hello"


