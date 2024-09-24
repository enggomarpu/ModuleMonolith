﻿using MediatR;
using System;

namespace Shared.DDD
{
	public class IDomainEvent : INotification
	{
		Guid EventId => Guid.NewGuid();
		public DateTime OccurredOn => DateTime.Now;
		public string EventType => GetType().AssemblyQualifiedName!;
	}
}
