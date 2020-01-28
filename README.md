

# Arex388.Extensions.MediatR

A small set of [MediatR][2] handler interfaces for implementing the [Projection-Result pattern][3]. Also contains basic handler implementations, but I recommend that you implement the interfaces in your project so you can inject the appropriate services for your application.

#### Interfaces

- `IAsyncHandler<TRequest>` - An asynchronous non-returning request handler.
- `IAsyncHandler<TRequest, TResponse>` - An asynchronous returning request handler.
- `IAsyncProjectionHandler<TRequest, TDataProjection, TResponse>` - An asynchronous returning projection request handler.

#### How to Use

I typically implement the interfaces as abstract classes I can inherit from. In the abstract classes I inject services such as Entity Framework and [AutoMapper][1]. I use [EntityFramework-Plus][0] for its future queries to build up my projections and then AutoMapper to map them to the final response.

Here's an example of a view handler that pulls a list of customers by their status from the database, projects the results, and then returns a model for the view to render. Abstract classes are included for reference.

```c#
public abstract class AsyncHandler<TRequest, TResponse> :
    IAsyncHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse> {
    protected DbContext Context { get; }
    protected IMapper Mapper { get; }
    protected IConfigurationProvider MapperConfig => Mapper.ConfigurationProvider;

    protected AsyncHandler(
        DbContext context,
        IMapper mapper) {
        Context = context;
        Mapper = mapper;
    }

    public abstract Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken);
}

public abstract class AsyncProjectionHandler<TRequest, TDataProjection, TResponse> :
    AsyncHandler<TRequest, TResponse>,
    IAsyncProjectionHandler<TRequest, TDataProjection, TResponse>
    where TRequest : IRequest<TResponse>
    where TDataProjection : class, new()
    where TResponse : class {
    protected AsyncProjectionHandler(
        DbContext context,
        IMapper mapper) :
        base(context, mapper) {
    }

    public override Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken) {
        var response = GetResponse(request);

        return Task.FromResult(response);
    }

    public abstract TDataProjection GetDataProjection(
        TRequest request);

    public virtual TResponse GetResponse(
        TRequest request) {
        var projection = GetDataProjection(request);

        return Mapper.Map<TResponse>(projection);
    }
}

public sealed class CustomersByStatus {
    public sealed class View {
        public IEnumerabl<CustomerProjection> Customers { get; set; }
    }

    public sealed class ViewDataProjection {
        public QueryFutureEnumerable<CustomerProjection> Customers { get; set; }
    }

    public sealed class ViewHandler :
    	AsyncProjectionHandler<ViewQuery, ViewDataProjection, View> {
    	public ViewHandler(
            DbContext context,
            IMapper mapper) :
            base(context, mapper) {
        }

        public override ViewDataProjection GetDataProjection(
            ViewQuery query) => new ViewDataProjection {
            Customers = GetCustomers()
        };

        //  Future Queries

        private QueryFutureEnumerable<CustomerProjection> GetCustomers(
            ViewQuery query) => Context.Customers.AsNoTracking().Where(
            c => c.IsActive == query.IsActive).ProjectTo<CustomerProjection>(MapperConfig).Future();
    }

    public sealed class ViewQuery :
        IRequest<View> {
        public bool IsActive { get; set; }
    }

    //  Mappings

    public sealed class Mappings :
        AutoMapper.Profile {
        public Mappings() {
            CreateMap<Customer, CustomerProjection>();
        }
    }

    //  Models

    public sealed class CustomerProjection {
    	public string Name { get; set; }
    }
}
```

#### Why?

My goal with these extensions is to provide a clear and structured way to create MediatR handlers and to allow for the most efficient way to query for data needed by the handler while also being easy to use.

[0]:https://github.com/zzzprojects/EntityFramework-Plus
[1]: https://github.com/AutoMapper/AutoMapper
[2]: https://github.com/jbogard/MediatR
[3]:https://arex388.com/blog/projection-result-pattern-improving-on-the-projection-view-pattern