module TCPClient
open System.Net.Sockets
open System.IO
open Networking

let stream = ref null
let mutable isRunning = false

let sendMessage (message: string) = sendMessage message stream
let rec readMessages (sr: StreamReader) onMessage =
    let message = sr.ReadLine()
    if not (isNull message) then begin
        onMessage message
        readMessages sr onMessage
    end

let connectHP hostname port onMessage =
    async {
        let client = new TcpClient(hostname, port)
        isRunning <- true
        printfn "Client connection started"
        use s = client.GetStream()
        stream := s
        use sr = new StreamReader(!stream)
        readMessages sr onMessage
        isRunning <- false
        printfn "Client connection lost"
    }

let connect hostname onMessage = connectHP hostname defaultPort onMessage