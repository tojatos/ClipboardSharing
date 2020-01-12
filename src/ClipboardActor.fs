module ClipboardActor
open Akka.Actor

type UpdateClipboard(text) =
    member __.Text = text

type ClipboardActor() as g =
    inherit ReceiveActor()
    do g.Receive<UpdateClipboard>(fun (uc: UpdateClipboard) -> printfn "Received: %s" uc.Text)
