module TCPServer
open System.Net.Sockets
open System.Net
open System.IO
open Networking

let stream = ref null
let mutable started = false

let sendMessage (message: string) = sendMessage message stream
let rec readMessages (sr: StreamReader) onMessage =
    let message = sr.ReadLine()
    if not (isNull message) then begin
        onMessage message
        readMessages sr onMessage
    end

let service (listener: TcpListener) onMessage =
    while true do
        let client = listener.AcceptTcpClient()
        printfn "Client connected"
        use s = client.GetStream()
        stream := s
        use sr = new StreamReader(!stream)
        readMessages sr onMessage

let start onMessage =
    async {
        let listener = TcpListener(IPAddress.Any, defaultPort)
        listener.Start()
        started <- true
        printfn "Listening started"
        service listener onMessage
    }