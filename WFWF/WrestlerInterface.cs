using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WFWF
{
    enum rating { C = 1, B, A, S };
    interface modifierInterface
    {
        string minAtt { get; }
        string maxAtt { get; }
        string[] skillMods { get; }
    }
    interface attributeInterface
    {
        rating aptitude { get; }
    }
    interface experienceInterface
    {
        byte level { get; }

        byte exp { get; }
        void addExp(byte total);
    }
    interface bodypartInterface
    {
        rating damage { get; }
        rating beauty { get; }
        void hurt();
        void heal(bool hospital = false);
    }
    interface WrestlerInterface
    {
        //string name { get; }

        attribute getAttribute(string key);
        experience getGeneralSkill(string key);
        experience getWrestlingSkill(string key);
        bodypart getBodyPart(string key);

        void expGeneralSkill(string key, byte val);
        void expWrestlingSkill(string key, byte val);
    }
}
