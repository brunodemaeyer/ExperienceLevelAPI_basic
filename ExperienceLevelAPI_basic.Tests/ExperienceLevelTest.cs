using System;
using ExperienceLevelAPI_basic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExperienceLevelAPI_basic.Tests
{
    [TestClass]
    public class ExperienceLevelTest
    {
        [TestMethod]
        public void TestExperienceLevel()
        {
            ExperienceLevel hero1 = new ExperienceLevel();

            //Check starting values
            Assert.AreEqual(0, hero1.GetCurrentExperience());
            Assert.AreEqual(0, hero1.GetTotalExperience());
            Assert.AreEqual(0, hero1.GetLevel());

            //Add some xp
            hero1.AddExperience(20);
            hero1.AddExperience(45);
            hero1.AddExperience(13);
            hero1.SubtractExperience(27);

            Assert.AreEqual(51, hero1.GetCurrentExperience());
            Assert.AreEqual(51, hero1.GetTotalExperience());
            Assert.AreEqual(0, hero1.GetLevel());

            //Add xp so we level-up 

            hero1.AddExperience(49);
            Assert.AreEqual(0, hero1.GetCurrentExperience());
            Assert.AreEqual(100, hero1.GetTotalExperience());
            Assert.AreEqual(1, hero1.GetLevel());

            //Add more xp so we level up two levels, then drop and go back up
            hero1.AddExperience(201);
            Assert.AreEqual(3, hero1.GetLevel());
            Assert.AreEqual(1, hero1.GetCurrentExperience());
            hero1.SubtractExperience(49);
            Assert.AreEqual(-48, hero1.GetCurrentExperience());
            Assert.AreEqual(252, hero1.GetTotalExperience());
            Assert.AreEqual(3, hero1.GetLevel());
            hero1.AddExperience(48);
            //level should still be 3
            Assert.AreEqual(3, hero1.GetLevel());

            //make experience positive again
            hero1.AddExperience(27);

            //Check where we are
            Assert.AreEqual(327, hero1.GetTotalExperience()); //Currently, total experience is 327,
            Assert.AreEqual(27, hero1.GetCurrentExperience());//           current experience is 27, 
            Assert.AreEqual(3, hero1.GetLevel());             //           and level is 3

            //and some calculations
            Assert.AreEqual(173, hero1.ExperienceDelta(5));
            Assert.AreEqual(73, hero1.ExperienceTillLevelUp());
            Assert.AreEqual(27, hero1.ProgressToNextLevel());
            Assert.AreEqual(53, hero1.ExperienceToLevel(5347));

            //test ResetExperience()

            hero1.ResetExperience();
            Assert.AreEqual(0, hero1.GetCurrentExperience(), 0);
            Assert.AreEqual(3, hero1.GetLevel(), 3);

            //test SetLevel()

            hero1.SetLevel(1);
            Assert.AreEqual(0, hero1.GetCurrentExperience());
            Assert.AreEqual(100, hero1.GetTotalExperience());
            Assert.AreEqual(1, hero1.GetLevel());

        }
    }
}
