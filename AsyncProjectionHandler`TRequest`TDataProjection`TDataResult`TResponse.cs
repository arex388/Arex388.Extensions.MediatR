using MediatR;

namespace Arex388.Extensions.MediatR {
	/// <summary>
	/// A basic asynchronous returning projection request handler.
	/// </summary>
	/// <typeparam name="TRequest">The type of request being handled.</typeparam>
	/// <typeparam name="TDataProjection">The type of data projection container.</typeparam>
	/// <typeparam name="TDataResult">The type of data result container.</typeparam>
	/// <typeparam name="TResponse">The type of response from the handler.</typeparam>
	public abstract class AsyncProjectionHandler<TRequest, TDataProjection, TDataResult, TResponse> :
		AsyncHandler<TRequest, TResponse>,
		IAsyncProjectionHandler<TRequest, TDataProjection, TDataResult, TResponse>
		where TRequest : IRequest<TResponse>
		where TDataProjection : class
		where TDataResult : class {
		public abstract TDataProjection GetDataProjection(
			TRequest request);

		public abstract TDataResult GetDataResult(
			TRequest request);
	}
}