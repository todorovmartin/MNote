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
        private const int DefaultPageSize = 8;
        private const int DefaultPageNumber = 1;

        private readonly INotebooksService notebooksService;
        private readonly IMapper mapper;

        public NotebooksController(INotebooksService notebooksService, IMapper mapper)
        {
            this.notebooksService = notebooksService;
            this.mapper = mapper;
        }

        public IActionResult All(int? pageNumber, int? pageSize)
        {
            var products = this.notebooksService.GetAllNotebooks(this.User.Identity.Name).OrderByDescending(x => x.Id).ToList();

            pageNumber = pageNumber ?? DefaultPageNumber;
            pageSize = pageSize ?? DefaultPageSize;

            var pageProductsViewModel = products.ToPagedList(pageNumber.Value, pageSize.Value);

            var model = pageProductsViewModel.Select(x => new AllNotesViewModel
            {
                Id = x.Id,
                Title = x.Title,
                DateCreated = x.DateCreated,
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

    }
}