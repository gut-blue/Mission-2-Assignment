namespace Mission2Assignment;

public class SecondClass
{
    // Creating a static instance of the Random class. Because the random
    // Class generates random numbers. Use this same object throughout the program
    private static Random random = new Random();

    // Create my method to roll one die
    private int RollDie()
    {
        // Generates random number between 1 and 6
        return random.Next(1, 7);
    }
    
    // Method to simulate rolling two dice and return their sum
    // (by adding up the 2 instances of rolling ONE die)
    public int RollTwoDice()
    {
        // Creating instances of the two DICE
        int die1 = RollDie();
        int die2 = RollDie();
        // Sum the two totals of the rolls together
        return die1 + die2;
    }
}