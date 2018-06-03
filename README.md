# AzureManagedCacheExplorer

A Windows Azure Managed Cache explorer/management app I wrote back in 2014 when at a previous employer, for use by the Ops team during releases and for general monitoring, now preserved as an artifact.

As the Azure Managed Cache doesn't exist any more, there's no real use to the project. I merely offer it as an interesting look at the sorts of issues I came across.

## Real versus perceived performance

Showing progress clearly for long-running and avoiding unnecessary progress bars for short-running operations meant that the app felt much faster than it would have done otherwise, and simple fixes like double-buffering ListViews when scrolling made the app feel much more "solid".

## WinForms UI/UX for operations and development people

Ease of access to common uses, and getting out of the way of doing work were the priority, with much  less emphasis on discoverability than usual.

## Representing data without any idea what that data might be

The cache stored all sorts of data, often .NET objects which couldn't be retrieved without knowing the object's signature. Where possible I return a simple representation of the data (its type name, plus a string or JSON representation of its value), but this didn't always work, especially for complex types that were defined in classes the cache explorer didn't have access to.

Spelunking through the private source code allowed me to find a private method that would return the serialised value as a 2-dimensional array of bytes,  which I could then show on screen, giving anyone using the tool a far better chance of understanding what was cached and validating if it made sense.