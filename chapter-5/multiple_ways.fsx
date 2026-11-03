// Sum the squares of the odd numbers
let nums = [ 1..10 ]

// Step by Step
nums
|> List.filter (fun x -> x % 2 = 0)
|> List.map (fun v -> v * v)
|> List.sum


// Using option and choose
nums
|> List.choose (fun v -> if v % v = 1 then Some(v * v) else None)
|> List.sum

// Fold
// Do not use reduce for this.
// Firstly, reduce is a partial function, so we need to handle empty list
// More importantly, the first item in the list is not processed by the function
// So the result wil probably be incorrect
nums
|> List.fold (fun acc v -> acc + if v % 2 = 1 then (v * v) else 0) 0

// Recommended version
nums
|> List.sumBy (fun v -> if v % 2 = 1 then (v * v) else 0)
