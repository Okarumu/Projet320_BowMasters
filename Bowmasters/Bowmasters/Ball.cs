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
        // Déclaration des constantes *************************************************

        /// <summary>
        /// Modèle de la balle
        /// </summary>
        private const char _MODEL = '×';

        // Déclaration des attributs **************************************************

        /// <summary>
        /// Vélocité de la balle
        /// </summary>
        private readonly double _velocity;

        /// <summary>
        /// Angle de la balle
        /// </summary>
        private readonly double _angle;
 
        /// <summary>
        /// Position initiale de la balle (non modifiable)
        /// </summary>
        private readonly PositionByte _initialPosition;

        /// <summary>
        /// Position actuelle de la balle (modifiée en jeu)
        /// </summary>
        private PositionByte _actualPosition;

        /// <summary>
        /// Couleur de la balle
        /// </summary>
        private ConsoleColor _color;


        // Déclaration des propriétés **********************************************

        /// <summary>
        /// Obtient la position initiale (en lecture seule)
        /// </summary>
        public PositionByte InitialPosition         
        {
            get
            {
                return _initialPosition;
            }
        }

        /// <summary>
        /// Obtient ou définit la position actuelle
        /// </summary>
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

        // Déclaration du constructeur *********************************************

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

        // Déclaration et implémentation des méthodes ******************************

        /// <summary>
        /// Update la position de la balle en fonction du temps
        /// </summary>
        /// <param name="time">temps</param>
        public void UpdateBallPosition(double time)
        {
           try
           {
                // Donne la position de la balle après un temps t
                ActualPosition.X = Convert.ToByte(Balistic.MovementOnXAxis(initialX: InitialPosition.X, time: time, velocity: this._velocity, angle: this._angle));
                ActualPosition.Y = Convert.ToByte(Balistic.MovementOnYAxis(initialY: InitialPosition.Y, time: time, velocity: this._velocity, angle: this._angle));
           }
            // vérifie que la balle se situe bien dans les limites du type byte (entre 0 et 255)
           catch (System.OverflowException)
           {
           }
        }

        /// <summary>
        /// Affiche la balle si elle est dans la console
        /// </summary>
        public void DisplayBallInTime()
        {
            // met la couleur du curseur à la couleur donnée aléatoirement plus haut
            Console.ForegroundColor = _color;
            try
            {
                Console.SetCursorPosition(Convert.ToInt16(ActualPosition.X), Convert.ToInt16(ActualPosition.Y));
                Console.Write(_MODEL);
            }
            // vérifie que la balle ne soit pas en dehors de la console
            catch (System.ArgumentOutOfRangeException) { }
            // remet les couleurs de base
            Console.ResetColor();
        }

        /// <summary>
        /// Efface la balle si elle est dans la console
        /// </summary>
        public void ErasePreviousBall()
        {
            try
            {
                Console.SetCursorPosition(Convert.ToInt16(ActualPosition.X), Convert.ToInt16(ActualPosition.Y));
                Console.Write(" ");
            }
            // Vérifie que la balle ne soit pas en dehors de la console ce qui n'est normalement pas possible
            catch(System.ArgumentOutOfRangeException) { }           
        }
    }
}
