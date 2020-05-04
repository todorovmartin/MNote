namespace MNote.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MNote.Data.Models;
    using MNote.Web.Services.Interfaces;
    using MNote.Web.ViewModels.Notes;
    using X.PagedList;

    [Authorize]
    public class NotesController : BaseController
    {
        private const int DefaultPageSize = 8;
        private const int DefaultPageNumber = 1;

        private readonly INotesService notesService;
        private readonly IMapper mapper;

        public NotesController(INotesService notesService, IMapper mapper)
        {
            this.notesService = notesService;
            this.mapper = mapper;
        }

        public IActionResult All(int? pageNumber, int? pageSize)
        {
            var products = this.notesService.GetAllNotes().OrderByDescending(x => x.Id).ToList();

            pageNumber = pageNumber ?? DefaultPageNumber;
            pageSize = pageSize ?? DefaultPageSize;

            var pageProductsViewModel = products.ToPagedList(pageNumber.Value, pageSize.Value);

            var model = pageProductsViewModel.Select(x => new AllNotesViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                DateCreated = x.DateCreated,
                NoteColor = x.NoteColor.ToString(),
            });

            return this.View(model);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateNoteViewModel model)
        {
            var note = this.mapper.Map<Note>(model);

            this.notesService.CreateNote(note, this.User.Identity.Name);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Edit(int noteId)
        {
            return this.View();
        }
    }
}
