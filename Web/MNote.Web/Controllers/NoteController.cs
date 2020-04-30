namespace MNote.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class NoteController : BaseController
    {
        public IActionResult Create()
        {
            return this.View();
        }

        public IActionResult Edit(int noteId)
        {
            return this.View();
        }
    }
}
