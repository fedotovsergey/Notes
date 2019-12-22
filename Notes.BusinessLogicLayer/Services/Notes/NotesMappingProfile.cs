using AutoMapper;
using Notes.BusinessLogicLayer.Services.Notes.Models;
using Notes.DataAccessLayer.Entities;
using System;
using Notes.BusinessLogicLayer.Services.Notes.Models;

namespace Notes.BusinessLogicLayer.Services.Notes
{
    public class NotesMappingProfile : Profile
    {
        public NotesMappingProfile()
        {
            const int previewMaxLength = 30;

            CreateMap<NoteEntity, NotePreviewModel>()
                .ForMember(d => d.ShortText, opts => opts.MapFrom(s =>  s.Text.Substring(0, Math.Min(previewMaxLength, s.Text.Length))))
                .ForMember(d => d.TextIsTrimed, opts => opts.MapFrom(s => s.Text.Length > previewMaxLength));

            CreateMap<NoteEntity, NoteModel>();

        }
    }
}
