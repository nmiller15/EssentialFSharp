type Coordinate(latitude: float, longitute: float) =
    member _.Latitude = latitude
    member _.Longitude = longitute

let c1 = Coordinate(25.0, 11.98)
let c2 = Coordinate(25.0, 11.98)
let c3 = c1

let eq1 = c1 = c2
let eq2 = c1 = c3
