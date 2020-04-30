namespace MNote.Data.Models
{
    using System;

    using MNote.Data.Models.Enums;

    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsPinned { get; set; } = false;

        public bool IsDeleted { get; set; } = false;

        public NoteColor NoteColor { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int NotebookId { get; set; }

        public Notebook Notebook { get; set; }
    }
}
