using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEScs_1
{
    class ExperimentType
    {
        private string title;
        private int nmrOfReplications;

        public ExperimentType(string title, int nmrOfReplications)
        {
            this.title = title;
            this.nmrOfReplications = nmrOfReplications;
        }
    }
}
