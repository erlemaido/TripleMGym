using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.Data.Common
{
    public abstract class TitledEntityData : DefinedEntityData
    {
        public string Title { get; set; }
    }
}
