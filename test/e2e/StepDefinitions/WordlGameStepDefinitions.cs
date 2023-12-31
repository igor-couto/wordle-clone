using FluentAssertions;
using System.Text.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;

namespace WordleClone.E2E.StepDefinitions;

[Binding]
public sealed class WordlGameStepDefinitions
{
    private ChromeDriver _driver;
    private readonly JsonSerializerOptions _options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    private readonly string _url = "https://localhost:53120";

    [Given(@"a new game with the word ""(.*)""")]
    public async Task ANewGameWithTheWord(string word)
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Url = _url;

        using var client = new HttpClient();
        var content = new StringContent($@"""{word}""", System.Text.Encoding.UTF8, "application/json");
        await client.PostAsync($"{_url}/answer", content);

        var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 1));

        Thread.Sleep(1000);
    }

    [Given(@"a new game")]
    public void ANewGame()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Url = _url;
        Thread.Sleep(1000);
    }

    [When(@"submiting the word ""(.*)""")]
    public void SubmitingTheWord(string word)
    {
        var actions = new Actions(_driver);

        foreach (var letter in word)
        {
            actions.SendKeys(letter.ToString()).Perform();
        }
        actions.SendKeys(Keys.Enter).Perform();
    }

    [Then("a word not found error happen")]
    public void AWordNotFoundErrorHappen()
    {
        var messageElement = _driver.FindElement(By.Id("message"));
        messageElement.Text.Should().Be("Not in word list.");

        var localStorageGame = GetGameFromLocalStorage();
        localStorageGame.Status.Should().Be(GameStatus.InProgress);
    }

    [Then("a short word error happen")]
    public void AWordShortWordErrorHappen()
    {
        var messageElement = _driver.FindElement(By.Id("message"));
        messageElement.Text.Should().Be("Word must be 5 letters!");

        var localStorageGame = GetGameFromLocalStorage();
        localStorageGame.Status.Should().Be(GameStatus.InProgress);
    }

    [Then("the game is won")]
    public void TheGameIsWon()
    {
        var messageElement = _driver.FindElement(By.Id("message"));
        messageElement.Text.Should().Be("Congratulations, you won!");

        var localStorageGame = GetGameFromLocalStorage();
        localStorageGame.Status.Should().Be(GameStatus.Won);

        var lastGuess = localStorageGame.LastGuess().ToLower();
        foreach (var letter in lastGuess) 
        {
            var keyboardKeyCssClass = _driver
                .FindElement(By.Id($"key-{letter}"))
                .GetAttribute("class");

            keyboardKeyCssClass.Contains("letter-correct").Should().BeTrue();
        }
    }

    private Game GetGameFromLocalStorage() 
    {
        var localStorageItemAsString = (string)_driver.ExecuteScript("return localStorage.getItem('game');");
        var localStorageGame = JsonSerializer.Deserialize<Game>(localStorageItemAsString, _options);
        return localStorageGame;
    }

    [AfterScenario]
    public void Cleanup()
    {
        if (_driver != null)
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}

public class Game
{
    public Guid SessionId { get; set; }
    public GameStatus Status { get; set; }
    public string[] BoardState { get; set; }

    public string LastGuess() 
    {
        var lastGuess = BoardState[0];
        foreach (var guess in BoardState) 
        {
            if (!string.IsNullOrWhiteSpace(guess)) 
                lastGuess = guess;
        }
        return lastGuess;
    }
}

public enum GameStatus 
{
    InProgress,
    Won,
    Lost
}