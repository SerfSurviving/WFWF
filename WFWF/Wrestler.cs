using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WFWF
{
    // TO DO: Implement modifiers.

    struct modifier : modifierInterface
    {
        
    }

    struct attribute : attributeInterface
    {
        private rating __aptitude;
        public rating aptitude 
        { 
            get 
            {
                return __aptitude; 
            } 
        }

        public attribute(rating attRating = rating.C)
        {
            __aptitude = attRating;
        }
    }
    
    struct experience : experienceInterface
    {
        private static const byte expToLevel = 100;
        private static const byte maxLevel = 100;

        private byte __level;
        public byte level 
        {
            get
            {
                return __level;
            }
        }

        private byte __exp;
        public byte exp 
        {
            get
            {
                return __exp;
            }
        }

        public void addExp(byte total)
        {
            int newexp = __exp  + total;
            if (newexp > expToLevel)
            {
                if (__level < maxLevel)
                {
                    __level++;
                    newexp -= expToLevel;
                }

                else
                {
                    return;
                }
            }

            Debug.Assert(newexp <= byte.MaxValue, 
                "Experience not properly handled, check addExp");
            Debug.Assert(__level < maxLevel,
                "Wrestler's level changed above max, check addExp");

            __exp = (byte)newexp;
        }

        public experience(byte initialLevel = 0)
        {
            bool check = initialLevel <= expToLevel;
            Trace.Assert(check , String.Format(
                "Attempted to intialize an experience struct " +
                "with an initial level that was too high. Level of {0} was" +
                "asked for, but {1} is the max level. Check the file where" +
                "starting conditions for wrestlers are defined and make sure" +
                "no one has a level above the max.", initialLevel, maxLevel));

            if (!check)
            {
                throw new Exception("Level too high to fit within rules.");
            }

            __exp = 0;
            __level = initialLevel;
        }
    }

    struct bodypart : bodypartInterface
    {
    }

    class Wrestler : WrestlerInterface
    {
        // Static dictionaries that will be copied for wrestlers
        private static string[] genericAttributes;
        private static Dictionary<string, modifier> genericGeneralSkills;
        private static Dictionary<string, modifier> genericWrestlingSkills;
        private static Dictionary<string, modifier> genericBodyParts;

        // The personal skill and attribute dictionaries for wrestlers
        private Dictionary<string, attribute> __attributes;
        private Dictionary<string, experience> __generalSkills;
        private Dictionary<string, experience> __wrestlingSkills;
        private Dictionary<string, bodypart> __bodyParts;

        // Will initialize the dictionaries above, constructors will all check
        // for initialization before running, and will throw errors if
        // intialization does not work. init() will throw an error if it fails.
        private static bool isinit;
        public static bool init();

        // Accessors for the various dictionaries, because it returns a struct,
        // these will of course not be references to the actual dictionary
        // entries the wrestler hads, trace asserts are used because of how
        // modable the game is, it will give feedback to anyone else working
        // on modding it, but unlike Debug asserts (which should never happen)
        // these will throw exceptions
        public attribute getAttribute(string key)
        {
            bool hasKey = __attributes.ContainsKey(key);
            Trace.Assert(hasKey, String.Format(
                "Tried getting an atrribute called {0}, but did not find it" +
                "is this mispelled? Try searching the files for this name and" +
                "see if it's supposed to be there", key));
            if (!hasKey)
            {
                throw new Exception("Tried getting attribute that did not exist.");
            }
            return __attributes[key];
        }
        public experience getGeneralSkill(string key)
        {
            bool hasKey = __generalSkills.ContainsKey(key);
            Trace.Assert(hasKey, String.Format(
                "Tried getting an general skill called {0}, but did not find it" +
                "is this mispelled? Try searching the files for this name and" +
                "see if it's supposed to be there", key));
            if (!hasKey)
            {
                throw new Exception("Tried getting general skill that did not exist.");
            }
            return __generalSkills[key];
        }
        public experience getWrestlingSkill(string key)
        {
            bool hasKey = __wrestlingSkills.ContainsKey(key);
            Trace.Assert(hasKey, String.Format(
                "Tried getting an wrestling skill called {0}, but did not find it" +
                "is this mispelled? Try searching the files for this name and" +
                "see if it's supposed to be there", key));
            if (!hasKey)
            {
                throw new Exception("Tried getting wrestling skill that did not exist.");
            }
            return __wrestlingSkills[key];
        }
        public experience getBodyPart(string key)
        {
            bool hasKey = __wrestlingSkills.ContainsKey(key);
            Trace.Assert(hasKey, String.Format(
                "Tried getting an bodypart called {0}, but did not find it" +
                "is this mispelled? Try searching the files for this name and" +
                "see if it's supposed to be there", key));
            if (!hasKey)
            {
                throw new Exception("Tried getting bodypart that did not exist.");
            }
            return __bodyParts[key];
        }

        // These are, essentially, the setters for the different dicts, but 
        // you are only allowed to change things through the methods provided
        // So you can only change the skills by adding exp, and the body parts
        // by damaging them
        // TO DO: Make it so skills are properly modifying by experience
        public void expGenericSkill(string name, byte experience)
        {
            bool hasKey = __generalSkills.ContainsKey(name);
            Trace.Assert(hasKey, String.Format(
                "Tried getting an general skill called {0}, but did not find it" +
                "is this mispelled? Try searching the files for this name and" +
                "see if it's supposed to be there", name));
            if (!hasKey)
            {
                throw new Exception("Tried getting genericskill that did not exist.");
            }
            __generalSkills[name].addExp(experience);
        }
        public void expWrestlingSkill(string name, byte experience)
        {
            bool hasKey = __wrestlingSkills.ContainsKey(name);
            Trace.Assert(hasKey, String.Format(
                "Tried getting an wrestling skill called {0}, but did not find it" +
                "is this mispelled? Try searching the files for this name and" +
                "see if it's supposed to be there", name));
            if (!hasKey)
            {
                throw new Exception("Tried getting wrestling that did not exist.");
            }
            __wrestlingSkills[name].addExp(experience);
        }
    }
}
