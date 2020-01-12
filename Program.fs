// Learn more about F# at http://fsharp.org

open System
open System.Threading

let rec loop oldText =
    let text = Clipboard.getText()
    if oldText <> text then printfn "%s" text
    Thread.Sleep 1000
    loop text

let checkSystem() =
    match Os.get with
    | Os.Windows -> failwith "Windows is not supported yet!" |> ignore
    | Os.OSX -> failwith "OSX is not supported yet!" |> ignore
    | Os.Linux -> ()

[<EntryPoint>]
let main _ =
    try checkSystem() with e -> printfn "%s" e.Message; exit 1

    Clipboard.getText() |> loop
    0