using MediatR;

namespace Arex388.Extensions.MediatR {
	/// <summary>
	/// A basic asynchronous non-returning request handler.
	/// </summary>
	/// <typeparam name="TRequest">The type of request being handled.</typeparam>
	public abstract class AsyncHandler<TRequest> :
		AsyncHandler<TRequest, Unit>,
		IAsyncHandler<TRequest>
		where TRequest : IRequest<Unit> {
	}
}