namespace MNote.Web.ViewModels.Notes
{
    using MNote.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateNotebookViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "\"{0}\" is reqired.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "\"{0}\" should be min {2} and max {1}.")]
        public string Title { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
