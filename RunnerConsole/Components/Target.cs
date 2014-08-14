using System.Collections.Generic;

namespace Runner.Components
{
    public class Target
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return Location;
        }
    }
}