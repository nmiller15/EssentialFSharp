namespace MyProjectTests

open Xunit
open FsUnit
open MyProject.Customer

module ``When upgrading customer`` =

    let customerVIP = { Id = 1; IsVip = true; Credit = 0.0M }
    let customerSTD = { Id = 2; IsVip = false; Credit = 100.0M }

    let areEqual expected actual =
        actual = expected

    // let assertVIP =
    //     let expected = { Id = 1; IsVip = true; Credit = 100.0M }
    //     areEqual expected (upgradeCustomer customerVIP)
    [<Fact>]
    let ``should give VIP customer more credit`` () =
        let expected = { customerVIP with Credit = customerVIP.Credit + 100M }
        let actual = upgradeCustomer customerVIP
        actual |> should equal expected


    // let assertSTDtoVIP =
    //     let expected = { Id = 2; IsVip = true; Credit = 200.0M }
    //     areEqual expected (upgradeCustomer customerSTD)

    [<Fact>]
    let ``should convert STD customer to VIP`` () =
        let expected = { Id = 2; IsVip = true; Credit = 200.0M }
        let actual = upgradeCustomer customerSTD
        actual |> should equal expected

    // let assertSTD =
    //     let expected = { Id = 3; IsVip = false; Credit = 100.M }
    //     areEqual expected (upgradeCustomer { customerSTD with Id = 3; Credit = 50.0M })
    [<Fact>]
    let ``should not upgrade ineligible STD customer to VIP`` () =
        let expected = { Id = 3; IsVip = false; Credit = 100M }
        let actual = upgradeCustomer { customerSTD with Id = 3; Credit = 50.0M }
        actual |> should equal expected
