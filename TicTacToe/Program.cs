// See https://aka.ms/new-console-template for more information
//This applicaton will play the game Tic Tac Toe

//Main board function
string[] pos = { " "," "," "," "," "," "," "," "," " };
//Denne bool styrer hvis tur det er, true = kryds, false = bolle
bool turn = true;
string brik = "X";
int KrydsWins = 0;
int BolleWins = 0;

Console.Title = "Tic Tac Toe";

while (true)
{
    PrintBoard();
    if (turn)
    {
        brik = "X";
    }
    if (!turn)
    {
        brik = "O";
    }
    PlaceBrick(turn);
    CheckVictory(turn);
    turn = !turn;
}

void CheckVictory(bool Tur)
{
    if (((brik == pos[0] && brik == pos[1] && brik == pos[2]) || (brik == pos[0] && brik == pos[3] && brik == pos[6]) || (brik == pos[3] && brik == pos[4] && brik == pos[5])||(brik == pos[6] && brik == pos[7] && brik == pos[8])|| (brik == pos[1] && brik == pos[4] && brik == pos[7])||(brik == pos[2] && brik == pos[5] && brik == pos[8]) ||(brik == pos[2] && brik == pos[4] && brik == pos[6])||(brik == pos[0] && brik == pos[4] && brik == pos[8])))
    {
        if (Tur)
        {
            PrintBoard();
            Console.WriteLine("X wins!\n");
            KrydsWins++;
        }
        if (!Tur)
        {
            PrintBoard();
            Console.WriteLine("O wins! \n");
            BolleWins++;
        }
        RestartGame();
        
    }
    else if (pos[0] != " " && pos[1] != " " && pos[2] != " " && pos[3] != " " && pos[4] != " " && pos[5] != " " && pos[6] != " " && pos[7] != " " && pos[8] != " ")
    {
        Console.WriteLine("Det står lige.");
        RestartGame();
    }
}
void PrintBoard()
{
    Console.Clear();
    Console.WriteLine($" {pos[0]} | {pos[1]} | {pos[2]} ");
    Console.WriteLine($"----------");
    Console.WriteLine($" {pos[3]} | {pos[4]} | {pos[5]} ");
    Console.WriteLine($"----------");
    Console.WriteLine($" {pos[6]} | {pos[7]} | {pos[8]} ");
}
void RestartGame()
{
    Console.WriteLine("Vil du spille igen?");
    string input = Console.ReadLine();
    input = input.ToLower();
    if (input == "yes" || input == "ja" || input == "jaer" || input == "totalt" || input == "yes." || input == "ja.")
    {
        ResetBoard();
    }
    else if (input == "ole")
    {
        Console.WriteLine("Der troede du vist du var smart, hva'?");
    }
    else
    {
        Environment.Exit(0);
    }
}

void PlaceBrick(bool Tur)
{
    bool cont = true;
    do
    {

        Console.WriteLine("Vælg et tal mellem 1 og 9");
        int input = 0;
        do
        {
            try
            {
                input = int.Parse(Console.ReadLine());
                cont = true;
            }
            catch (Exception ex)
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine("Invalid input, prøv igen.");
                cont = false;
            }
            
        } while (cont == false);

        if (input > 9 || input < 1)
        {
            Console.WriteLine("Invalid input, prøv igen.");
            cont = false;
        }
        else if (pos[input - 1] == " ")
        {
            pos[input - 1] = brik;
            cont = true;
        }
        else
        {
            PrintBoard();
            Console.WriteLine("Den brik er allerede taget. Vælg en anden.");
            cont = false;
        }
    } while (cont == false);
}
void ResetBoard()
{
    for (int i = 0; i < pos.Length; i++)
    {
        pos[i] = " ";
    }
}