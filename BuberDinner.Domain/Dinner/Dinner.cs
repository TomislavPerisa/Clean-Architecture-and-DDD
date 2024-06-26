﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner
{
    public sealed class Dinner : AggregateRoot<DinnerId>
    {
        private readonly List<Reservation> _reservations = new();

        private Dinner(
            DinnerId dinnerId,
            string name,
            string description,
            Status status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location)
            : base(dinnerId)
        {
            Name = name;
            Description = description;
            StartDateTime = DateTime.UtcNow;
            EndDateTime = DateTime.UtcNow;
            StartedDateTime = DateTime.UtcNow;
            EndedDateTime = DateTime.UtcNow;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
            CreatedDateTime = DateTime.UtcNow;
            UpdatedDateTime = DateTime.UtcNow;
        }

        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime? StartedDateTime { get; }
        public DateTime? EndedDateTime { get; }
        public Status Status { get; }
        public bool IsPublic { get; }
        public int MaxGuests { get; }
        public Price Price { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public string ImageUrl { get; }
        public Location Location { get; }
        public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public static Dinner Create(
            string name,
            string description,
            Status status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            MenuId menuId,
            string imageUrl,
            Location location)
        {
            return new(
                DinnerId.CreateUnique(),
                name,
                description,
                status,
                isPublic,
                maxGuests,
                price,
                hostId,
                menuId,
                imageUrl,
                location);
        }
    }
}
