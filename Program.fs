// Learn more about F# at http://fsharp.org

open System
open System.Threading
open Akka.Actor
open ClipboardActor

let checkOs() =
    match Os.get with
    | Os.Windows -> failwith "Windows is not supported yet!" |> ignore
    | Os.OSX -> failwith "OSX is not supported yet!" |> ignore
    | Os.Linux -> ()

[<EntryPoint>]
let main _ =
    try checkOs() with e -> printfn "%s" e.Message; exit 1
    let system = ActorSystem.Create "MySystem"
    let ca = system.ActorOf<ClipboardActor> "MyActor"
    let rec loop oldText =
        let text = Clipboard.getText()
        if oldText <> text then text |> UpdateClipboard |> ca.Tell
        Thread.Sleep 1000
        loop text
    Clipboard.getText() |> loop
    0