# Haikunator.NET

[![Build Status](https://img.shields.io/appveyor/ci/Atrox/haikunator-net.svg?style=flat-square)](https://ci.appveyor.com/project/Atrox/haikunator-net)
[![Latest Version](https://img.shields.io/nuget/v/Haikunator.svg?style=flat-square)](https://www.nuget.org/packages/Haikunator)

Generate Heroku-like random names to use in your .NET applications.

## Installation

To install Haikunator, run the following command in the Package Manager Console
```
PM> Install-Package Haikunator
```

## Usage

Haikunator is pretty simple.

```cs
// default usage
Haikunator.Haikunator.haikunate() // => "wispy-dust-1337"

// custom length (default=4)
Haikunator.Haikunator.haikunate(tokenLength: 6) // => "patient-king-887265"

// use hex instead of numbers
Haikunator.Haikunator.haikunate(tokenHex: true) // => "purple-breeze-98e1"

// use custom chars instead of numbers/hex
Haikunator.Haikunator.haikunate(tokenChars: "HAIKUNATE") // => "summer-atom-IHEA"

// don't include a token
Haikunator.Haikunator.haikunate(tokenLength: 0) // => "cold-wildflower"

// use a different delimiter
Haikunator.Haikunator.haikunate(delimiter: ".") // => "restless.sea.7976"

// no token, space delimiter
Haikunator.Haikunator.haikunate(tokenLength: 0, delimiter: " ") // => "delicate haze"

// no token, empty delimiter
Haikunator.Haikunator.haikunate(tokenLength: 0, delimiter: "") // => "billowingleaf"
```

## Options

The following options are available:

```cs
Haikunator.Haikunator.haikunate(
  delimiter: "-",
  tokenLength: 4,
  tokenHex: false,
  tokenChars: "0123456789"
)
```
*If ```tokenHex``` is true, it overrides any tokens specified in ```tokenChars```*

## Contributing

Everyone is encouraged to help improve this project. Here are a few ways you can help:

- [Report bugs](https://github.com/Atrox/haikunator.net/issues)
- Fix bugs and [submit pull requests](https://github.com/Atrox/haikunator.net/pulls)
- Write, clarify, or fix documentation
- Suggest or add new features

## Other Languages

Haikunator is also available in other languages. Check them out:

- Python: https://github.com/Atrox/haikunatorpy
- Node: https://github.com/Atrox/haikunatorjs
- PHP: https://github.com/Atrox/haikunator.net
- Dart: https://github.com/Atrox/haikunatordart
- Ruby: https://github.com/usmanbashir/haikunator
- Go: https://github.com/yelinaung/go-haikunator