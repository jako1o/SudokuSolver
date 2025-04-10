
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using FindowsWormsApp.Enums;

namespace FindowsWormsApp.Logic
{
    internal class SudokuGrid
    {

        //Attribute
        protected uint[,] grid; //Array mit dem gearbeitet wird
        protected uint[,] originalGrid; //Variable, um ursprünglichen Zustand zu speichern
        protected bool[,] isGiven; //Struktur, die speichert ob Zahl vorher schon gegeben war, um diese dann später rot auszugeben


        //Konstruktor
        public SudokuGrid()
        {
            grid = new uint[9, 9]; //leeres Grid initialisieren          
            isGiven = new bool[9, 9];
            originalGrid = new uint[9, 9];
        }


        //Methoden


        public ErrorCode CreateGrid(uint[,] gr)  //Neues Grid erzeugen Methode
        {
            //Überprüfen, ob eingegebenes Array die richtige Größe hat
            if (gr.GetLength(0) != 9 || gr.GetLength(1) != 9)
            {
                // Console.WriteLine("Das eingegebene Raster hat nicht die erforderliche Größe (9x9).");
                grid = new uint[9, 9]; // Rückgabe eines leeren 9x9-Arrays
                return ErrorCode.Size;
            }

            //Zahlen auf Gültigkeit prüfen (0-9 erlaubt)
            for (int i = 0; i < gr.GetLength(0); i++)
            {
                for (int j = 0; j < gr.GetLength(1); j++)
                {
                    if (gr[i, j] > 9)
                    {
                        // Console.WriteLine("Das eingegebene Raster enthält ungültige Zahlen.");
                        grid = new uint[9, 9]; //Rückgabe eines leeren 9x9-Arrays
                        return ErrorCode.NumbersInvalid;
                    }
                }
            }

            //Überprüfen, ob Eingabe leer ist.
            bool empty = true;
            foreach (var item in gr)
            {
                if (item != 0)
                {
                    empty = false;
                }
            }
            if (empty) return ErrorCode.Empty;



            //Console.WriteLine("Ein neues Raster wurde erfolgreich erstellt.");
            grid = gr; //Neues Raster in Klassenvariable schreiben

           

            for (int i = 0; i < 9; i++) //Markiert gegebene Zahlen in der isGiven Struktur mit true
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j] != 0)
                    {
                        isGiven[i, j] = true;  // Markiere als gegeben
                    }
                }
            }

            return ErrorCode.InputValid; //Gibt true zurück wenn erstellen erfolgreich
        }


        public uint[,] GetGrid() //Getter um von Solve drauf zuzugreifen
        {
            return grid;
        }

        public uint[,] GetOriginalGrid() //Getter um auf Originalzustand zuzugreifen
        {
            return originalGrid;
        }

        
    }
}