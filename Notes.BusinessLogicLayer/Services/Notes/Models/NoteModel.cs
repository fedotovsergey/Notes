using System;

namespace Notes.BusinessLogicLayer.Services.Notes.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Text { get; set; }
    }
}
