type Customer =
    { Id: int
      IsVip: bool
      Credit: decimal }

// Customer -> (Customer * decimal)
let getPurchases customer =
    let purchases = if customer.Id % 2 = 0 then 120M else 80M
    customer, purchases

// (Customer * decimal) -> Customer
let tryPromoteToVip purchases =
    let (customer, amount) = purchases

    if amount > 100M then
        { customer with IsVip = true }
    else
        customer

// Customer -> Customer
let increaseCreditIfVip customer =
    let increase = if customer.IsVip then 100M else 50M

    { customer with
        Credit = customer.Credit + increase }

// Composition operator
let upgradeCustomerComposed = // Customer -> Customer
    getPurchases >> tryPromoteToVip >> increaseCreditIfVip

// Nested
let upgradeCustomerNested customer = // Customer -> Customer
    increaseCreditIfVip (tryPromoteToVip (getPurchases customer))

// Procedural
let upgradeCustomerProcedural customer = // Customer -> Customer
    let customerWithPurchases = getPurchases customer
    let promotedCustomer = tryPromoteToVip customerWithPurchases
    let increasedCreditCustomer = increaseCreditIfVip promotedCustomer

    increasedCreditCustomer

// Forward pipe operator
// DEFAULT STYLE
let upgradeCustomerPiped customer = // Customer -> Customer
    customer |> getPurchases |> tryPromoteToVip |> increaseCreditIfVip



// ASSERT
// ========================================================================

let customerVIP = { Id = 1; IsVip = true; Credit = 0.0M }

let customerSTD =
    { Id = 2
      IsVip = false
      Credit = 100.0M }



let assertVIP =
    upgradeCustomerPiped customerVIP = { Id = 1
                                         IsVip = true
                                         Credit = 100.0M }

let assertSTDToVIP =
    upgradeCustomerPiped customerSTD = { Id = 2
                                         IsVip = true
                                         Credit = 200.0M }

let assertSTD =
    upgradeCustomerPiped
        { customerSTD with
            Id = 3
            Credit = 50.0M } = { Id = 3
                                 IsVip = false
                                 Credit = 100.0M }
