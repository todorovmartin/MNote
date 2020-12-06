using MNote.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNote.Web.ViewModels.Notes
{
    public class DetailNotebookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
