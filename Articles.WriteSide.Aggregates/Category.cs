﻿using Articles.WriteSide.Events.ToSaga;
using Infrastructure.Contracts;
using Infrastructure.Domain;
using System;

namespace Articles.WriteSide.Aggregates
{
	public class Category :
		AggregateRoot,
		IHandle<CategoryDeletedEvent>,
		IHandle<CategoryInsertedEvent>
	{
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }
		public int Importance { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }

		public Category()
		{

		}
		public Category(
			Guid id,
			DateTime AddedDate,
			string AddedBy,
			string Title,
			int Importance,
			string Description,
			string ImageUrl)
		{
			var @event = new CategoryInsertedEvent
			{
				AggregateId = id,
				AddedBy = AddedBy,
				AddedDate = AddedDate,
				Description = Description,
				ImageUrl = ImageUrl,
				Importance = Importance,
				Title = Title
			};
			ApplyChange(@event);
		}

		public void Update(
			string title,
			int importance,
			string description,
			string imageUrl)
		{
			var @event = new CategoryUpdatedEvent
			{
				AggregateId = Id,
				Description = description,
				ImageUrl = imageUrl,
				Importance = importance,
				Title = title
			};
			ApplyChange(@event);
		}

		public void Delete()
		{
			var @event = new CategoryDeletedEvent
			{
				AggregateId = Id
			};
			ApplyChange(@event);
		}

		public void Handle(CategoryInsertedEvent @event)
		{
			AddedBy = @event.AddedBy;
			AddedDate = @event.AddedDate;
			Id = @event.AggregateId;
			Description = @event.Description;
			ImageUrl = @event.ImageUrl;
			Importance = @event.Importance;
			Title = @event.Title;
		}

		public void Handle(CategoryDeletedEvent @event)
		{
			Id = @event.AggregateId;
		}

	}
}