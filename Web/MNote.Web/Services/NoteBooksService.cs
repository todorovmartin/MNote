using MNote.Data;
using MNote.Data.Models;
using MNote.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MNote.Web.Services
{
    public class NotebooksService : INotebooksService
    {
        private readonly MNoteDbContext db;
        private readonly IUsersService usersService;

        public NotebooksService(MNoteDbContext db, IUsersService usersService)
        {
            this.db = db;
            this.usersService = usersService;
        }

        public bool AddNote(int id, string username)
        {
            throw new NotImplementedException();
        }

        public void CreateNotebook(Notebook notebook, string username)
        {
            if (notebook == null)
            {
                return;
            }

            notebook.User = this.usersService.GetUserByUsername(username);
            this.db.NoteBooks.Add(notebook);
            this.db.SaveChanges();
        }

        public void DeleteNotebook(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notebook> GetAllNotebooks(string username)
        {
            throw new NotImplementedException();
        }

        public Notebook GetNotebookById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveNote(int id, string username)
        {
            throw new NotImplementedException();
        }
    }
}
