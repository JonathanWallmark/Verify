﻿using System;

static partial class DiffTools
{
    public static DiffTool VsCode() => new DiffTool(
        name: "Visual Studio Code",
        url: "https://code.visualstudio.com/docs/editor/command-line",
        argumentPrefix: "--diff ",
        exePaths: new[]
        {
            @"%LOCALAPPDATA%\Programs\Microsoft VS Code\code.exe"
        },
        binaryExtensions: Array.Empty<string>());
}