open System

// string -> Option<DateTime>
let tryParseDateTime (input: string) =
    match DateTime.TryParse(input) with
    | true, result -> Some result
    | false, _ -> None

let isDate = tryParseDateTime "2019-08-01"
let isNotdate = tryParseDateTime "Hello"


type PersonName =
    { FirstName: string
      MiddleName: string option
      LastName: string }

let person =
    { FirstName = "Ian"
      MiddleName = None
      LastName = "Russell" }

let person2 = { person with MiddleName = Some "????" }


open System

// Reference type
let nullObj: string = null

// Nullable type
let nullPri = Nullable<int>()

let fromNullObj = Option.ofObj nullObj
let fromNullPri = Option.ofNullable nullPri

let resultPM input =
    match input with
    | Some value -> value
    | None -> "------"

let resultDV = Option.defaultValue "------" fromNullObj

let resultFP = fromNullObj |> Option.defaultValue "------"

let setUnknownAsDefault = Option.defaultValue "????"
let result = fromNullObj |> setUnknownAsDefault
