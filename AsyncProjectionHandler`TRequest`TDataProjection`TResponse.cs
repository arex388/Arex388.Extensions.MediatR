using MediatR;

namespace Arex388.Extensions.MediatR {
	/// <summary>
	/// A basic asynchronous returning projection request handler.
	/// </summary>
	/// <typeparam name="TRequest">The type of request being handled.</typeparam>
	/// <typeparam name="TDataProjection">The type of data projection container.</typeparam>
	/// <typeparam name="TResponse">The type of response from the handler.</typeparam>
	public abstract class AsyncProjectionHandler<TRequest, TDataProjection, TResponse> :
		AsyncHandler<TRequest, TResponse>,
		IAsyncProjectionHandler<TRequest, TDataProjection, TResponse>
		where TRequest : IRequest<TResponse>
		where TDataProjection : class {
		public abstract TDataProjection GetDataProjection(
			TRequest request);

		public abstract TResponse GetResponse(
			TRequest request);
	}
}