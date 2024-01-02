# MoreDotNet

## Status

[![NuGet version](https://badge.fury.io/nu/MoreDotNet.svg)](https://badge.fury.io/nu/MoreDotNet)

[![Coverage Status](https://coveralls.io/repos/github/Teodor92/MoreDotNet/badge.svg?branch=master)](https://coveralls.io/github/Teodor92/MoreDotNet?branch=master)

## Summary

This project is a collection of handy extension methods for the .NET Framework. The functionality of this package can be separated in the following groups:

### Extension methods for common .NET types:

---

* ICollection:

```cs
AddRange()
```

* IDictionary:

```cs
GetOrDefault()
GetKeyIgnoringCase()
```

* IEnumerable:

```cs
ForEach()
EmptyIfNull()
Shuffle()
ToString()
IsNullOrEmpty()
ToHashSet()
```

* IList:

```cs
BinarySearch()
ToDataTable()
InsertionSort()
InsertWhere()
RemoveAll()
```

* bool:

```cs
WhenTrue()
WhenFalse()
```

* ByteArray:

```cs
GetString()
```

* IConvertible:

```cs
To()
ToOrDefault()
ToOrOther()
ToOrNull()
```

* IDataRecord:

```cs
GetNullable()
```

* DateTime:

```cs
FirstDayOfMonth()
LastDayOfMonth()
NextDate()
Midnight()
Noon()
WithTime()
IsFuture()
IsPast()
IsWorkDay()
IsWeekend()
NextWorkday()
```

* Enum:

```cs
GetDisplayName()
GetDescription()
```

* Generics

```cs
IsBetween()
GetMemberName()
```

* int:

```cs
RangeTo()
```

* object:

```cs
Is()
IsNot()
As()
ToDictionary()
```

* OperatingSystem:

```cs
IsWinXpOrHigher()
IsWinVistaOrHigher()
IsWin7OrHigher()
IsWin8OrHigher()
```

* Random:

```cs
OneOf()
NextBool()
NextChar()
NextDateTime()
NextDouble()
NextString()
NextTimeSpan()
```

* Stream:

```cs
ToByteArray()
ToStream()
```

* string:

```cs
ToTitleCase()
CaseToWords()
Capitalize()
IsLike()
ToMaximumLengthString()
NthIndexOf()
RemoveLastCharacter()
RemoveLast()
RemoveFirstCharacter()
RemoveFirst()
```

* Type:

```cs
IsNullable()
GetCoreType()
```

* Xml:

```cs
XmlSerialize()
XmlDeserialize()
```

* RomanNumeral:

```cs
IsValidRomanNumeral()
ParseRomanNumeral()
ToRomanNumeralString()
```

### Static helpers

---

* Directory:

```cs
CreateTempDirectory()
SafeDeleteDirectory()
```

* File:

```cs
SaveStringToTempFile()
SaveByteArrayToTempFile()
```

### Wrappers for transforming common static methods to instance methods

---

Example:

```cs
string.IsNullOrWhiteSpace(testStringVar)
```

Is transformed to:

```cs
testStringVar.IsNullOrWhiteSpace()
```

## Installation

NOTE: The package is still under development and some bugs may exist!

You can install the library using NuGet into your project:

```bash
Install-Package MoreDotNet
```

## Changelog

## Version 0.7

- Switched to .NET Standard.
- APIs for Color, OperatingSystem and DataTable removed due to them missing in the .NET Standard API.

## License

This package has MIT license. Refer to the [LICENSE](https://github.com/Teodor92/MoreDotNet/blob/master/LICENSE) for detailed information.

## Any questions, comments or additions

If you have a feature request or bug report, leave an issue on the [issues page](https://github.com/Teodor92/MoreDotNet/issues) or send a [pull request](https://github.com/Teodor92/MoreDotNet/pulls). For general questions and comments, use the [StackOverflow](http://stackoverflow.com/) forum.
