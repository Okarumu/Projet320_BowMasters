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
        // Déclaration et initialisation des attributs ********************************
        /// constante gravitationnelle
        private const double _GRAVITATIONAL_CONSTANT = 9.81; 


        // Déclaration et implémentation des méthodes *********************************
        /// <summary>
        /// calcule la coordonnée y d'un objet lancé grâce à la balistique
        /// </summary>
        /// <param name="initialY">point de départ</param>
        /// <param name="time">temps en question</param>
        /// <param name="velocity">vitesse initiale de l'objet</param>
        /// <param name="angle">angle initial de l'objet</param>
        /// <returns>une coordonnée y</returns>
        public static double MovementOnYAxis(double initialY, double time, double velocity, double angle)
        {
            return initialY - ((velocity * Math.Sin(DegToRad(angle)) * time) - ((_GRAVITATIONAL_CONSTANT * Math.Pow(time, 2)) / 2));
        }

        /// <summary>
        /// Calcule la coordonnée x d'un objet lancé grâce à la balistique
        /// </summary>
        /// <param name="initialX">position x initiale</param>
        /// <param name="time">temps t passé</param>
        /// <param name="velocity">vitesse de l'objet initiale</param>
        /// <param name="angle">angle de lancement initial</param>
        /// <returns></returns>
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
