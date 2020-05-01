namespace MNote.Data.Models.Enums
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [DefaultValue(light)]
    public enum NoteColor
    {
        [Display(Name = "White")]
        light = 0,

        [Display(Name = "Gray")]
        secondary = 1,

        [Display(Name = "Green")]
        success = 2,

        [Display(Name = "Red")]
        danger = 3,

        [Display(Name = "Blue")]
        primary = 5,

        [Display(Name = "Yellow")]
        warning = 6,

        [Display(Name = "Black")]
        dark = 7,
    }
}
