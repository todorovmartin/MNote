using Microsoft.EntityFrameworkCore;
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
            notebook.Notes = new List<Note>();
            this.db.NoteBooks.Add(notebook);
            this.db.SaveChanges();
        }

        public void DeleteNotebook(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notebook> GetAllNotebooks(string username)
        {
            //var notebooks = this.db.NoteBooks.Where(x => x.User.UserName == username).ToList();
            var notebooks = this.db.NoteBooks.Include(x => x.Notes).Where(x => x.User.UserName == username).ToList();

            return notebooks;
        }

        public Notebook GetNotebookById(int id)
        {
            var notebook = this.db.NoteBooks.Include(x => x.Notes).FirstOrDefault(x => x.Id == id);

            return notebook;
        }

        public bool RemoveNote(int id, string username)
        {
            throw new NotImplementedException();
        }
    }
}
