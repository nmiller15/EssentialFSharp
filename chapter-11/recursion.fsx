// naive: can't perform any operation until all values are computed
let rec _fact n =
    match n with
    | 1 -> 1
    | n -> n * _fact (n - 1)

// tail call optimization
let fact n =
    let rec loop n acc =
        match n with
        | 1 -> acc
        | _ -> loop (n - 1) (acc * n)

    loop n 1


// naive
let rec _fib (n: int64) =
    match n with
    | 0L -> 0L
    | 1L -> 1L
    | s -> _fib (s - 1L) + _fib (s - 2L)

let fib (n: int64) =
    // n = count of iterations
    // a = value 2 back in the sequence
    // b = value 1 back in the sequence
    let rec loop n (a, b) =
        match n with
        | 0L -> a
        | 1L -> b
        | n -> loop (n - 1L) (b, a + b)

    loop n (0L, 1L)

printfn "%i" (fib 50L)

// fib 5L = loop 5L (0L, 1L)
//        = loop 4L (1L, 1L)
//        = loop 3L (1L, 2L)
//        = loop 2L (2L, 3L)
//        = loop 1L (3L, 5L)
//        = 5L
