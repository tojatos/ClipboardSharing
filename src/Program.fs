open Akka.Actor
open ClipboardActor
open System

let checkOs() =
    match Os.get with
    | Os.Windows -> failwith "Windows is not supported yet!" |> ignore
    | Os.OSX -> failwith "OSX is not supported yet!" |> ignore
    | Os.Linux -> ()


let clientHandleMsg msg = printfn "%s" msg
let serverHandleMsg msg = printfn "%s" msg
let startClient hostname = TCPClient.connect hostname clientHandleMsg |> Async.Start
let onClientConnect address = address.ToString() |> startClient

[<EntryPoint>]
let main argv =
    try checkOs() with e -> printfn "%s" e.Message; exit 1
    let system = ActorSystem.Create "MySystem"
    let ca = system.ActorOf<ClipboardActor> "MyActor"
    TCPServer.start serverHandleMsg onClientConnect |> Async.Start

    if (argv.Length > 0) then startClient argv.[0]
    while true do TCPClient.sendMessage(Console.ReadLine())
    // let rec loop oldText =
    //     let text = Clipboard.getText()
    //     if oldText <> text then text |> UpdateClipboard |> ca.Tell
    //     Thread.Sleep 1000
    //     loop text
    // Clipboard.getText() |> loop
    0