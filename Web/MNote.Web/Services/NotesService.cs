using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic.CompilerServices;
using MNote.Data;
using MNote.Data.Models;
using MNote.Data.Models.Enums;
using MNote.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MNote.Web.Services
{
    public class NotesService : INotesService
    {
        private readonly MNoteDbContext db;
        private readonly IUsersService usersService;
        private readonly INotebooksService notebooksService;

        public NotesService(MNoteDbContext db, IUsersService usersService, INotebooksService notebooksService)
        {
            this.db = db;
            this.usersService = usersService;
            this.notebooksService = notebooksService;
        }

        public void ArchiveNote(int id)
        {
            var note = this.GetNoteById(id);

            note.IsActive = false;

            this.db.Update(note);
            this.db.SaveChanges();
        }

        public void UnarchiveNote(int id)
        {
            var note = this.GetNoteById(id);

            note.IsActive = true;

            this.db.Update(note);
            this.db.SaveChanges();
        }

        public void CreateNote(Note note, string username)
        {
            if (note == null)
            {
                return;
            }

            note.User = this.usersService.GetUserByUsername(username);
            this.db.Notes.Add(note);
            this.db.SaveChanges();
        }

        public void DeleteNote(int id)
        {
            var note = this.GetNoteById(id);

            note.IsDeleted = true;
        }

        public bool NoteExists(int id)
        {
            return this.db.Notes.Any(x => x.Id == id);
        }

        public bool EditNote(Note note)
        {
            if (!this.NoteExists(note.Id))
            {
                return false;
            }

            try
            {
                this.db.Update(note);
                this.db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IEnumerable<Note> GetAllNotes(string username)
        {
            var notes = this.db.Notes.Where(x => x.User.UserName == username).ToList();

            return notes;
        }

        public Note GetNoteById(int id)
        {
            var note = this.db.Notes.FirstOrDefault(x => x.Id == id);

            return note;
        }

        public IEnumerable<Note> GetNotesByNotebook(int notebookId)
        {
            var notes = this.db.Notes.Where(x => x.NotebookId == notebookId).ToList();

            return notes;
        }

        public IEnumerable<Note> GetNotesBySearch(string searchString)
        {
            throw new NotImplementedException();
        }

        public void PinNote(int id)
        {
            var note = this.GetNoteById(id);

            note.IsPinned = true;

            this.db.Update(note);
            this.db.SaveChanges();
        }

        public void UnpinNote(int id)
        {
            var note = this.GetNoteById(id);

            note.IsPinned = false;

            this.db.Update(note);
            this.db.SaveChanges();
        }

        void INotesService.EditNote(Note note)
        {
            throw new NotImplementedException();
        }

        public void AddNoteToNotebook(int noteId, int notebookId)
        {
            var note = this.GetNoteById(noteId);
            var notebook = this.notebooksService.GetNotebookById(notebookId);

            notebook.Notes.Add(note);
            this.db.SaveChanges();
        }

        public void ChangeNoteColor(int id, NoteColor color)
        {
            var note = this.GetNoteById(id);
            note.NoteColor = color;

            this.db.Update(note);
            this.db.SaveChanges();
        }
    }
}
