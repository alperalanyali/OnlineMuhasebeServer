using System;
using MediatR;

namespace Application.Messaging
{
	public interface IQuery<out TResponse>:IRequest<TResponse>
	{
	}
}

