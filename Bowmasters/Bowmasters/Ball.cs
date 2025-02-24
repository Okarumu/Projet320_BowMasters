///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 20.01.2025
///*******************************************************

using System;

namespace Bowmasters
{
    /// <summary>
    /// Balle que le joueur lance
    /// </summary>
    public class Ball
    {
        //Déclaraton des propriétés ***************************************
        private double _velocity;                       // vélocité de la balle
        private double _angle;                          // angle de la balle
        private readonly PositionByte _initialPosition; // position initiale de la balle
        private PositionByte _actualPosition;           // position updatée de la balle
        private ConsoleColor _color;                    // couleur de la balle

        // getter de la position initiale de la balle
        public PositionByte InitialPosition
        {
            get
            {
                return _initialPosition;
            }
        }

        // getter/setter de la position updatée de la balle
        public PositionByte ActualPosition
        {
            get
            {
                return _actualPosition;
            }
            set
            {
                _actualPosition = value;
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="velocity">vélocité de la balle</param>
        /// <param name="angle">angle de la balle</param>
        /// <param name="initialXPosition">position initiale x de la balle</param>
        /// <param name="initialYPosition">position initiale y de la balle</param>
        public Ball(double velocity, double angle, byte initialXPosition, byte initialYPosition)
        {
            this._velocity = velocity;
            this._angle = angle;
            _initialPosition = new PositionByte(initialXPosition, initialYPosition);
            ActualPosition = new PositionByte(initialXPosition, initialYPosition);
            _color = Custom.GetRandomColor();
        }

        /// <summary>
        /// Update la position de la balle en fonction du temps
        /// </summary>
        /// <param name="time">temps</param>
        public void UpdateBallPosition(double time)
        {
           try
           {
                ActualPosition.X = Convert.ToByte(Balistic.MovementOnXAxis(initialX: InitialPosition.X, time: time, velocity: this._velocity, angle: this._angle));
                ActualPosition.Y = Convert.ToByte(Balistic.MovementOnYAxis(initialY: InitialPosition.Y, time: time, velocity: this._velocity, angle: this._angle));
           }
            // vérifier que la balle se situe bien dans les limites de la console
           catch (System.OverflowException)
           {
           }
        }

        /// <summary>
        /// Affiche la balle si elle est dans la console
        /// </summary>
        /// 
        public void DisplayBallInTime()
        {
            // met la couleur du curseur à la couleur donnée aléatoirement plus haut
            Console.ForegroundColor = _color;
            try
            {
                Console.SetCursorPosition(Convert.ToInt16(ActualPosition.X), Convert.ToInt16(ActualPosition.Y));
                Console.Write("X");
            }
            // vérifie que la balle ne soit pas en dehors de la console
            catch (System.ArgumentOutOfRangeException) { }
            // remet les couleurs de base
            Console.ResetColor();
        }

        /// <summary>
        /// Effacer la balle si elle est dans la console
        /// </summary>
        public void ErasePreviousBall()
        {
            try
            {
                Console.SetCursorPosition(Convert.ToInt16(ActualPosition.X), Convert.ToInt16(ActualPosition.Y));
                Console.Write(" ");
            }
            // Vérifie que la balle ne soit pas en dehors de la console
            catch(System.ArgumentOutOfRangeException) { }           
        }
    }
}
