// See https://aka.ms/new-console-template for more information

using Mission2Assignment;

internal class Program
{
    public static void Main(string[] args)
    {
        // Initializing Variables
        int numRolls = 0;
        bool validInput = false;
        
        // Loop until the user enters a valid number (some extra error handling I added in)
        while (!validInput)
        {
            // Prompt the user
            Console.Write($"Welcome to Hilton's High Rollers & Casino!" +
                          $"\nHow many dice ya' wanna roll bub?: ");
            
            // Take the user input as a string
            string input = Console.ReadLine();
            
            // Convert the input from a string to an integer
            if (int.TryParse(input, out numRolls) && numRolls > 0) // Ensure input is positive
            {
                // Create an INSTANCE of SecondClass (my other class)
                SecondClass diceRoller = new SecondClass();
                
                // Creates an array to count how many times each sum of two dice appears.
                // Can range anywhere from 2-12 since dice can't be 0.
                int[] uniqueSumDice = new int[13];
                
                // Roll the dice and add up the results with a loop
                // This looks like a JavaScript loop
                for (int i = 0; i < numRolls; i += 1)
                {
                    // Create variable named uniqueSumDice that is my instance calling my method? (I think)
                    int diceRollResult = diceRoller.RollTwoDice();
                    uniqueSumDice[diceRollResult] += 1; // Incrementing count for the loop
                }
                
                // Calculate and display the asterisks
                Console.WriteLine($"\nGAMBLING RESULTS:\n" +
                                  $"Each '*' represents 1% of the total number of rolls\n" +
                                  $"Let's see how lucky you are wise guy...\n" +
                                  $"You rolled {numRolls} times!\n");
                for (int i = 2; i <= 12; i++)
                {
                    // This will display a percentage next to the asterisks that shows the % of rolls
                    double percentage = (double)uniqueSumDice[i] / numRolls * 100;
                    
                    // Prints out the number of "*"s
                    string stars = new string('*', (int)Math.Round(percentage));
                    Console.WriteLine($"{i}: {stars} ({percentage:F2}%)");
                }
                
                // Thank you message to the user
                Console.WriteLine("\nThanks for visitin' Hilton's High Rollers & Casino eh. " +
                                  "\nBetter luck next time!");
                
                validInput = true; // Exit the loop after processing (since the user input was a valid number)
            }
            else
            {
                // Handle invalid input
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
