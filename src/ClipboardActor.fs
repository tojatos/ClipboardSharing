module ClipboardActor
open Akka.Actor

type UpdateMyClipboard(text) =
    member __.Text = text

type UpdateOtherClipboards(text) =
    member __.Text = text

type ClipboardActor() as g =
    inherit ReceiveActor()
    do g.Receive<UpdateMyClipboard>(fun (uc: UpdateMyClipboard) -> printfn "Received: %s" uc.Text)
    do g.Receive<UpdateOtherClipboards>(fun (uc: UpdateOtherClipboards) -> TCPClient.sendMessage(uc.Text))