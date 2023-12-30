namespace WordleClone.Results;

public class CorrectResult : Result
{
    public CorrectResult(string correctWord)
    {
        IsCorrect = true;
        Message = "You won!";

        for(var i = 0; i < correctWord.Length; i++)
            Letters[i] = new (correctWord[i], LetterPlacement.Correct);
    }
}