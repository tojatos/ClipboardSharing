// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    TextCopy.Clipboard.SetText("Hey ms kek")
    Console.WriteLine (TextCopy.Clipboard.GetText())
    0 // return an integer exit code
