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
        private readonly INotebooksService notebooksService;
        private readonly IMapper mapper;

        public NotesController(INotesService notesService, IMapper mapper, INotebooksService notebooksService)
        {
            this.notesService = notesService;
            this.notebooksService = notebooksService;
            this.mapper = mapper;
        }

        public IActionResult All(int? pageNumber, int? pageSize)
        {
            var notes = this.notesService.GetAllNotes(this.User.Identity.Name).OrderByDescending(x => x.Id).ToList();

            pageNumber = pageNumber ?? DefaultPageNumber;
            pageSize = pageSize ?? DefaultPageSize;

            var pageProductsViewModel = notes.ToPagedList(pageNumber.Value, pageSize.Value);

            var allNotebooks = this.notebooksService.GetAllNotebooks(this.User.Identity.Name).ToList();
            this.ViewBag.allNotebooks = allNotebooks;

            var notesModel = pageProductsViewModel.Select(x => new AllNotesViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                DateCreated = x.DateCreated,
                NoteColor = x.NoteColor.ToString(),
            });

            return this.View(notesModel);
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
            var note = this.notesService.GetNoteById(noteId);

            if (note == null)
            {
                return this.NotFound();
            }

            var model = this.mapper.Map<EditNoteViewModel>(note);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditNoteViewModel model)
        {
            var note = this.mapper.Map<Note>(model);

            this.notesService.EditNote(note);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Delete(int id)
        {
            this.notesService.DeleteNote(id);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult ArchiveUnarchive(int id)
        {
            if (this.notesService.GetNoteById(id).IsActive == true)
            {
                this.notesService.ArchiveNote(id);
            }
            else
            {
                this.notesService.UnarchiveNote(id);
            }

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult PinUnpin(int id)
        {
            if (this.notesService.GetNoteById(id).IsPinned == true)
            {
                this.notesService.UnpinNote(id);
            }
            else
            {
                this.notesService.PinNote(id);
            }

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult AddToNotebook(int noteId, int notebookId)
        {
            this.notesService.AddNoteToNotebook(noteId, notebookId);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}