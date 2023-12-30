namespace WordleClone.Results;

public abstract class Result
{
    public bool IsCorrect { get; init; }
    public Letter[] Letters { get; set; } = new Letter[5];
    public string Message { get; init; }
}