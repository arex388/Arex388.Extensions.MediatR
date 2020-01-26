using MediatR;

namespace Arex388.Extensions.MediatR {
	/// <summary>
	/// An asynchronous returning projection request handler.
	/// </summary>
	/// <typeparam name="TRequest">The type of request being handled.</typeparam>
	/// <typeparam name="TDataProjection">The type of data projection container.</typeparam>
	/// <typeparam name="TResponse">The type of response from the handler.</typeparam>
	public interface IAsyncProjectionHandler<in TRequest, out TDataProjection, TResponse> :
		IAsyncHandler<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
		where TDataProjection : class {
		TDataProjection GetDataProjection(
			TRequest request);

		TResponse GetResponse(
			TRequest request);
	}
}