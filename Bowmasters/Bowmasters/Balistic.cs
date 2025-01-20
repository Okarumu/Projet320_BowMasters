using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

///ETML
///Auteur : Maël Naudet
///Date: 20.01.2025
///Description: différentes fonctions permettant de faire différentes choses avec la balistique

namespace Bowmasters
{
    public class Balistic
    {
        //properties **************************************************

        private const double GRAVITATIONAL_CONSTANT = 9.81; //constante gravitationnelle

        //movement on y axis
        public double MovementOnYAxis(double time, double velocity, double angle)
        {
            return (velocity * Math.Sin(angle) * time) - ((GRAVITATIONAL_CONSTANT * Math.Pow(time, 2)) / 2);
        }

        //movement on x axis
        public double MovementOnXAxis(double time, double velocity, double angle)
        {
            return velocity * Math.Cos(angle) * time;
        }
    }
}
