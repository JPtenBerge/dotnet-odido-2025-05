# Notes

## IDEs

- Visual Studio (full-fledged IDE)
- JetBrains Rider (full-fledged IDE)
- VS Code (text editor + extensions) <== free

## Type system

- value types: exist on the stack
- reference types: exist on the heap
  - garbage collected

Value types in .NET:

- `long` 8 BYTES/64-bit -9.223.372.036.854.775.808
- `int` 4 bytes/32-bit 2^32 -2.147.xxx.xxx - 2.147.xxx.xxx
- `short` 2 bytes/16 bit 2^16 -32.768 - 32.767
- `ulong`
- `uint` 0 - 4.294.xxx.xxx
- `ushort` 0 - 65536
- `float` 32 bits
- `double` 64 bits
- `decimal` 128 bits
- `boolean` `true`/`false`
- `char` `'a'` `'e'` `'j'` `'p'` no unicode
- `enum`
- `struct`

## `is null` vs `== null`

C# has a language feature called "operator overloading" that allows for custom behavior with operators. `== null` can be overloaded, `is null` cannot. For this reason, `is null` is regularly preferred over `== null`.
