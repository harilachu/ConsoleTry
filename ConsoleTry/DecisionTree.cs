using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTry
{
    public class DecisionTree
    {
        public int Id { get; set; }
        public bool flag { get; set; }
        public string IsValidated { get; set; }

        public bool ValidateDecisionTree()
        {
            return (Id, flag, IsValidated) switch
            {
                (1, true, "true") => false,
                (1, false, "true") => true,
                (2, _, _) => true,
                (1, true, _) => true,
                (1, false, _)=> false,
            };
        }
    }
}
