namespace MNote.Web.ViewModels.Notes
{
    using MNote.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateNoteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "\"{0}\" is reqired.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "\"{0}\" should be min {2} and max {1}.")]
        public string Title { get; set; }

        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Color")]
        public string NoteColor { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        //[Display(Name = "Notebook")]
        //[Required(ErrorMessage = "\"{0}\" is required.")]
        //public string Notebook { get; set; }
    }
}
