using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Models
{
    public class Cat : Animal
    {
        private const string CAT_SOUND = "MEEOW";

        public Cat(string name, string favFood)
            : base(name, favFood)
        {

        }
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + CAT_SOUND;
        }
    }
}
