// Learn more about F# at http://fsharp.org

open System
open System.Threading

let rec loop() =
    Clipboard.getText() |> printfn "%s"
    Thread.Sleep 1000
    loop()

[<EntryPoint>]
let main argv =
    Clipboard.setText "Hello, girls"
    loop()
    Console.Read() |> ignore
    0 // return an integer exit code