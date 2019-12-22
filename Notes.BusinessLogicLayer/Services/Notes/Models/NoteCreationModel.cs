using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Notes.BusinessLogicLayer.Services.Notes.Models
{
    public class NoteCreationModel
    {
        [Required]
        public string Text { get; set; }
    }
}
