module Clipboard

let getText() = Bash.exec "xsel -ob"
let setText text = Bash.exec ("echo -n " + text + " | xsel -ib") |> ignore