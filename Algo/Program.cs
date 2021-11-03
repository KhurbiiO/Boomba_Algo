

using System;

namespace Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            int Xpos = 4; 
            int Ypos = 0;
            int PreMoveX;

            if(Xpos == 4)
            {
                PreMoveX = 0;
            }
            else
            {
                PreMoveX = 1;
            }

            String[,] Box = new String[,] {
                {"O", "O", "O", "O", "O" },
                {"X", "X", "O", "X", "X" },
                {"O", "O", "O", "O", "O" },
                {"X", "X", "X", "O", "X" },
                {"X", "X", "X", "O", "X" },
            };

            int pathCreation()
            {
                //forward
                if (Box[Ypos + 1 , Xpos] == "O")
                {
                    Ypos++;
                    return 2;
                }

                //right
                if (PreMoveX != 1)
                {
                    if (Xpos != 0)
                    {
                        if (Box[Ypos, Xpos - 1] == "O")
                        {
                            Xpos--;
                            PreMoveX = 0;
                            return 1;
                        }
                    }
                }                
                
                //left
                if(PreMoveX != 0)
                {
                    if (Xpos != 4)
                    {
                        if (Box[Ypos, Xpos + 1] == "O")
                        {
                            Xpos++;
                            PreMoveX = 1;
                            return 3;
                        }
                    }
                }
                 
                return 0;                
            }

            if(Box[Ypos, Xpos] == "O")
            {
                Console.WriteLine("Entry at position (" + Ypos + ", " + Xpos + ")");
                while (Ypos != 4)
                {
                    int Movement = pathCreation();
                    switch (Movement)
                    {
                        case 2:
                            Console.WriteLine("Moved forward, position (" + Ypos + ", " + Xpos + ")");
                            break; 

                        case 1:
                            Console.WriteLine("Moved to the left, position (" + Ypos + ", " + Xpos + ")");
                            break;

                        case 3:
                            Console.WriteLine("Moved to the right, position (" + Ypos + ", " + Xpos + ")");
                            break;

                        case 0:
                            Console.WriteLine("Dead-End");
                            Movement = 5;
                            break;
                    }                      

                }


            }

            else
            {
                Console.WriteLine("Invalid entry detected");
            }


        }
    }
}
