using WordleClone.WordSet;
using WordleClone.Results;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel(option => option.AddServerHeader = false);

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );
}

app.UseDefaultFiles(); 
app.UseStaticFiles();

app.UseHttpsRedirection();

var words = new[]
{
    "aback", "abbey", "abbot", "abort", "about", "actor", "acute", "adept", "alert", "amble", "apple", "apply", "arise", "aside", "babel", "bacon", "badge", "bagel", "baker", "baler", "beach", "black", "blend", "bloat", "brave", "bread", "break", "bring", "broad", "build", "cabin", "cacti", "cadet", "caged", "cagey", "camel", "canal", "carry", "catch", "cause", "check", "child", "chill", "clear", "click", "clock", "close", "cloud", "coach", "color", "count", "court", "cover", "crash", "crisp", "cross", "crowd", "crown", "daily", "dairy", "daisy", "dance", "dandy", "dared", "drake", "dream", "drink", "drive", "dwell", "eager", "eagle", "early", "earth", "easel", "eaten", "eater", "elbow", "elite", "enjoy", "enter", "ethos", "event", "every", "exact", "exist", "extra", "fable", "faint", "fairy", "fakir", "fancy", "fight", "final", "first", "fixed", "flash", "flask", "flint", "floor", "focus", "force", "fresh", "front", "fruit", "gaily", "gains", "gamer", "gamma", "gavel", "gawky", "glass", "grant", "grape", "grass", "green", "grind", "group", "guard", "guess", "guest", "guide", "habit", "hairy", "halve", "handy", "happy", "heard", "heart", "heavy", "hello", "hoist", "honor", "horse", "hotel", "house", "hover", "human", "icing", "ideal", "idiot", "idler", "image", "imply", "inbox", "index", "inner", "input", "irony", "issue", "jaded", "jaunt", "jazz", "jelly", "jewel", "joint", "joker", "joust", "judge", "juice", "jumpy", "kayak", "kiosk", "knack", "knead", "knelt", "knife", "knoll", "koala", "label", "labor", "laden", "lager", "lance", "lanky", "lapse", "large", "latch", "laugh", "layer", "learn", "light", "limit", "local", "logic", "loose", "lucid", "lucky", "lunch", "magic", "maize", "major", "maker", "manic", "maple", "march", "marry", "match", "media", "metal", "mimic", "model", "money", "month", "moral", "motor", "mound", "mount", "mouse", "mouth", "movie", "music", "nadir", "naive", "naked", "nasal", "nasty", "never", "night", "noble", "noise", "north", "notch", "novel", "nudge", "nurse", "nylon", "oasis", "ocean", "offer", "often", "order", "other", "outer", "ovary", "owner", "paced", "pacer", "paddy", "paint", "panel", "pansy", "party", "peace", "phase", "phone", "photo", "piece", "pilot", "pitch", "place", "plane", "plant", "plate", "pluck", "point", "power", "press", "price", "prick", "pride", "prime", "print", "prior", "proof", "proud", "prove", "quail", "quark", "quart", "queen", "query", "quest", "quick", "quiet", "quill", "quite", "rabid", "radar", "raise", "rally", "range", "raven", "roast", "robin", "sable", "saint", "salad", "salsa", "sassy", "satyr", "scale", "scrap", "shift", "table", "tacky", "tango", "taper", "taste", "tawny", "teach", "thorn", "trick", "udder", "ulcer", "ultra", "umbra", "uncap", "uncle", "uncut", "under", "vague", "valid", "valor", "vapor", "vault", "vaunt", "virus", "vivid", "wafer", "wager", "wagon", "waist", "waltz", "waver", "waxed", "whale", "wrist", "xebec", "xenic", "xenon", "xeric", "xerus", "xylan", "yacht", "yearn", "yeast", "yield", "yodel", "zebra", "zesty", "zippy"
};

IWordSet wordSet = new TrieTree();
wordSet.Add(words);
var correctWord = words[Random.Shared.Next(words.Length)];
var notFoundResult = new WordNotFoundResult();

app.MapGet("/answer", () => Results.Ok(correctWord))
.WithName("Answer")
.WithOpenApi();

app.MapGet("/guess", (string word) =>
{
    word = word.ToLower();

    if (word.Length != 5)
        return Results.BadRequest();

    if(word == correctWord)
        return Results.Ok(new CorrectResult(correctWord));

    if(wordSet.Exists(word))
    {
        var result = new IncorrectResult(word, correctWord);
        return Results.Ok(result);
    }
    else
       return Results.NotFound(notFoundResult);
})
.WithName("Guess")
.WithOpenApi();

if (app.Environment.IsDevelopment())
{
    app.MapPost("/answer", ([FromBody] string word) => correctWord = word);
}

app.Run();