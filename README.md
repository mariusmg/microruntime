Microruntime 
============

Microruntime is a general purpose utility for .NET (v4 and higher)

It contains :

- a simple Inversion of Control container (TypeInstance)

- ranges

- DateTime, string and streams utilities 

- a simple option type for C# ( inspired from F#)

   This allows you, to write non nullable reference types, something like this :

   `Maybe<ReferenceInstance>  result = GetResult();`

   `if(result.HasValue)`
   `{`
   
   `result.DoStuffWithIt();`
   
   `}`


- a discriminated union implementation (again, inspired from F#)


Use it :

To use it, just install the library directly from nuget :

## Install-Package Microruntime