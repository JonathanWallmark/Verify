<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /docs/mdsource/received-ci.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->

# Getting .received files from CI


## AppVeyor

https://www.appveyor.com/docs/packaging-artifacts/#pushing-artifacts-from-scripts

```
build_script:
- ps: >-
    dotnet build src --configuration Release

    dotnet test src --configuration Release --no-build --no-restore --filter Category!=Integration

    Get-ChildItem .\**\*.received.* | % { Push-AppveyorArtifact $_.FullName -FileName $_.Name }
```
