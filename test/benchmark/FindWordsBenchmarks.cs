using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using WordleClone.WordSet;

namespace WordleClone.Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class FindWordsBenchmarks
{
    private readonly string[] _words =
    [
        "aback", "abbey", "abbot", "abort", "about", "actor", "acute", "adept", "alert", "amble", "apple", "apply", "arise", "aside", "babel", "bacon", "badge", "bagel", "baker", "baler", "beach", "black", "blend", "bloat", "brave", "bread", "break", "bring", "broad", "build", "cabin", "cacti", "cadet", "caged", "cagey", "camel", "canal", "carry", "catch", "cause", "check", "child", "chill", "clear", "click", "clock", "close", "cloud", "coach", "color", "count", "court", "cover", "crash", "crisp", "cross", "crowd", "crown", "daily", "dairy", "daisy", "dance", "dandy", "dared", "drake", "dream", "drink", "drive", "dwell", "eager", "eagle", "early", "earth", "easel", "eaten", "eater", "elbow", "elite", "enjoy", "enter", "ethos", "event", "every", "exact", "exist", "extra", "fable", "faint", "fairy", "fakir", "fancy", "fight", "final", "first", "fixed", "flash", "flask", "flint", "floor", "focus", "force", "fresh", "front", "fruit", "gaily", "gains", "gamer", "gamma", "gavel", "gawky", "glass", "grant", "grape", "grass", "green", "grind", "group", "guard", "guess", "guest", "guide", "habit", "hairy", "halve", "handy", "happy", "heard", "heart", "heavy", "hello", "hoist", "honor", "horse", "hotel", "house", "hover", "human", "icing", "ideal", "idiot", "idler", "image", "imply", "inbox", "index", "inner", "input", "irony", "issue", "jaded", "jaunt", "jazz", "jelly", "jewel", "joint", "joker", "joust", "judge", "juice", "jumpy", "kayak", "kiosk", "knack", "knead", "knelt", "knife", "knoll", "koala", "label", "labor", "laden", "lager", "lance", "lanky", "lapse", "large", "latch", "laugh", "layer", "learn", "light", "limit", "local", "logic", "loose", "lucid", "lucky", "lunch", "magic", "maize", "major", "maker", "manic", "maple", "march", "marry", "match", "media", "metal", "mimic", "model", "money", "month", "moral", "motor", "mound", "mount", "mouse", "mouth", "movie", "music", "nadir", "naive", "naked", "nasal", "nasty", "never", "night", "noble", "noise", "north", "notch", "novel", "nudge", "nurse", "nylon", "oasis", "ocean", "offer", "often", "order", "other", "outer", "ovary", "owner", "paced", "pacer", "paddy", "paint", "panel", "pansy", "party", "peace", "phase", "phone", "photo", "piece", "pilot", "pitch", "place", "plane", "plant", "plate", "pluck", "point", "power", "press", "price", "prick", "pride", "prime", "print", "prior", "proof", "proud", "prove", "quail", "quark", "quart", "queen", "query", "quest", "quick", "quiet", "quill", "quite", "rabid", "radar", "raise", "rally", "range", "raven", "roast", "robin", "sable", "saint", "salad", "salsa", "sassy", "satyr", "scale", "scrap", "shift", "table", "tacky", "tango", "taper", "taste", "tawny", "teach", "thorn", "trick", "udder", "ulcer", "ultra", "umbra", "uncap", "uncle", "uncut", "under", "vague", "valid", "valor", "vapor", "vault", "vaunt", "virus", "vivid", "wafer", "wager", "wagon", "waist", "waltz", "waver", "waxed", "whale", "wrist", "xebec", "xenic", "xenon", "xeric", "xerus", "xylan", "yacht", "yearn", "yeast", "yield", "yodel", "zebra", "zesty", "zippy"
    ];

    public TrieTree TrieTree { get; set; } = new();
    public WordsArrayWithLinq WordsArrayWithLinq { get; set; } = new();

    public FindWordsBenchmarks()
    {
        WordsArrayWithLinq.Add(_words);
        TrieTree.Add(_words);
    }

    [Benchmark]
    public void FindExistingWord_With_WordsArrayWithLinq() => TrieTree.Exists("labor");
    

    [Benchmark]
    public void FindExistingWord_With_TrieTree() => WordsArrayWithLinq.Exists("labor");
}