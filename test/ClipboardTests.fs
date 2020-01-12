namespace Tests

open NUnit.Framework
open Clipboard

[<TestFixture>]
type ClipboardTests () =

    [<Test>]
    member this.BasicGetSet () =
        let testText = "test text"
        setText testText
        Assert.AreEqual(testText, getText())
