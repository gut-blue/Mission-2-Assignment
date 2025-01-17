// See https://aka.ms/new-console-template for more information

using Mission2Assignment;

internal class Program
{
    public static void Main(string[] args)
    {
        // Initializing Variables, number of rolls, and a boolean
        // variable that checks if the user input is valid.
        int numRolls = 0;
        bool validInput = false;
        
        // Loop until the user enters a valid number (some extra error handling I added in)
        while (!validInput)
        {
            // Prompt the user to input the number of rolls
            Console.Write($"Welcome to Hilton's High Rollers & Casino!" +
                          $"\nHow many dice ya' wanna roll bub?: ");
            
            // Take the user input as a string
            string input = Console.ReadLine();
            
            // Convert the input from a string to an integer if needed
            // also ensure that they entered a number greater than 0 (you can't roll a die 0 or -1 times)
            if (int.TryParse(input, out numRolls) && numRolls > 0) // Ensure input is positive
            {
                // Create an INSTANCE of SecondClass (my other class) and assign
                // it to my variable called diceRoller.
                SecondClass diceRoller = new SecondClass();
                
                // Creates an array to count how many times each sum of two dice appears.
                // Can range anywhere from 2-12 since the sum of two dice can't be 0 or 1.
                int[] SumDice = new int[13];
                
                // Roll the dice and add up the results with a loop until i (the counter)
                // is no longer less than the User's requested number of rolls
                // This looks like a JavaScript loop
                for (int iCount = 0; iCount < numRolls; iCount += 1)
                {
                    // I passed the number of rolls from above to my SecondClass
                    // responsible for doing all of the dice rolling logic.
                    
                    // Now I call my RollTwoDice() method from my SecondClass, by referencing
                    // the instance of that class I created above (called diceRoller)
                    // and stored that result in the diceRollResult variable.
                    int diceRollResult = diceRoller.RollTwoDice();
                    
                    // Increments the value of my index (diceRollResult) by 1
                    // (the index being the sum of the 2 dice being rolled), and 
                    // this being stored in the SumDice array I created earlier.
                    SumDice[diceRollResult] += 1; // Incrementing count for the loop
                }
                
                // Display the output (words and the numRolls) variable
                Console.WriteLine($"\nGAMBLING RESULTS:\n" +
                                  $"Each '*' represents 1% of the total number of rolls\n" +
                                  $"Let's see how lucky you are wise guy...\n" +
                                  $"You rolled {numRolls} times!\n");
                // loop through and iterate through all possible dice roll results
                // (2 through 12)
                for (int iCount = 2; iCount <= 12; iCount++)
                {
                    // Now I calculate the percentage of rolls based on the current iCount (dice result)
                    double percentage = (double)SumDice[iCount] / numRolls * 100;
                    
                    // Creates a variable called stars that consists of asterisks, the count
                    // of the asterisks is based on the percentage above ^^^
                    // (so if the percentage above is 0.0634, it is multiplied by 100 (as shown above)
                    // which makes it 6.34, then it will be rounded down to 6 (and so this knows to print
                    // out 6 asterisks)
                    string stars = new string('*', (int)Math.Round(percentage));
                    
                    // Finally, this prints the concatenated output of the SumDice
                    Console.WriteLine($"{iCount}: {stars} ({percentage:F2}%)");
                }
                
                // Thank you message to the user
                Console.WriteLine("\nThanks for visitin' Hilton's High Rollers & Casino eh. " +
                                  "\nBetter luck next time!");
                
                validInput = true; // Exit the loop after processing
                                   // we turn this variable to true (since the user input was a valid number)
            }
            else
            {
                // Handle invalid user input just in case
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
