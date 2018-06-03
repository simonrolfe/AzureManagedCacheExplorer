# AzureManagedCacheExplorer

A Windows Azure Managed Cache explorer/management app I wrote back in 2014 when at a previous employer, for use by the Ops team during releases and for general monitoring, now preserved as an artifact.

As the Azure Managed Cache doesn't exist any more, there's no real use to the project. I merely offer it as an interesting look at the sorts of issues I came across.

## Things that went well

### The fact that this works at all

The core function I use (GetKeys) isn't actually exposed to the API directly. This made the app a non-starter initially, so I ended up spelunking through the DotPeek'ed source code to see if there was anything I could do. As it turned out, there were a few private methods that helped.

### Real performance

The app caches key info internally for very fast searches (absolute fidelity to the current items in the cache wasn't a concern in this case).

For large invalidation runs (say, pushing all the keys for an entire "version" of the app out), uses Parallel.ForEach which gave a very decent performance boost.

 Being sensible with limiting UI updates (only posting progress every *x* records) lowered load on the client machine without harming the perception of responsiveness.

### Perceived performance

Showing progress clearly for long-running and avoiding unnecessary progress bars for short-running operations meant that the app felt much faster than it would have done otherwise, and simple fixes like double-buffering ListViews when scrolling made the app feel much more "solid".

### WinForms UI/UX for operations and development people

Ease of access to common uses, and getting out of the way of doing work were the priority, with much  less emphasis on discoverability than usual.

### Representing data without any idea what that data might be

The cache stored all sorts of data, often .NET objects which couldn't be retrieved without knowing the object's signature. Where possible I return a simple representation of the data (its type name, plus a string or JSON representation of its value), but this didn't always work, especially for complex types that were defined in classes the cache explorer didn't have access to.

I found a private method that would return the serialised value as a 2-dimensional array of bytes,  which I could then show on screen, giving anyone using the tool a far better chance of understanding what was cached and validating if it made sense.

## Things I'd do differently now

### Separation of Concerns

There is far, far too much code in the forms, and I never found the time to refactor it out into separate classes.

### Configuration Management

Credentials aren't stored in a secure way, which always made me uneasy.

### Use of private, undocumented API

Well, it was necessary, but I can't say I like it.