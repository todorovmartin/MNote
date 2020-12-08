using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MNote.Data.Models;
using MNote.Web.ViewModels.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MNote.Web.MappingConfig
{
    public class MNoteMappingProfile : Profile
    {
        public MNoteMappingProfile()
        {
            this.CreateMap<CreateNoteViewModel, Note>();
            this.CreateMap<EditNoteViewModel, Note>();
            this.CreateMap<CreateNotebookViewModel, Notebook>();
            this.CreateMap<DetailNotebookViewModel, Notebook>();
            this.CreateMap<Notebook, DetailNotebookViewModel>();
        }
    }
}
