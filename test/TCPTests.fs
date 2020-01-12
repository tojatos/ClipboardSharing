namespace Tests

open NUnit.Framework
open System.Threading

[<TestFixture>]
type TCPTests () =

    [<Test>]
    member this.BasicConnection () =
        let mutable res = ""
        let serverAsync = TCPServer.start ignore
        let clientAsync = TCPClient.connect "127.0.0.1" (fun msg -> res <- msg)
        let msg = "Message from server"
        Async.Start serverAsync
        while not TCPServer.started do Thread.Sleep 200
        Async.Start clientAsync
        TCPServer.sendMessage msg
        Thread.Sleep 200
        Assert.AreEqual(msg, res)
