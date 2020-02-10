<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /docs/mdsource/comparer.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->

# Comparer

Comparers are used to compare non-text files.


## Custom Comparer

Using a custom comparer can be helpful when a result has changed, but not enough to fail verification. For example when rendering images/forms on different operating systems.

For samples purposes an [image difference hash algorithm](https://github.com/coenm/ImageHash#hash-algorithms) from the [ImageHash project](https://github.com/coenm/ImageHash) will be used:

<!-- snippet: ImageComparer -->
<a id='snippet-imagecomparer'/></a>
```cs
static bool CompareImages(Stream stream1, Stream stream2)
{
    var hash1 = HashImage(stream1);
    var hash2 = HashImage(stream2);
    var percentage = CompareHash.Similarity(hash1, hash2);
    return percentage > 99;
}

static ulong HashImage(Stream stream)
{
    var algorithm = new DifferenceHash();
    using var image = Image.Load<Rgba32>(stream);
    return algorithm.Hash(image);
}
```
<sup><a href='/src/Snippets/ComparerSnippets.cs#L37-L52' title='File snippet `imagecomparer` was extracted from'>snippet source</a> | <a href='#snippet-imagecomparer' title='Navigate to start of snippet `imagecomparer`'>anchor</a></sup>
<!-- endsnippet -->


### Instance comparer

<!-- snippet: InstanceComparer -->
<a id='snippet-instancecomparer'/></a>
```cs
var settings = new VerifySettings();
settings.UseComparer(CompareImages);
settings.UseExtension("png");
await Verify("TheImage.png", settings);
```
<sup><a href='/src/Snippets/ComparerSnippets.cs#L21-L26' title='File snippet `instancecomparer` was extracted from'>snippet source</a> | <a href='#snippet-instancecomparer' title='Navigate to start of snippet `instancecomparer`'>anchor</a></sup>
<!-- endsnippet -->


### Static comparer

<!-- snippet: StaticComparer -->
<a id='snippet-staticcomparer'/></a>
```cs
SharedVerifySettings.RegisterComparer("png", CompareImages);
await VerifyFile("TheImage.png");
```
<sup><a href='/src/Snippets/ComparerSnippets.cs#L31-L34' title='File snippet `staticcomparer` was extracted from'>snippet source</a> | <a href='#snippet-staticcomparer' title='Navigate to start of snippet `staticcomparer`'>anchor</a></sup>
<!-- endsnippet -->


## Default Comparison

<!-- snippet: DefualtCompare -->
<a id='snippet-defualtcompare'/></a>
```cs
static async Task<bool> StreamsAreEqual(Stream stream1, Stream stream2)
{
    const int bufferSize = 1024 * sizeof(long);
    var buffer1 = new byte[bufferSize];
    var buffer2 = new byte[bufferSize];

    while (true)
    {
        var t1 = ReadBufferAsync(stream1, buffer1);
        await ReadBufferAsync(stream2, buffer2);

        var count = await t1;

        //no need to compare size here since only enter on files being same size

        if (count == 0)
        {
            return true;
        }

        for (var i = 0; i < count; i+= sizeof(long))
        {
            if (BitConverter.ToInt64(buffer1, i) != BitConverter.ToInt64(buffer2, i))
            {
                return false;
            }
        }
    }
}

static async Task<int> ReadBufferAsync(Stream stream, byte[] buffer)
{
    var bytesRead = 0;
    while (bytesRead < buffer.Length)
    {
        var read = await stream.ReadAsync(buffer, bytesRead, buffer.Length - bytesRead);
        if (read == 0)
        {
            // Reached end of stream.
            return bytesRead;
        }

        bytesRead += read;
    }

    return bytesRead;
}
```
<sup><a href='/src/Verify/Compare/FileComparer.cs#L71-L119' title='File snippet `defualtcompare` was extracted from'>snippet source</a> | <a href='#snippet-defualtcompare' title='Navigate to start of snippet `defualtcompare`'>anchor</a></sup>
<!-- endsnippet -->