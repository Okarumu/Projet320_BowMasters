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
        private double _initialXPosition;
        private double _initialYPosition;
        private double _xPosition;
        private double _yPosition;
        private double _velocity;
        private double _angle;

        public double XPosition
        {
            get { return _xPosition; }
            set { _xPosition = value; }
        }

        public double YPosition
        {
            get { return _yPosition; }
            set { _yPosition = value; }
        }

        //Déclaration des constructeurs ***********************************
        public Ball(double velocity, double angle, double initialXPosition, double initialYPosition)
        {
            this._velocity = velocity;
            this._angle = angle;
            this._initialXPosition = initialXPosition;
            this._initialYPosition = initialYPosition;
            _xPosition = initialXPosition;
            _yPosition = initialYPosition;
        }

        /// <summary>
        /// Update la position de la balle en fonction du temps
        /// </summary>
        /// <param name="time">temps</param>
        public void UpdateBallPosition(double time)
        {
            _xPosition = Balistic.MovementOnXAxis(initialX: _initialXPosition, time: time, velocity: this._velocity, angle: this._angle);
            _yPosition = Balistic.MovementOnYAxis(initialY: _initialYPosition, time: time, velocity: this._velocity, angle: this._angle);
        }

        /// <summary>
        /// Affiche la balle
        /// </summary>
        /// 
        public void DisplayBallInTime()
        {
            
            Console.SetCursorPosition(Convert.ToInt16(Math.Round(_xPosition)), Convert.ToInt16(Math.Round(_yPosition)));
            Console.Write("X");
        }

        /// <summary>
        /// Effacer la balle
        /// </summary>
        public void ErasePreviousBall()
        {
            Console.SetCursorPosition(Convert.ToInt16(Math.Round(_xPosition)), Convert.ToInt16(Math.Round(_yPosition)));
            Console.Write(" ");
        }
    }
}
