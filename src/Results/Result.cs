namespace WordleClone.Results;

public abstract class Result
{
    public bool IsCorrect { get; init; }
    public Letter[] Letters { get; init; } =
    [
        new (' ', LetterPlacement.NotPresent),
        new (' ', LetterPlacement.NotPresent),
        new (' ', LetterPlacement.NotPresent),
        new (' ', LetterPlacement.NotPresent),
        new (' ', LetterPlacement.NotPresent)
    ];
    
    public string Message { get; init; }
}