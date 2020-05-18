using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TrainingApp.Facade.Common
{
    public abstract class PeriodView
    {
        [DisplayName("Registreerimise aeg")]
        public DateTime? ValidFrom { get; set; }

        [DisplayName("Kehtiv kuni")]
        public DateTime? ValidTo { get; set; }
    }
}
