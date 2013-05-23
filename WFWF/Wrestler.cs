using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WFWF
{
    /// <summary>
    /// The modifier struct holds a list of minimum attribute rating required
    /// to train a skill at a normal level, and the maximum attribute level
    /// with which training bonuses are confered above the minimum. It 
    /// holds a string that determines what gen skills are used for
    /// giving bonuses to wrestling skill training, of course, this is only
    /// used for wrestling skills.
    /// </summary>
    struct modifier : modifierInterface
    {
        // Constants
        private static string NOSKILL = "NOSK";

        // C# properties
        private string __minAtt;
        public string minAtt
        {
            get
            {
                return __minAtt;
            }
        }

        private string __maxAtt;
        public string maxAtt
        {
            get
            {
                return __maxAtt;
            }
        }

        private string[] __skillMods;
        public string[] skillMods 
        {
            get
            {
                return __skillMods;
            }
        }
        
        // Constructors
        public modifier(string in_minAtt, string in_maxAtt, string[] in_skillMods)
        {
            if (in_maxAtt == null || in_minAtt == null || in_skillMods == null)
            {
                throw new Exception("Attribute array null.");
            }

            bool size_match = in_minAtt.Length == in_maxAtt.Length;
 
            Trace.Assert(size_match, String.Format(
                "Error, got two in attribute arrays with" +
                "different sizes, {0} is the first string, {1} is the " +
                "second string", in_minAtt, in_maxAtt));
            if (!size_match)
            {
                throw new Exception("Size mismatch in skills, typo exists.");
            }

            __minAtt = in_minAtt;
            __maxAtt = in_maxAtt;
            __skillMods = in_skillMods;
        }
    }

    /// <summary>
    /// The attribute struct wraps around and aptitude, keeping it constant
    /// and giving defined conditions for what is a valid rating, it's maybe
    /// overly complicated for now, but if attributes become more complicated
    /// it will be easy to improve upon
    /// </summary>
    struct attribute : attributeInterface
    {
        // C# properties
        private rating __aptitude;
        public rating aptitude 
        { 
            get 
            {
                return __aptitude; 
            } 
        }

        // Constructor
        public attribute(rating attRating = rating.C)
        {
            __aptitude = attRating;
        }
    }

    /// <summary>
    /// The experience struct is similar to the attribute struct, it wraps
    /// around several different bits of data and makes sure they are 
    /// initated within allowable conditions, and makes sure they're not
    /// changed in a way that is illogical, it also allows for the addition
    /// of exp to the structure, as the "safe" way to change things
    /// </summary>
    struct experience : experienceInterface
    {
        // Constants
        private static byte expToLevel = 100;
        private static byte maxLevel = 100;

        // C# properties
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

        /// <summary>
        /// Add exp to the current pool, if its higher than what one needs to
        /// level up, level up, if we're at max level, don't do anything
        /// </summary>
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

        // Constructors
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

    /// <summary>
    /// Keeps track of the health and physical attractiveness of a body part
    /// while also providing functions that help heal or hurt the wrestlers
    /// </summary>
    struct bodypart : bodypartInterface
    {
        // Consts
        private static int baseChance = 75;
        private static Random rand = new Random();

        // C# Properties
        private rating __damage;
        public rating damage 
        { 
            get
            {
                return __damage;
            }
        }
        private rating __beauty;
        public rating beauty 
        {
            get
            {
                return __beauty;
            }
        }

        // Constructors
        public bodypart(rating in_beauty = rating.B)
        {
            __damage = rating.C;
            __beauty = in_beauty;
        }

        /// <summary>
        /// Simple function that determine randomly wether a wrestler is
        /// seriously hurt or not upon being hurt in an opportunity
        /// </summary>
        /// <remarks>
        /// TODO: Improve formulas for randomly being hurt
        /// </remarks>
        public void hurt()
        {
            if(__damage != rating.S)
            {
                int chance = (100 - baseChance) * ((int)__damage - 1);
                if (chance > rand.Next(100))
                {
                    __damage++;
                }
            }
        }

        /// <summary>
        /// Simple function that determine randomly wether a wrestler is
        /// healed or not upon being given the opportunity to try and heal
        /// </summary>
        /// <remarks>
        /// TODO: Improve formulas for randomly being healed
        /// </remarks>
        public void heal(bool hospital = false)
        {
            if (__damage != rating.C)
            {
                int chance = baseChance / (int)__damage     ;
                if (hospital)
                {
                    chance *= 2;
                }

                if (chance > rand.Next(100))
                {
                    __damage--;
                }
            }
        }
    }

    /// <summary>
    /// Used to define a wrestler in game, several static fields of data
    /// are kept within the class after loading it from files so that wrestlers
    /// can be copied into other wrestlers, along with keeping the data required
    /// to do things with the skills
    /// </summary>
    class Wrestler : WrestlerInterface
    {
        /// <remarks>
        /// Static dictionaries that will be copied for wrestlers
        /// Generic attributes are strings that will be referenced in
        /// the dictionaries keys in the other skills, as of now they don't
        /// need to hold information statically
        /// </remarks>
        private static string[] genericAttributes;
        /// <remarks>
        /// General skills are a dictionary, with the key being the name of the
        /// and the value being an attribute
        /// </remarks>
        private static Dictionary<string, string> genericGeneralSkills;
        /// <remarks>
        /// Contains all the static information for leveling up a skill, the
        /// string key is the name of the skill, the modifier holds all the
        /// experience modifier information
        /// </remarks>
        private static Dictionary<string, modifier> genericWrestlingSkills;
        /// <remarks>
        /// An array that holds the dictionary values for the body parts,
        /// we don't need to hold any information statically as of yet
        /// </remarks>
        private string[] genericBodyParts;

        /// <remarks>
        /// The personal skill and attribute dictionaries for wrestlers
        /// </remarks>
        private Dictionary<string, attribute> __attributes;
        private Dictionary<string, experience> __generalSkills;
        private Dictionary<string, experience> __wrestlingSkills;
        private Dictionary<string, bodypart> __bodyParts;

        private static bool isinit = false;
        /// <summary>
        /// Will initialize the dictionaries above, constructors will all check
        /// for initialization before running, and will throw errors if
        /// intialization does not work. init() will throw an error if it fails.
        /// </summary>
        public static bool init()
        {
            return isinit;
        }

        /// <summary>
        /// Accessors for the attribute, throws out errors if the attribute
        /// is non-existant, these errors are to help modders debug.
        /// </summary>
        /// <returns>
        /// Copy of the attribute belonging to the wrestler
        /// </returns>
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
        /// <summary>
        /// Accessors for the general skill, throws out errors if the g. skill
        /// is non-existant, these errors are to help modders debug.
        /// </summary>
        /// <returns>
        /// Copy of the general skills belonging to the wrestler
        /// </returns>
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
        /// <summary>
        /// Accessors for the wrestling skill, throws out errors if the w. skill
        /// is non-existant, these errors are to help modders debug.
        /// </summary>
        /// <returns>
        /// Copy of the wrestling skills belonging to the wrestler
        /// </returns>
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
        /// <summary>
        /// Accessors for the body parts, throws out errors if the b. part
        /// is non-existant, these errors are to help modders debug.
        /// </summary>
        /// <returns>
        /// Copy of the body parts belonging to the wrestler
        /// </returns>
        public bodypart getBodyPart(string key)
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

        /// <summary>
        /// Adds exp to a general skill, defines the parameters through which
        /// the game is allowed to modify the experience and skills of the
        /// wrestler
        /// </summary>
        public void expGeneralSkill(string name, byte experience)
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
        /// <TODO>
        /// Make it so skills are properly modifying by experience mods
        /// </TODO>
        /// <summary>
        /// Adds exp to a general skill, defines the parameters through which
        /// the game is allowed to modify the experience and skills of the
        /// wrestler
        /// </summary>
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
