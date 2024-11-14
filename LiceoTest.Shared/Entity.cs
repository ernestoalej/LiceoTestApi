using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiceoTest.Shared
{
	public abstract class Entity : AuditableEntity
	{
		private List<INotification>? _domainEvents;
		private int? _requestedHashCode;

		public virtual int Id { get; set; }

		public IReadOnlyCollection<INotification>? DomainEvents => _domainEvents?.AsReadOnly();

		public void AddDomainEvent(INotification eventItem)
		{
			_domainEvents = _domainEvents ?? new List<INotification>();
			_domainEvents.Add(eventItem);
		}

		public void RemoveDomainEvent(INotification eventItem)
		{
			_domainEvents?.Remove(eventItem);
		}

		public void ClearDomainEvents()
		{
			_domainEvents?.Clear();
		}

		public bool IsTransient()
		{
			return Id == default;
		}

		public override bool Equals(object? obj)
		{
			var entity = obj as Entity;
			if (entity is null)
				return false;

			if (ReferenceEquals(this, entity))
				return true;

			if (GetType() != entity.GetType())
				return false;

			var item = entity;

			if (item.IsTransient() || IsTransient())
				return false;

			return item.Id == Id;
		}

		public override int GetHashCode()
		{
			if (!IsTransient())
			{
				_requestedHashCode ??= Id.GetHashCode() ^ 31;

				return _requestedHashCode.Value;
			}

			return base.GetHashCode();
		}

		public static bool operator ==(Entity left, Entity right)
		{
			if (Equals(left, null))
				return Equals(right, null);

			return left.Equals(right);
		}

		public static bool operator !=(Entity left, Entity right)
		{
			return !(left == right);
		}
	}
}
