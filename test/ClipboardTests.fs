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

    [<Test>]
    member this.ProblematicText () =
        let testText = "remote: Compressing objects: 100% (1/1), done."
        setText testText
        Assert.AreEqual(testText, getText())
