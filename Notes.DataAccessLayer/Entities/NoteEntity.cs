using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.DataAccessLayer.Entities
{
    public class NoteEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Text { get; set; }
    }
}
