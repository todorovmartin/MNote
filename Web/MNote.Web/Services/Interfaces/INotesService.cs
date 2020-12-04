namespace MNote.Web.Services.Interfaces
{
    using System.Collections.Generic;

    using MNote.Data.Models;
    using MNote.Data.Models.Enums;

    public interface INotesService
    {
        Note GetNoteById(int id);

        bool NoteExists(int id);

        void CreateNote(Note note, string username);

        void DeleteNote(int id);

        void PinNote(int id);

        void UnpinNote(int id);

        void EditNote(Note note);

        void ArchiveNote(int id);

        void UnarchiveNote(int id);

        void AddNoteToNotebook(int id);

        void ChangeNoteColor(int id, NoteColor color);

        IEnumerable<Note> GetNotesBySearch(string searchString);

        IEnumerable<Note> GetAllNotes(string username);

        IEnumerable<Note> GetNotesByNotebook(int notebookId);
    }
}
