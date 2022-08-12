using System;
using System.Linq;
namespace passwordvalidator
{
    class Program
    {
        // GUI layer, outputs to console
        static void Main(string[] args)
        {
            string input = Program.ModelLayer();
            bool result = Program.Controller(input);
            if (result == true)
            {
                Console.WriteLine("Kodeordet er ok");
            }
            else
            {
            }            

        }
        // Controller layer, logic
        static bool Controller(string input)
        {
            if (input.Length >= 12 && input.Length <= 64)    
            {
                Console.WriteLine("Din kode er omkring 12-64 tegn");
                foreach (char letter in input)
                {
                    bool validUpper = false;
                    bool validLower = false;
                    if (char.IsUpper(letter))
                    {
                        Console.WriteLine("Din kode har store bogstaver");
                        validUpper = true;
                    
                    }
                    if (char.IsLower(letter))
                    {
                        Console.WriteLine("Din kode har små bogstaver");
                        validLower = true;
                       
                        
                    }
                   
                    // koden kan ikke komme herned pga. foreach loopen over fucker det hele op, kan ikke fikse det
                    if (validUpper && validLower == true)
                    {
                        foreach (char letters in input)
                        {
                            bool isLetters = false;
                            bool isNumbers = false;
                            if (char.IsLetter(letters))
                            {
                                Console.WriteLine("Din kode har bogstaver");
                                isLetters = true;
                            }
                            if (char.IsNumber(letters))
                            {
                                Console.WriteLine("Din kode har tal");
                                isNumbers = true;
                                
                            }
                            if (isLetters && isNumbers == true)
                            {
                                foreach (char specialSymbol in input)
                                {
                                    bool isSymbol = false;
                                    if (char.IsSymbol(specialSymbol))
                                    {
                                        Console.WriteLine("Din kode har symboler");
                                        isSymbol = true;
                                        
                                    }
                                    if (isSymbol)
                                    {
                                       
                                        string fourInARow = input;
                                        for (int i = 0; i < fourInARow.Length - 3; i++)
                                        {
                                            if (fourInARow[i].Equals(fourInARow[i] + 1).Equals(fourInARow[i] + 2).Equals(fourInARow[i] + 3))
                                            {
                                                OkPass();
                                            }
                                            if (!fourInARow[i].Equals(fourInARow[i] + 1).Equals(fourInARow[i] + 2).Equals(fourInARow[i] + 3))
                                            {
                                                PerfectPass();
                                            }
                                        }
                                    }

                                    
                                }
                            }
                            
                        }
                    }
                    
                }
            }
            else
            {
                InvalidPassword();
            }
            return false;
        }
        // starts if the password is perfect
        static void PerfectPass()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("din kode er rigtig god");
        }
        // starts if the password is ok
        static void OkPass()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("din kode er ok");
        }

        // starts if the password doesn't meet the requirmed minium for the password
        static void InvalidPassword()
        {
            Console.WriteLine("Din kode skal indeholde: ");
            Console.WriteLine("12-64 tegn og tal");
            Console.WriteLine("Store og små bogstaver");
            Console.WriteLine("Der skal være et mix af tegn og tal");
            Console.WriteLine("Minium et specialtegn");
        }
        // Model layer, readlines that gets user input
        static string ModelLayer()
        {
            Console.Write("Opret et kodeord: ");
            string passwordInput = Console.ReadLine();
            return passwordInput;
        }
    }
}
