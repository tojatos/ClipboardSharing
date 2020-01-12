// Learn more about F# at http://fsharp.org

open System
open System.Threading

let rec loop oldText =
    let text = Clipboard.getText()
    if oldText <> text then printfn "%s" text
    Thread.Sleep 1000
    loop text

[<EntryPoint>]
let main _ =
    Clipboard.getText() |> loop
    0