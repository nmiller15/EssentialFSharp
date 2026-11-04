let (|IsDivisibleBy|_|) divisor n =
    if n % divisor = 0 then Some() else None

let (|NotDivisibleBy|_|) divisor n =
    if n % divisor <> 0 then Some() else None

let isLeapYear year =
    match year with
    | IsDivisibleBy 400 -> true
    | IsDivisibleBy 4 & NotDivisibleBy 100 -> true
    | _ -> false

[ 2000; 2001; 2020 ]
|> List.map isLeapYear
