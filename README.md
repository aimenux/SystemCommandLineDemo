[![.NET](https://github.com/aimenux/SystemCommandLineDemo/actions/workflows/ci.yml/badge.svg)](https://github.com/aimenux/SystemCommandLineDemo/actions/workflows/ci.yml)

# SystemCommandLineDemo
```
Exploring ways of using System.CommandLine to build CLI tools
```

In this repo, i m exploring various ways in order to build a simple cli tool based on [System.CommandLine](https://github.com/dotnet/command-line-api).
>
> :one: straightforward way
> - pros : simplicity
> - cons : verbosity
>
> :two: fluent way
> - pros : discoverability
> - cons : encapsulation
>
> :three: poco way
> - pros : encapsulation
> - cons : performance (use of reflection) 

To run code in debug or release mode, type the following commands in your favorite terminal : 
> - `.\Way.exe Upper [InputText]`
> - `.\Way.exe Lower [InputText]`
>

**`Tools`** : vs22, net 6.0, command-line
