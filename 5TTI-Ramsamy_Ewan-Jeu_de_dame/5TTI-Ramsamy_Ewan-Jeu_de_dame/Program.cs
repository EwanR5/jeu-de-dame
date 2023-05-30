using System;

namespace _5TTI_Ramsamy_Ewan_Jeu_de_dame
{
    class Program
    {
        public class ChaineColoree
        {
            public ConsoleColor Couleur;
            public String Texte;

            public ChaineColoree(ConsoleColor couleur, string texte)
            {
            Couleur = couleur;
            Texte = texte;
            }
        }

        static void Main(string[] args)
        {
            MethodesDuProjet Outils = new MethodesDuProjet();
            char[,] plateau = new char[10,10];
            bool tours = true;
            int coefficientPos = 1;
            int coefficientNeg = -1;
            char pionB = '+';
            char pionRB = 'X';
            char pionR = '-';
            char pionRR = '/';
            int compteurR = 20;
            int compteurB = 20;
            bool winB = false;
            bool winR = false;

            Outils.RemplissagePlateau(ref plateau);

            while (winB == false || winR == false)
            {
                if (tours == true)
                {
                    Outils.MouvementPion(ref plateau, pionB, pionR, pionRB, pionRR, coefficientPos, ref compteurR);
                    tours = false;
                }
                else
                {
                    Outils.MouvementPion(ref plateau, pionR, pionB, pionRR, pionRB, coefficientNeg, ref compteurB);
                    tours = true;
                }
                if (compteurB == 0)
                {
                    winR = true;
                }
                else if (compteurR == 0)
                {
                    winB = true;
                }
            }
            if (winB == true)
            {
                Console.WriteLine("Félicitation aux Blancs pour la victoire !");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Félicitation aux Rouges pour la victoire !");
                Console.ReadLine();
            }
        }
    }
}
