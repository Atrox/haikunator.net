# Haikunator.NET

[![Latest Version](https://img.shields.io/nuget/v/Haikunator.svg?style=flat-square)](https://www.nuget.org/packages/Haikunator)
[![Build Status - Windows](https://img.shields.io/appveyor/ci/Atrox/haikunator-net.svg?style=flat-square&label=windows)](https://ci.appveyor.com/project/Atrox/haikunator-net)
[![Build Status - Linux](https://img.shields.io/travis/Atrox/haikunator.net.svg?style=flat-square&label=linux)](https://travis-ci.org/Atrox/haikunator.net)

Generate Heroku-like random names to use in your .NET applications.

## Installation

To install Haikunator, run the following command in the [Package Manager Console](http://docs.nuget.org/consume/package-manager-console)
```
PM> Install-Package Haikunator
```

## Usage

Haikunator is pretty simple.

```cs
var haikunator = new Atrox.Haikunator();

// default usage
haikunator.Haikunate() // => "wispy-dust-1337"

// custom length (default=4)
haikunator.Haikunate(tokenLength: 6) // => "patient-king-887265"

// use hex instead of numbers
haikunator.Haikunate(tokenHex: true) // => "purple-breeze-98e1"

// use custom chars instead of numbers/hex
haikunator.Haikunate(tokenChars: "HAIKUNATE") // => "summer-atom-IHEA"

// don't include a token
haikunator.Haikunate(tokenLength: 0) // => "cold-wildflower"

// use a different delimiter
haikunator.Haikunate(delimiter: ".") // => "restless.sea.7976"

// no token, space delimiter
haikunator.Haikunate(tokenLength: 0, delimiter: " ") // => "delicate haze"

// no token, empty delimiter
haikunator.Haikunate(tokenLength: 0, delimiter: "") // => "billowingleaf"

// custom adjectives and nouns
haikunator.Adjectives = new[] {"red", "green", "blue"};
haikunator.Nouns = new[] {"reindeer", "cow", "kangaroo"};
haikunator.Haikunate() // => "green-cow-5426"
```

## Options

The following options are available:

```cs
var haikunator = new Atrox.Haikunator();

haikunator.Adjectives = new[] {"set", "custom", "adjectives"};
haikunator.Nouns = new[] {"set", "custom", "nouns"};

haikunator.Haikunate(
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
- PHP: https://github.com/Atrox/haikunatorphp
- Java: https://github.com/Atrox/haikunatorjava
- Go: https://github.com/Atrox/haikunatorgo
- Dart: https://github.com/Atrox/haikunatordart
- Ruby: https://github.com/usmanbashir/haikunator
- Rust: https://github.com/nishanths/rust-haikunator
