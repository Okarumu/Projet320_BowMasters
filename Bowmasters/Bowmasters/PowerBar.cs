///*******************************************************
/// ETML
/// Auteur : Maël Naudet
/// Date : 31.01.2025
///*******************************************************

using System;
using System.Runtime.InteropServices;

namespace Bowmasters
{
    /// <summary>
    /// Affiche une barre de progression et quand on appuie sur espace, retourne le temps d'attente avant la pression (max 5 secondes)
    /// </summary>
    internal class PowerBar
    {


        // Déclaration et initialisation des constantes ****************************

        /// <summary>
        /// ajustement de la position x de la barre
        /// </summary>
        private const byte _X_DIFFERENCE_PROGRESSION_BAR = 4;

        /// <summary>
        /// ajustement de la position y de la barre
        /// </summary>
        private const byte _Y_DIFFERENCE_PROGRESSION_BAR = 26;

        /// <summary>
        /// taille de la barre de progression
        /// </summary>
        private const byte _PROGRESSION_BAR_SIZE = 20;

        /// <summary>
        /// clé virtuelle de la barre espace
        /// </summary>
        private const int _VK_SPACE = 0x20;

        /// <summary>
        /// Vitesse maximum de la balle
        /// </summary>
        private const byte _MAX_SPEED = 50;

        // Déclaration des attributs ***********************************************

        /// <summary>
        /// savoir si la barre espace a déjà été enfoncée
        /// </summary>
        private bool _isSpaceHeld = false;

        /// <summary>
        /// timer qui permet d'augmenter la barre de progression
        /// </summary>
        private DateTime _startTime = new DateTime();

        /// <summary>
        /// couleur de la barre de progression
        /// </summary>
        private readonly ConsoleColor _color;

        /// <summary>
        /// temps max possible de pression
        /// </summary>
        private readonly float _maxHoldTime;

        /// <summary>
        /// temps de pression 
        /// </summary>
        private float _holdTime;

        /// <summary>
        /// Position de la barre
        /// </summary>
        private PositionByte _position;                         

        // Déclaration des propriétés **********************************************

        /// <summary>
        /// Obtient et peut modifier la position de l'objet
        /// </summary>
        public PositionByte Position
        {
            get { return _position; }
            set { _position = value; }
        }

        // Déclaration du constructeur *********************************************
        /// <summary>
        /// Constructeur qui demande une position et un temps max de pression
        /// </summary>
        /// <param name="xPosition">position x</param>
        /// <param name="yPosition">position y</param>
        /// <param name="maxHoldTime">temps max de pression</param>
        public PowerBar(Player player, float maxHoldTime, ConsoleColor color)
        {
            // se positionne au bon endroit
            Position = new PositionByte((byte)(player.Position.X - _X_DIFFERENCE_PROGRESSION_BAR), (byte)(player.Position.Y - _Y_DIFFERENCE_PROGRESSION_BAR));
            this._maxHoldTime = maxHoldTime;
            _holdTime = 0;
            this._color = color;
        }

        // Déclaration et implémentation des méthodes *******************************
        /// <summary>
        /// Récupère l'état actuel d'une touche spécifiée du clavier
        /// Utilise l'API Windows via P/Invoke.
        /// </summary>
        /// <param name="vKey">Code virtuel de la touche (VK_*) à vérifier.</param>
        /// <returns>
        /// Un entier court contenant l'état de la touche :
        /// - Le bit de poids faible indique si la touche est actuellement enfoncée.
        /// - Le bit de poids fort indique si la touche a été pressée depuis le dernier appel.
        /// </returns>
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        /// <summary>
        /// Affiche la progression de la barre
        /// </summary>
        private void DisplayBar()
        {
            Console.ForegroundColor = _color;
            // Positionnement en fonction du temps passé
            Console.SetCursorPosition(Position.X + (int)(_holdTime / _maxHoldTime * _PROGRESSION_BAR_SIZE), Position.Y);
            Console.Write("■");
        }

        /// <summary>
        /// Efface la barre en entier
        /// </summary>
        public void EraseBar()
        {
            // parcourt toute la barre pour l'effacer
            for (int i = 0; i <= _PROGRESSION_BAR_SIZE; i++)
            {
                Console.SetCursorPosition(Position.X + i, Position.Y);
                Console.Write(" ");
            }
        }

        /// <summary>
        /// Commence une boucle tant que l'utilisateur n'a pas appuyé une fois sur espace et qu'il ne relâche pas une fois appuyé
        /// Augmente un timer et affiche la progression de la barre en fonction de ce timer
        /// </summary>
        /// <returns> le temps tenu </returns>
        public float Start()
        {
            // boucle
            do
            {
                // si l'utilisateur appuie sur espace
                if (((GetAsyncKeyState(_VK_SPACE) & 0x8000) != 0) && !_isSpaceHeld)
                {
                    // temps de départ
                    _startTime = DateTime.Now;
                    // indique qu'il appuie
                    _isSpaceHeld = true;
                }

                // la touche est appuyée
                if (_isSpaceHeld)
                {
                    // on ajoute un timer en fonction de quand il a appuyé la première fois
                    _holdTime = (float)(DateTime.Now - _startTime).TotalSeconds;
                    // Limite le temps à maxHoldTime
                    _holdTime = Math.Min(_holdTime, _maxHoldTime);

                    // Quand holdTime est au max on efface et on recommence
                    if (_holdTime == _maxHoldTime)
                    {
                        _holdTime = 0;
                        _startTime = DateTime.Now;
                        EraseBar();
                    }
                }
                // Affiche la barre
                DisplayBar();

            } while (((GetAsyncKeyState(_VK_SPACE) & 0x8000) != 0) || !_isSpaceHeld); // tant que l'utilisateur n'a pas appuyé une fois sur espace et qu'il ne relâche pas une fois appuyé

            // retourne un chiffre entre 0 et 50 en fonction du pourcentage de temps appuyé
            return (_holdTime / _maxHoldTime) * _MAX_SPEED;
        }
    }
}
