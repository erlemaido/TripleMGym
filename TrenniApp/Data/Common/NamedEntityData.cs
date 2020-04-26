using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.Data.Common
{
    public abstract class NamedEntityData : DefinedEntityData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
