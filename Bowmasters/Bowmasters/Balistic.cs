﻿using System;

///ETML
///Auteur : Maël Naudet
///Date: 20.01.2025
///Description: différentes fonctions permettant de faire différentes choses avec la balistique

namespace Bowmasters
{
    internal static class Balistic
    {
        //properties **************************************************

        private const double GRAVITATIONAL_CONSTANT = 9.81; //constante gravitationnelle

        //movement on y axis
        public static double MovementOnYAxis(double initialY, double time, double velocity, double angle)
        {
            return initialY - ((velocity * Math.Sin(DegToRad(angle)) * time) - ((GRAVITATIONAL_CONSTANT * Math.Pow(time, 2)) / 2));
        }

        //movement on x axis
        public static double MovementOnXAxis(double initialX, double time, double velocity, double angle)
        {
            return initialX + (velocity * Math.Cos(DegToRad(angle)) * time);
        }

        //from degree to radian
        public static double DegToRad(double degree)
        {
            return degree * (Math.PI / 180);
        }

        //from radian to degree
        public static double RadToDeg(double radian)
        {
            return radian * (180 / Math.PI);
        }
    }
}
