using MNote.Data.Models;
using System.Collections.Generic;

namespace MNote.Web.Services.Interfaces
{
    public interface INotebooksService
    {
        void CreateNotebook(Notebook notebook, string username);

        void DeleteNotebook(int id);

        bool AddNote(int id, string username);

        bool RemoveNote(int id, string username);

        IEnumerable<Notebook> GetAllNotebooks(string username);

        Notebook GetNotebookById(int id);
    }
}
