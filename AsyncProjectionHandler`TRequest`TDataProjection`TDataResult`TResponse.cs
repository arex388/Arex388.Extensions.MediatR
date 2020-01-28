using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Arex388.Extensions.MediatR {
	public abstract class AsyncProjectionHandler<TRequest, TDataProjection, TDataResult, TResponse> :
		AsyncProjectionHandler<TRequest, TDataProjection, TResponse>,
		IAsyncProjectionHandler<TRequest, TDataProjection, TDataResult, TResponse>
		where TRequest : IRequest<TResponse>
		where TDataProjection : class
		where TResponse : class {
		public abstract TDataResult GetDataResult(
			TRequest request);
	}
}
