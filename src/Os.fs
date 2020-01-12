module Os

open System

type OS =
    | OSX
    | Windows
    | Linux

let get =
    match int Environment.OSVersion.Platform with
    | 4 | 128 -> Linux
    | 6 -> OSX
    | _ -> Windows