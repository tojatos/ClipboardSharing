namespace Tests

open NUnit.Framework
open Bash

[<TestFixture>]
type BashTests () =

    [<Test>]
    member this.EchoTest () =
        let testText = "Ala ma kota"
        let cmdResult = "echo -n " + testText |> exec
        Assert.AreEqual(testText, cmdResult)
