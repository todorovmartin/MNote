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
    public class NotebooksController : BaseController
    {
        private const int DefaultPageSize = 15;
        private const int DefaultPageNumber = 1;

        private readonly INotebooksService notebooksService;
        private readonly INotesService notesService;
        private readonly IMapper mapper;

        public NotebooksController(INotebooksService notebooksService, IMapper mapper, INotesService notesService)
        {
            this.notebooksService = notebooksService;
            this.mapper = mapper;
            this.notesService = notesService;
        }

        public IActionResult All(int? pageNumber, int? pageSize)
        {
            var products = this.notebooksService.GetAllNotebooks(this.User.Identity.Name).OrderByDescending(x => x.Id).ToList();

            pageNumber = pageNumber ?? DefaultPageNumber;
            pageSize = pageSize ?? DefaultPageSize;

            var pageProductsViewModel = products.ToPagedList(pageNumber.Value, pageSize.Value);

            var model = pageProductsViewModel.Select(x => new AllNotebooksViewModel
            {
                Id = x.Id,
                Title = x.Title,
                DateCreated = x.DateCreated,
                Notes = x.Notes,
            });

            return this.View(model);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateNotebookViewModel model)
        {
            var notebook = this.mapper.Map<Notebook>(model);

            this.notebooksService.CreateNotebook(notebook, this.User.Identity.Name);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Details(int? pageNumber, int? pageSize, int notebookId)
        {
            var products = this.notesService.GetNotesByNotebook(notebookId).OrderByDescending(x => x.Id).ToList();

            pageNumber = pageNumber ?? DefaultPageNumber;
            pageSize = pageSize ?? DefaultPageSize;

            var pageProductsViewModel = products.ToPagedList(pageNumber.Value, pageSize.Value);

            var model = pageProductsViewModel.Select(x => new DetailNotebookViewModel
            {
                Id = x.Id,
                Title = x.Title,
                DateCreated = x.DateCreated,
                Notes = x.Notebook.Notes,
            });

            return this.View(model);
        }
    }
}