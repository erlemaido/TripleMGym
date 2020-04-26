using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingApp.Facade.Common
{
    public abstract class TitledEntityView : DefinedEntityView
    {
        [Required]
        public string Title { get; set; }
    }
}
