using MediatR;

namespace Arex388.Extensions.MediatR {
	/// <summary>
	/// An asynchronous returning request handler.
	/// </summary>
	/// <typeparam name="TRequest">The type of request being handled.</typeparam>
	/// <typeparam name="TResponse">The type of response from the handler.</typeparam>
	public interface IAsyncHandler<in TRequest, TResponse> :
		IRequestHandler<TRequest, TResponse>
		where TRequest : IRequest<TResponse> {
	}
}