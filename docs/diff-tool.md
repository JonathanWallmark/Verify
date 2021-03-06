<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /docs/mdsource/diff-tool.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->

# Diff Tool

When a test fails verification the difference between the received and verified files is displayed in a diff tool.


## Initial difference behavior

Behavior when an input is verified for the first time.

Behavior depends on if an [EmptyFiles](https://github.com/SimonCropp/EmptyFiles) can be found matching the current extension.

 * If an EmptyFiles can be found matching the current extension, then the diff tool will be launch to compare the input to that empty file.
 * If no EmptyFiles can be found no diff tool will be launched.


## Detected difference behavior

Behavior when a difference is detected between the input an existing current verified file.


### Not Running

If no diff tool is running for the comparison of the current verification (per test), a new diff tool instance will be launched.


### Is Running

If a diff tool is running for the comparison of the current verification (per test), and a new verification fails, the following logic will be applied:

| Auto Refresh | Mdi   | Behavior |
|--------------|-------|----------|
| true         | true  | No action. Current instance will refresh |
| true         | false | No action. Current instance will refresh |
| false        | true  | Open new instance. Previous instance must be manually closed |
| false        | false | Kill current and open new instance |

This allows, in most cases, for no manual closing of the diff tool to be required. <!-- include: diffToolCleanup. path: /docs/mdsource/diffToolCleanup.include.md -->

This behavior is currently supported on Windows. On Linux and OSX, diff tool instances must be manually managed. <!-- end include: diffToolCleanup. path: /docs/mdsource/diffToolCleanup.include.md -->


## MaxInstancesToLaunch

By default a maximum of 5 diff tool instances will be launched. This prevents a change that break many test from causing too much load on a machine.

This value can be changed:

<!-- snippet: MaxInstancesToLaunch -->
<a id='snippet-maxinstancestolaunch'/></a>
```cs
DiffRunner.MaxInstancesToLaunch(10);
```
<sup><a href='/src/Verify.Tests/Tests.cs#L145-L149' title='File snippet `maxinstancestolaunch` was extracted from'>snippet source</a> | <a href='#snippet-maxinstancestolaunch' title='Navigate to start of snippet `maxinstancestolaunch`'>anchor</a></sup>
<!-- endsnippet -->


## Successful verification behavior

If a diff tool is running for the comparison of the current verification (per test), and a new verification passes, the following logic will be applied:

| Mdi   | Behavior |
|-------|----------|
| true  | No action taken. Previous instance must be manually closed |
| false | Kill current instance |

This allows, in most cases, for no manual closing of the diff tool to be required. <!-- include: diffToolCleanup. path: /docs/mdsource/diffToolCleanup.include.md -->

This behavior is currently supported on Windows. On Linux and OSX, diff tool instances must be manually managed. <!-- end include: diffToolCleanup. path: /docs/mdsource/diffToolCleanup.include.md -->


## Supported Diff tools:

 <!-- include: diffTools. path: /src/DiffEngine.Tests/diffTools.include.md -->
## [VisualStudio](https://docs.microsoft.com/en-us/visualstudio/ide/reference/diff)

  * IsMdi: True
  * SupportsAutoRefresh: True

### Windows scanned paths:

 * `%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv.exe`
 * `%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Professional\Common7\IDE\devenv.exe`
 * `%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\devenv.exe`

## [VisualStudioCode](https://code.visualstudio.com/docs/editor/command-line)

  * IsMdi: True
  * SupportsAutoRefresh: True

### Windows scanned paths:

 * `%LOCALAPPDATA%\Programs\Microsoft VS Code\code.exe`

### OSX scanned paths:

 * `/Applications/Visual Studio Code.app/Contents/Resources/app/bin/code`

### Linux scanned paths:

 * `/usr/local/bin/code`

## [TkDiff](https://sourceforge.net/projects/tkdiff/)

  * IsMdi: False
  * SupportsAutoRefresh: False

### OSX scanned paths:

 * `/Applications/TkDiff.app/Contents/MacOS/tkdiff`

## [KDiff3](https://github.com/KDE/kdiff3)

  * IsMdi: False
  * SupportsAutoRefresh: False

### Windows scanned paths:

 * `%ProgramFiles%\KDiff3\kdiff3.exe`

### OSX scanned paths:

 * `/Applications/kdiff3.app/Contents/MacOS/kdiff3`

## [TortoiseIDiff](https://tortoisesvn.net/TortoiseIDiff.html)

  * IsMdi: False
  * SupportsAutoRefresh: False

### Windows scanned paths:

 * `%ProgramFiles%\TortoiseSVN\bin\TortoiseIDiff.exe`

### Supported Text files: False


### Supported binary extensions:

 * bmp
 * gif
 * ico
 * jpg
 * jpeg
 * png
 * tif
 * tiff

## [TortoiseMerge](https://tortoisesvn.net/TortoiseMerge.html)

  * IsMdi: False
  * SupportsAutoRefresh: False

### Windows scanned paths:

 * `%ProgramFiles%\TortoiseSVN\bin\TortoiseMerge.exe`

## [DiffMerge](https://www.sourcegear.com/diffmerge/)

  * IsMdi: False
  * SupportsAutoRefresh: False

### Windows scanned paths:

 * `%ProgramFiles%\SourceGear\Common\DiffMerge\sgdm.exe`

### OSX scanned paths:

 * `/Applications/DiffMerge.app/Contents/MacOS/DiffMerge`

### Linux scanned paths:

 * `/usr/bin/diffmerge`

## [WinMerge](https://manual.winmerge.org/en/Command_line.html)

  * IsMdi: False
  * SupportsAutoRefresh: True

### Windows scanned paths:

 * `%ProgramFiles(x86)%\WinMerge\WinMergeU.exe`

## [CodeCompare](https://www.devart.com/codecompare/docs/index.html?comparing_via_command_line.htm)

  * IsMdi: True
  * SupportsAutoRefresh: False

### Windows scanned paths:

 * `%ProgramFiles%\Devart\Code Compare\CodeCompare.exe`

## [Kaleidoscope](https://www.kaleidoscopeapp.com/)

  * IsMdi: False
  * SupportsAutoRefresh: False

### OSX scanned paths:

 * `/usr/local/bin/ksdiff`

### Supported Text files: True


### Supported binary extensions:

 * bmp
 * gif
 * ico
 * jpg
 * jpeg
 * png
 * tiff
 * tif

## [SublimeMerge](https://www.sublimemerge.com/)

  * IsMdi: False
  * SupportsAutoRefresh: False

### Windows scanned paths:

 * `%ProgramFiles%\Sublime Merge\smerge.exe`

### OSX scanned paths:

 * `/Applications/smerge.app/Contents/MacOS/smerge`

### Linux scanned paths:

 * `/usr/bin/smerge`

## [Meld](https://meldmerge.org/)

  * IsMdi: False
  * SupportsAutoRefresh: False

### Windows scanned paths:

 * `%ProgramFiles(x86)%\Meld\meld.exe`

### OSX scanned paths:

 * `/Applications/meld.app/Contents/MacOS/meld`

### Linux scanned paths:

 * `/usr/bin/meld`

## [AraxisMerge](https://www.araxis.com/merge)

  * IsMdi: True
  * SupportsAutoRefresh: True

### Windows scanned paths:

 * `%ProgramFiles%\Araxis\Araxis Merge\Compare.exe`

### OSX scanned paths:

 * `/Applications/Araxis Merge.app/Contents/MacOS/Araxis Merge`

### Supported Text files: True


### Supported binary extensions:

 * bmp
 * dib
 * emf
 * gif
 * jif
 * j2c
 * j2k
 * jp2
 * jpc
 * jpeg
 * jpg
 * jpx
 * pbm
 * pcx
 * pgm
 * png
 * ppm
 * ras
 * tif
 * tiff
 * tga
 * wmf

## [P4Merge](https://www.perforce.com/products/helix-core-apps/merge-diff-tool-p4merge)

  * IsMdi: False
  * SupportsAutoRefresh: False

### Windows scanned paths:

 * `%ProgramFiles%\Perforce\p4merge.exe`

### OSX scanned paths:

 * `/Applications/p4merge.app/Contents/MacOS/p4merge`

### Linux scanned paths:

 * `/usr/bin/p4merge`

### Supported Text files: True


### Supported binary extensions:

 * bmp
 * gif
 * jpg
 * jpeg
 * png
 * pbm
 * pgm
 * ppm
 * tif
 * tiff
 * xbm
 * xpm

## [BeyondCompare](https://www.scootersoftware.com/v4help/index.html?command_line_reference.html)

  * IsMdi: False
  * SupportsAutoRefresh: True

### Windows scanned paths:

 * `%ProgramFiles%\Beyond Compare 4\BCompare.exe`
 * `%ProgramFiles%\Beyond Compare 3\BCompare.exe`

### OSX scanned paths:

 * `/Applications/Beyond Compare.app/Contents/MacOS/bcomp`

### Linux scanned paths:

 * `/usr/lib/beyondcompare/bcomp`

### Supported Text files: True


### Supported binary extensions:

 * mp3
 * xls
 * xlsm
 * xlsx
 * doc
 * docm
 * docx
 * dot
 * dotm
 * dotx
 * pdf
 * bmp
 * gif
 * ico
 * jpg
 * jpeg
 * png
 * tif
 * tiff
 * rtf <!-- end include: diffTools. path: /src/DiffEngine.Tests/diffTools.include.md -->


## Disable Diff

<!-- snippet: DisableDiff -->
<a id='snippet-disablediff'/></a>
```cs
var settings = new VerifySettings();
settings.DisableDiff();
```
<sup><a href='/src/Verify.Tests/Snippets/Snippets.cs#L55-L60' title='File snippet `disablediff` was extracted from'>snippet source</a> | <a href='#snippet-disablediff' title='Navigate to start of snippet `disablediff`'>anchor</a></sup>
<!-- endsnippet -->


## DiffEngine

**API SUBJECT TO CHNAGE IN MINOR RELEASES**

DiffEngine contains all functionality used to manage diff tools processes. It is shipped as a stand alone NuGet package: https://www.nuget.org/packages/DiffEngine/. It is designed to be used by [other Snapshot/Approval testing projects](/#alternatives).


### Launching a diff tool

A diff tool can be launched using the following:

<!-- snippet: DiffRunnerLaunch -->
<a id='snippet-diffrunnerlaunch'/></a>
```cs
DiffRunner.Launch(path1, path2);
```
<sup><a href='/src/DiffEngine.Tests/DiffRunnerTests.cs#L15-L17' title='File snippet `diffrunnerlaunch` was extracted from'>snippet source</a> | <a href='#snippet-diffrunnerlaunch' title='Navigate to start of snippet `diffrunnerlaunch`'>anchor</a></sup>
<!-- endsnippet -->

Note that this method will respect the above [difference behavior](#detected-difference-behavior) in terms of Auto refresh and MDI behaviors.


### Closing a diff tool

A diff tool can be closed using the following:

<!-- snippet: DiffRunnerKill -->
<a id='snippet-diffrunnerkill'/></a>
```cs
DiffRunner.Kill(path1, path2);
```
<sup><a href='/src/DiffEngine.Tests/DiffRunnerTests.cs#L26-L28' title='File snippet `diffrunnerkill` was extracted from'>snippet source</a> | <a href='#snippet-diffrunnerkill' title='Navigate to start of snippet `diffrunnerkill`'>anchor</a></sup>
<!-- endsnippet -->

Note that this method will respect the above [difference behavior](#detected-difference-behavior) in terms of MDI behavior.


### File type detection

`DiffEngine.Extensions` use data sourced from [sindresorhus/text-extensions](https://github.com/sindresorhus/text-extensions/blob/master/text-extensions.json) to determine if a given file or extension is a text file.

Methods:

 * `Extensions.IsTextExtension()` determines if a file extension (without a period `.`) represents a text file.
 * `Extensions.IsTextFile()` determines if a file path represents a text file.
