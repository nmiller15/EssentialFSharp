open System

// decimal -> decimal -> decimal
// let tryDivide (x:decimal) (y:decimal) =
//     try
//         x / y
//     with
//     | :? DivideByZeroException as ex -> raise ex

// The function signture above is a lie. It doesn't ALWAYS return a decimal.


// decimal -> decimal -> Result<decimal, DivideByZeroException>
let tryDivide (x: decimal) (y: decimal) =
    try
        Ok(x / y)
    with :? DivideByZeroException as ex ->
        Error ex

let badDivide = tryDivide 1M 0M
let goodDivide = tryDivide 1M 1M
