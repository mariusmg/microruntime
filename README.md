Microruntime 
============

Microruntime is a general purpose utility for .NET (v4 and higher) and .NetCore 

It contains :

- plugin loader (TypeInstance)

- ranges

- DateTime, string and streams utilities 

- some functional utilities for conditional checks

   `CustomType x = ....
   `RunIfNull<CustomType>(x, ()=>{
      //do stuffs
   });

- a simple option type for C# ( inspired from F#)

   This allows you, to write non nullable reference types, something like this :

   `Maybe<ReferenceInstance>  result = GetResult();`

   `if(result.HasValue)`
   `{`
   
   `result.DoStuffWithIt();`
   
   `}`

- discriminated union implementation (again, inspired from F#)

- helper class to implement circuit breaker pattern with for multiple retries for a operation


Install it :

To use it, just install the library directly from nuget :

## Install-Package Microruntime