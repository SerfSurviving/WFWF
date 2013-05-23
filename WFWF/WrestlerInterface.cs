using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WFWF
{
    private enum rating { C = 1, B, A, S };
    interface modifierInterface
    {
        public string minAtt { get; }
        public string maxAatt { get; }
        public string[] skillMods { get; }
    }
    interface attributeInterface
    {
        public rating aptitude { get; }
    }
    interface experienceInterface
    {
        public rating level { get; }

        public byte exp { get; }
        public void addExp(byte total);
    }
    interface bodypartInterface
    {
        public rating damage { get; }
        public rating beauty { get; }
        public void hurt();
        public void heal(bool hospital = false);
    }
    interface WrestlerInterface
    {
        public static bool init();

        public string name { get; }

        public attribute getAttribute(string key);
        public experience getGeneralSkill(string key);
        public experience getWrestlingSkill(string key);
        public bodypart getBodyPart(string key);

        public void expGeneralSkill(string key, byte val);
        public void expWrestlingSkill(string key, byte val);
    }
}
