using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.Data.Common
{
    public abstract class DefinedEntityData : UniqueEntityData
    {
        public string Description { get; set; }
    }
}
