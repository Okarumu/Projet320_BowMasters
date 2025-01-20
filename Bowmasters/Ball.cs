using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

///ETML
///Auteur : Maël Naudet
///Date : 20.01.2025

namespace Bowmasters
{
    /// <summary>
    /// Balle que le joueur lance
    /// </summary>
    public class Ball
    {
        //Déclaraton des propriétés ***************************************
        private double _xPosition;
        private double _yPosition;
        private double _velocity;
        private double _angle;
        private Balistic balistic = new Balistic();

        //Déclaration des constructeurs ***********************************
        public Ball(double velocity, double angle, double xPosition, double yPosition)
        {
            this._velocity = velocity;
            this._angle = angle;
            this._xPosition = xPosition;
            this._yPosition = yPosition;
        }

        /// <summary>
        /// Affiche la balle avec sa velocite et tout blablabla
        /// </summary>
        /// <param name="time">temps</param>
        public void DisplayBallInTime(double time)
        {

            _xPosition = balistic.MovementOnXAxis(time: time, velocity: this._velocity, angle: this._angle);
            _yPosition = balistic.MovementOnYAxis(time: time, velocity: this._velocity, angle: this._angle);

            Console.SetCursorPosition(Convert.ToInt16(Math.Round(_xPosition)), Convert.ToInt16(Math.Round(_yPosition)));

            Console.Write("X");
        }

        public void ErasePreviousBall()
        {
            Console.SetCursorPosition(Convert.ToInt16(Math.Round(_xPosition)), Convert.ToInt16(Math.Round(_yPosition)));
            Console.Write(" ");
        }
    }
}
