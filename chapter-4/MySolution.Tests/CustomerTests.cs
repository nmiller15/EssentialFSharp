namespace MyProjectTests

open System
open Xunit

module ``I can group my tests in a module and run`` =

    [<Fact>]
let ``My first test`` () =
        Assert.True(true)

