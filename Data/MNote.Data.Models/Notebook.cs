using System;
using System.Collections.Generic;

namespace MNote.Data.Models
{
    public class Notebook
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
