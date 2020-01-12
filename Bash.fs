module Bash
open System.Diagnostics

let exec command =
    let procStartInfo = ProcessStartInfo(
                            FileName = "/bin/bash",
                            Arguments = "-c \""+ command + "\"",
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        )
    let p = new Process(StartInfo = procStartInfo)
    p.Start() |> ignore
    p.WaitForExit()
    p.StandardOutput.ReadToEnd()
