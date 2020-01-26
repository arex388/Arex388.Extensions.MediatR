using MediatR;

namespace Arex388.Extensions.MediatR {
	/// <summary>
	/// An asynchronous non-returning request handler.
	/// </summary>
	/// <typeparam name="TRequest">The type of request being handled.</typeparam>
	public interface IAsyncHandler<in TRequest> :
		IAsyncHandler<TRequest, Unit>
		where TRequest : IRequest<Unit> {
	}
}