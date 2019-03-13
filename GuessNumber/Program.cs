using System;

namespace GuessNumber
{
  class Program
  {
    static void Main(string[] args)
    {
      var min = 1;
      var max = 100;
      var currentGuess = max / 2;
      var stillGuessing = true;
      var counter = 0;

      while (stillGuessing)
      {
        //figure out the next guess
        //ask the user if the guess was correct
        Console.WriteLine($"Is your number {currentGuess}?");
        var input = Console.ReadLine();
        if (input == "yes")
        {
          stillGuessing = false;
        }
        else
        {
          // if input is higher 
          // else if input is lower 
          if (input == "higher")
          {
            counter++;
            min = currentGuess - 1;
            currentGuess = (max + min) / 2;
          }
          else if (input == "lower")
          {
            counter++;
            max = currentGuess + 1;
            currentGuess = (max + min) / 2;
          }

        }
      }
      Console.WriteLine($"Yay! I guessed a total of {counter} times and your number {currentGuess} ");

    }
  }
}


