using System;
using System.Collections.Generic;
using System.Text;

namespace MNote.Web.ViewModels.Notes
{
    public class AllNotesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string NoteColor { get; set; }
    }
}
