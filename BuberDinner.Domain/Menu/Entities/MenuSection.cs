﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        private MenuSection(MenuSectionId menuSectionId, string name, string description) : base(menuSectionId)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; }
        public string Description { get; }

        public IReadOnlyList<MenuItem> items => _items.AsReadOnly();
        public static MenuSection Create(string name, string description)
        {
            return new(MenuSectionId.CreateUnique(), name, description);
        }
    }
}
