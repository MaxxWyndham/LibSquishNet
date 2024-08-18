**LibSquishNet**

![Nuget](https://img.shields.io/nuget/v/LibSquishNet)

A partial port of Simon Brown's v1.11 libsquish to .NET

Original project is available here https://code.google.com/p/libsquish/

**Changelog**

**v2.1.0**
Updated to .NET 4.6.2, and added support for .NET 4.8.1, 6.0, and 8.0.

**v2.0.0**  
Parallism!  A basic implementation using Parallel.For on the primary loop.  Reduces compression time considerably.  Pass true into `CompressImage` for the new `parallel` parameter.  Default is false.  
Code-style.  The code is more modern C# style now.

**v1.11.0**  
Initial release
