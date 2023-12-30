using System.Text;

namespace WordleClone.Results;

public class IncorrectResult : Result
{
    public IncorrectResult(string wordGuess, string correctWord)
    {
        IsCorrect = false;
        Message = "One or more letters are correct";

        var modifiableCorrectWord = new StringBuilder(correctWord);

        for (var i = 0; i < wordGuess.Length; i++)
        {
            var guessChar = wordGuess[i];

            if (guessChar == correctWord[i])
            {
                Letters[i] = new Letter(guessChar, LetterPlacement.Correct);
                modifiableCorrectWord[i] = '-';
                continue;
            }

            var indexInModifiable = modifiableCorrectWord.ToString().IndexOf(guessChar);
            if (indexInModifiable != -1)
            {
                Letters[i] = new Letter(guessChar, LetterPlacement.Incorrect);
                modifiableCorrectWord[indexInModifiable] = '-';
            }
            else
            {
                Letters[i] = new Letter(guessChar, LetterPlacement.NotPresent);
            }
        }
    }
}
