module Clipboard

let getText() = Bash.exec "xsel -ob"
let setText text = "echo -n \\\"" + text + "\\\" | xsel -ib" |> Bash.exec |> ignore