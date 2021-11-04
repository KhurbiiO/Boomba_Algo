using System;

namespace Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * ! = landmijn/perimeter
             * ? = onbekend pad
             * 1 = bekend pad
             * 0 = doodlopende pad
             */

            // Start positie
            int row = 1;
            int column = 1;

            // Fake map met landmijmen en een perimeter omheen
            char[,] fakeMap = new char[,] {
                {'!', '!', '!', '!', '!', '!', '!', '!', '!', '!', '!', },
                {'!', '?', '?', '?', '!', '!', '?', '?', '?', '?', '!', },
                {'!', '!', '!', '?', '!', '!', '!', '!', '!', '?', '!', },
                {'!', '!', '!', '?', '!', '!', '!', '?', '?', '?', '!', },
                {'!', '?', '?', '?', '?', '?', '!', '!', '?', '!', '!', },
                {'!', '?', '!', '!', '!', '?', '!', '!', '?', '!', '!', },
                {'!', '?', '!', '!', '!', '?', '?', '!', '?', '!', '!', },
                {'!', '?', '!', '!', '!', '?', '!', '!', '?', '?', '!', },
                {'!', '?', '!', '!', '?', '?', '!', '!', '!', '?', '!', },
                {'!', '?', '!', '!', '?', '!', '!', '?', '?', '?', '!', },
                {'!', '?', '!', '?', '?', '?', '!', '?', '!', '!', '!', },
                {'!', '?', '!', '!', '!', '?', '!', '?', '!', '!', '!', },
                {'!', '?', '!', '!', '!', '?', '?', '?', '!', '!', '!', },
                {'!', '?', '!', '!', '!', '!', '!', '!', '!', '!', '!', },
                {'!', '!', '!', '!', '!', '!', '!', '!', '!', '!', '!', },
            };

            // Klaar wanneer je de overkant hebt bereikt
            while (column != fakeMap.GetLength(0) - 1)
            {
                pathCreation();
                EntryPosition();
            }

            // Maak een pad
            void pathCreation()
            {
                fakeMap[column, row] = '1';
                if (fakeMap[column + 1, row] == '?')
                {
                     column++;
                }
                else if (fakeMap[column - 1, row] == '?')
                {
                     column--;
                }
                else if (fakeMap[column, row + 1] == '?')
                {
                     row++;
                }
                else if (fakeMap[column, row - 1] == '?')
                {
                     row--;
                }

                // Bij een doodlopende pad terug naar het eerst volgende '?'
                if ((fakeMap[column + 1, row] == '!' && fakeMap[column, row - 1] == '!' && fakeMap[column, row + 1] == '!') ||
                    (fakeMap[column, row - 1] == '!' && fakeMap[column - 1, row] == '!' && fakeMap[column + 1, row] == '!') ||
                    (fakeMap[column - 1, row] == '!' && fakeMap[column, row - 1] == '!' && fakeMap[column, row + 1] == '!') ||
                    (fakeMap[column, row + 1] == '!' && fakeMap[column - 1, row] == '!' && fakeMap[column + 1, row] == '!'))
                {
                    pathTraceback();
                }
            }

            void pathTraceback()
            {
                while (fakeMap[column + 1, row] != '?' && fakeMap[column, row + 1] != '?' && fakeMap[column - 1, row] != '?' && fakeMap[column, row - 1] != '?')
                {
                    fakeMap[column, row] = '0';

                    if (fakeMap[column - 1, row] == '1')
                    {
                        column--;
                        EntryPosition();

                    }
                    else if (fakeMap[column, row - 1] == '1')
                    {
                        row--;
                        EntryPosition();

                    }
                    else if (fakeMap[column + 1, row] == '1')
                    {
                        column++;
                        EntryPosition();

                    }
                    else if (fakeMap[column, row + 1] == '1')
                    {
                        row++;
                        EntryPosition();
                    }
                }
            }

            void EntryPosition()
            {
                Console.WriteLine(fakeMap[column, row] + " Entry at position (" + column + ", " + row + ")");
            }
        }
    }
}
