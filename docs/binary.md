<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /docs/mdsource/binary.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->

# Verification of binary data

Binary data can be verified by passing a stream to `VerifyBinary`.

<!-- snippet: VerifyBinary -->
<a id='snippet-verifybinary'/></a>
```cs
public async Task VerifyBinary(Stream input, string extension = "bin")
```
<sup><a href='/src/Verify.Xunit/VerifyBase_Stream.cs#L13-L15' title='File snippet `verifybinary` was extracted from'>snippet source</a> | <a href='#snippet-verifybinary' title='Navigate to start of snippet `verifybinary`'>anchor</a></sup>
<!-- endsnippet -->

A [Diff Tool](diff-tool.md) will only be displayed if one can be found that supports the defined extension.

For example if Beyond Compare is detected the following will be displayed:

<img src="image-diff-result.png" alt="Image Diff" width="400">


## Initial diff

The majority of diff tools require two files to render a diff. When doing the initial verification there is no ".verified." file available. As such when doing the initial verification an "empty file", of the specified extension, will be used. The list of supported empty file can be seen at [EmptyFiles](/src/Verify.Xunit/EmptyFiles). If no empty file can be found for a given extension, then no diff will be displayed.