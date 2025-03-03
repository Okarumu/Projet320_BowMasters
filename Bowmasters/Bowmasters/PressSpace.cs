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
    internal class PressSpace
    {


        // Déclaration des constantes **********************************************
        private const byte X_DIFFERENCE_PROGRESSION_BAR = 4;    // ajustement de la position x de la barre
        private const byte Y_DIFFERENCE_PROGRESSION_BAR = 26;   // ajustement de la position y de la barre
        private const byte PROGRESSION_BAR_SIZE = 20;           // taille de la barre de progression
        private const int VK_SPACE = 0x20;                      // clé virtuelle de la barre espace

        // Déclaration des attributs ***********************************************
        private bool isSpaceHeld = false;                       // savoir si la barre espace a déjà été enfoncée
        private DateTime startTime = new DateTime();            // timer qui permet d'augmenter la barre de progression
        private readonly ConsoleColor _color;                   // couleur de la barre de progression
        private readonly float maxHoldTime;                     // temps max possible de pression
        private float holdTime;                                 // temps de pression 


        // Déclaration des propriétés **********************************************
        private PositionByte position;     // Position de la barre
        public PositionByte Position
        {
            get { return position; }
            set { position = value; }
        }

        // Déclaration du constructeur *********************************************
        /// <summary>
        /// Constructeur qui demande une position et un temps max de pression
        /// </summary>
        /// <param name="xPosition">position x</param>
        /// <param name="yPosition">position y</param>
        /// <param name="maxHoldTime">temps max de pression</param>
        public PressSpace(Player player, float maxHoldTime, ConsoleColor color)
        {
            // se positionne au bon endroit
            Position = new PositionByte((byte)(player.Position.X - X_DIFFERENCE_PROGRESSION_BAR), (byte)(player.Position.Y - Y_DIFFERENCE_PROGRESSION_BAR));
            this.maxHoldTime = maxHoldTime;
            holdTime = 0;
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
            Console.SetCursorPosition(Position.X + (int)(holdTime / maxHoldTime * PROGRESSION_BAR_SIZE), Position.Y);
            Console.Write("■");
        }

        /// <summary>
        /// Efface la barre en entier
        /// </summary>
        public void EraseBar()
        {
            // parcourt toute la barre pour l'effacer
            for (int i = 0; i <= PROGRESSION_BAR_SIZE; i++)
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
                if (((GetAsyncKeyState(VK_SPACE) & 0x8000) != 0) && !isSpaceHeld)
                {
                    // temps de départ
                    startTime = DateTime.Now;
                    // indique qu'il appuie
                    isSpaceHeld = true;
                }
                // la touche est appuyée
                if (isSpaceHeld)
                {
                    // on ajoute un timer en fonction de quand il a appuyé la première fois
                    holdTime = (float)(DateTime.Now - startTime).TotalSeconds;
                    // Limite le temps à maxHoldTime
                    holdTime = Math.Min(holdTime, maxHoldTime); 
                }     

                // Affiche la barre
                DisplayBar();

            } while (((GetAsyncKeyState(VK_SPACE) & 0x8000) != 0) || !isSpaceHeld); // tant que l'utilisateur n'a pas appuyé une fois sur espace et qu'il ne relâche pas une fois appuyé

            // retourne un chiffre entre 0 et 50 en fonction du pourcentage de temps appuyé
            return (holdTime / maxHoldTime) * 50;
        }
    }
}
