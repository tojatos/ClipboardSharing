namespace Tests

open NUnit.Framework
open Clipboard

[<TestClass>]
type TestClass () =

    [<Test>]
    member this.Test1 () =
        let testText = "test text"
        setText testText
        Assert.AreEqual(testText, getText())
