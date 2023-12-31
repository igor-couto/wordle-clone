namespace WordleClone.Results;

public class WordNotFoundResult : Result
{
    public WordNotFoundResult()
    {
        IsCorrect = false;
        Message = "Not in word list.";
    }
}