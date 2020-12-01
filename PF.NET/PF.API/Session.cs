using System;

namespace PF.API
{
    [Serializable()]
    public class Session
    {
        public Encounter Encounter { get; set; }

        public Session()
        {
            Encounter = new Encounter();
        }

        public void AddCharacter(Character newChar)
        {
            Encounter.AddCharacter(newChar);
        }
    }
}
