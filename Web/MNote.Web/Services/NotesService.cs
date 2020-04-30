using Microsoft.VisualBasic.CompilerServices;
using MNote.Data;
using MNote.Data.Models;
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

        public NotesService(MNoteDbContext db)
        {
            this.db = db;
        }

        public void ArchiveNote(int id)
        {
            var note = this.GetNoteById(id);

            note.IsActive = false;
        }

        public void UnarchiveNote(int id)
        {
            var note = this.GetNoteById(id);

            note.IsActive = true;
        }

        public void CreateNote(Note note)
        {
            if (note == null)
            {
                return;
            }

            this.db.Add(note);
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

        public IEnumerable<Note> GetAllNotes()
        {
            return this.db.Notes.ToList();
        }

        public Note GetNoteById(int id)
        {
            var note = this.db.Notes.FirstOrDefault(x => x.Id == id);

            return note;
        }

        public IEnumerable<Note> GetNotesByNotebook(int notebookId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> GetNotesBySearch(string searchString)
        {
            throw new NotImplementedException();
        }

        public void PinNote(int id)
        {
            var note = this.GetNoteById(id);

            note.IsPinned = true;
        }

        public void UnpinNote(int id)
        {
            var note = this.GetNoteById(id);

            note.IsPinned = false;
        }
    }
}
