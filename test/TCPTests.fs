namespace Tests

open NUnit.Framework

[<TestFixture>]
type TCPTests () =

    [<Test>]
    member this.BasicConnection () =
        let serverAsync = TCPServer.start (fun msg -> printfn "Server: %s" msg)
        let clientAsync = TCPClient.connect "127.0.0.1" (fun msg -> printfn "Client: %s" msg)
        let msg = "Message from server"
        TCPServer.sendMessage msg
        Async.RunSynchronously serverAsync
        Async.RunSynchronously clientAsync
        Assert.Fail()
