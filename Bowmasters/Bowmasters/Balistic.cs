///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date: 20.01.2025
///*******************************************************

using System;

namespace Bowmasters
{
    /// <summary>
    /// différentes fonctions permettant de faire différentes choses avec la balistique
    /// </summary>
    internal static class Balistic
    {
        //properties **************************************************

        private const double GRAVITATIONAL_CONSTANT = 9.81; //constante gravitationnelle

        /// <summary>
        /// calcule la coordonnée y d'un objet lancé à une certaine vitesse, à un certain angle, depuis un certain point, après un certain temps
        /// </summary>
        /// <param name="initialY">point de départ</param>
        /// <param name="time">temps en question</param>
        /// <param name="velocity">vitesse initiale de l'objet</param>
        /// <param name="angle">angle initial de l'objet</param>
        /// <returns>une coordonnée y</returns>
        public static double MovementOnYAxis(double initialY, double time, double velocity, double angle)
        {
            return initialY - ((velocity * Math.Sin(DegToRad(angle)) * time) - ((GRAVITATIONAL_CONSTANT * Math.Pow(time, 2)) / 2));
        }

        //movement on x axis
        public static double MovementOnXAxis(double initialX, double time, double velocity, double angle)
        {
            return initialX + (velocity * Math.Cos(DegToRad(angle)) * time);
        }

        /// <summary>
        /// prend un angle en degré et le transforme en radian
        /// </summary>
        /// <param name="degree">angle en degré</param>
        /// <returns>angle en radian</returns>
        public static double DegToRad(double degree)
        {
            return degree * (Math.PI / 180);
        }

        /// <summary>
        /// prend un angle en radian et le transforme en degré
        /// </summary>
        /// <param name="radian">angle en radian</param>
        /// <returns>l'angle donné en degré</returns>
        public static double RadToDeg(double radian)
        {
            return radian * (180 / Math.PI);
        }
    }
}
