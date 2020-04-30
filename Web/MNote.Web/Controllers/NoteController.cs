namespace MNote.Web.Controllers
{
    using System.Diagnostics;

    using MNote.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class NoteController : BaseController
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
