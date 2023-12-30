namespace WordleClone.Results;

public class NotFoundResult : Result
{
    public NotFoundResult()
    {
        IsCorrect = false;
        Message = "Not in word list.";
    }
}