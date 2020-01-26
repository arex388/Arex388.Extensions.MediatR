using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Arex388.Extensions.MediatR {
	/// <summary>
	/// A basic asynchronous returning request handler.
	/// </summary>
	/// <typeparam name="TRequest">The type of request being handled.</typeparam>
	/// <typeparam name="TResponse">The type of response form the handler.</typeparam>
	public abstract class AsyncHandler<TRequest, TResponse> :
		IAsyncHandler<TRequest, TResponse>
		where TRequest : IRequest<TResponse> {
		public abstract Task<TResponse> Handle(
			TRequest request,
			CancellationToken cancellationToken);
	}
}