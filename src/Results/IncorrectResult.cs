namespace WordleClone.Results;

public class IncorrectResult : Result
{
    public IncorrectResult(string word, string correctWord)
    {
        IsCorrect = false;
        Message = "One or more letters are correct";

        for(var i = 0; i < correctWord.Length; i++)
        {
            if(word[i] == correctWord[i])
                Letters[i] = new (word[i], LetterPlacement.Correct);
            else if(correctWord.Contains(word[i])) //TODO: check this logic
                Letters[i] = new (word[i], LetterPlacement.Incorrect);
            else
                Letters[i] = new (word[i], LetterPlacement.NotPresent); 
        }
    }
}
