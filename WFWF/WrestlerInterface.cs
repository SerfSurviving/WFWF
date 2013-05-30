using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WFWF
{
    public enum rating { C = 1, B, A, S };
    interface modifierInterface
    {
        String minAtt { get; }
        String maxAtt { get; }
         String [] skillMods { get; }
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
        Wrestler.attribute getAttribute( String  key);
        Wrestler.experience getGeneralSkill( String  key);
        Wrestler.experience getWrestlingSkill( String  key);
        Wrestler.bodypart getBodyPart( String  key);

        void expGeneralSkill( String  key, byte val);
        void expWrestlingSkill( String  key, byte val);
    }

    /// <summary>
    /// Used to define a wrestler in game, several static fields of data
    /// are kept within the class after loading it from files so that wrestlers
    /// can be copied into other wrestlers, along with keeping the data required
    /// to do things with the skills
    /// </summary>
    public partial class Wrestler : WrestlerInterface
    {
        /// <remarks>
        /// Static dictionaries that will be copied for wrestlers
        /// Generic attributes are strings that will be referenced in
        /// the dictionaries keys in the other skills, as of now they don't
        /// need to hold information statically
        /// </remarks>
        private static String[] genericAttributes;
        /// <remarks>
        /// General skills are a dictionary, with the key being the name of the
        /// and the value being an attribute
        /// </remarks>
        private static Dictionary<String, String> genericGeneralSkills;
        /// <remarks>
        /// Contains all the static information for leveling up a skill, the
        /// String key is the name of the skill, the modifier holds all the
        /// experience modifier information
        /// </remarks>
        private static Dictionary<String, modifier> genericWrestlingSkills;
        /// <remarks>
        /// An array that holds the dictionary values for the body parts,
        /// we don't need to hold any information statically as of yet
        /// </remarks>
        private  String [] genericBodyParts;

        /// <remarks>
        /// The personal skill and attribute dictionaries for wrestlers
        /// </remarks>
        private Dictionary<String, attribute> __attributes;
        private Dictionary<String, experience> __generalSkills;
        private Dictionary<String, experience> __wrestlingSkills;
        private Dictionary<String, bodypart> __bodyParts;

        private static bool isinit = false;
    }
}
