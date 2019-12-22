using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.BusinessLogicLayer.Services.Notes.Models
{
    public class NotePreviewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ShortText { get; set; }
        public bool TextIsTrimed { get; set; }
    }
}
