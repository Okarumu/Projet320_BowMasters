///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 21.01.2025
///*******************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bowmasters;

namespace BowMastersTests
{
    /// <summary>
    /// Les différents tests unitaires utiles au projet, principalement des tests pour la ballistique du jeu
    /// </summary>
    [TestClass]
    public class BowMastersTests
    {
        /// <summary>
        /// Vérifie que le mouvement de la balle sur l'axe y soit correcte
        /// </summary>
        [TestMethod]
        public void Balistic_OnYAxis_From_0_After5Sec_Result_51dot91()
        {
            // Arrange
            int initialY = 0;
            double time = 5;
            double velocity = 20;
            double angle = 45;
            double result;

            // Act
            result = Balistic.MovementOnYAxis(initialY, time, velocity, angle);

            // Assert
            Assert.AreEqual(51.91, Math.Round(result, 2), "Le résultat doit être 51.91");
        }

        /// <summary>
        /// Vérifie que le mouvement de la balle sur l'axe X soit correct
        /// </summary>
        [TestMethod]
        public void Balistic_OnXAxist_From_0_After5Sec_Result_Minus70dot71()
        {
            // Arrange
            int initialX = 0;
            double time = 5;
            double velocity = 20;
            double angle = 45;
            double result;

            // Act
            result = Balistic.MovementOnXAxis(initialX, time, velocity, angle);

            // Assert
            Assert.AreEqual(70.71, Math.Round(result, 2), "Le résultat doit être 70.71");
        }
    }
}
