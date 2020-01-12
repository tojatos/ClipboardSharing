module Networking
open System.IO
open System.Threading

let defaultPort = 3003
let sendMessage (message: string) stream =
    while (isNull !stream) do Thread.Sleep 200
    let sw = new StreamWriter(stream = !stream)
    sw.AutoFlush <- true
    sw.WriteLine(message)