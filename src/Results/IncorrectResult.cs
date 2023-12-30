namespace WordleClone.Results;

public class IncorrectResult : Result
{
    public IncorrectResult(string wordGuess, string correctWord)
    {
        IsCorrect = false;
        Message = "One or more letters are correct";
        
        var used = new bool[correctWord.Length];

        for (var i = 0; i < wordGuess.Length; i++)
        {
            if (wordGuess[i] == correctWord[i])
            {
                Letters[i] = new Letter(wordGuess[i], LetterPlacement.Correct);
                used[i] = true;
            }
        }

        for (var i = 0; i < wordGuess.Length; i++)
        {
            if (Letters[i] == null)
            {
                var isIncorrect = false;

                for (var j = 0; j < correctWord.Length; j++)
                {
                    if (wordGuess[i] == correctWord[j] && !used[j])
                    {
                        isIncorrect = true;
                        used[j] = true;
                        break;
                    }
                }

                Letters[i] = new Letter(wordGuess[i], isIncorrect ? LetterPlacement.Incorrect : LetterPlacement.NotPresent);
            }
        }
    }
}
