

# Arex388.Extensions.MediatR

A small set of [MediatR][2] handler interfaces for implementing the [Projection-Result pattern][3]. Also contains basic handler implementations, but I recommend that you implement the interfaces in your project so you can inject the appropriate services for your application.

#### Interfaces

- `IAsyncHandler<TRequest>` - An asynchronous non-returning request handler.
- `IAsyncHandler<TRequest, TResponse>` - An asynchronous returning request handler.
- `IAsyncProjectionHandler<TRequest, TDataProjection, TResponse>` - An asynchronous returning projection request handler.

#### How to Use

I typically implement the interfaces as abstract classes I can inherit from. In the abstract classes I inject services such as Entity Framework and [AutoMapper][1]. I use [EntityFramework-Plus][0] for its future queries to build up my projections and then AutoMapper to map them to the final response.

#### Why?

My goal with these extensions is to provide a clear and structured way to create MediatR handlers at to allow for the most efficient way to query for data needed by the handler while also being easy to use.

[0]:https://github.com/zzzprojects/EntityFramework-Plus
[1]: https://github.com/AutoMapper/AutoMapper
[2]: https://github.com/jbogard/MediatR
[3]:https://arex388.com/blog/projection-result-pattern-improving-on-the-projection-view-pattern