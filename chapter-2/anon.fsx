// int -> int -> int
let add x y = x + y
let sum = add 1 4

// int -> int -> int
let add1 = fun x y -> x + y
let sum1 = add 1 4

// ('a -> 'b -> 'c) -> 'a -> 'b -> 'c
let apply f x y = f x y

let sum2 = apply add 1 4
let sum3 = apply (fun x y -> x + y) 1 4


open System

// unit -> int
let rnd () =
    let rand = Random()
    fun () -> rand.Next(100)

List.init 50 (fun _ -> rnd ())
