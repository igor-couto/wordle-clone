using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace WordleClone.E2E.StepDefinitions;

[Binding]
public sealed class WordlGameStepDefinitions
{
    private ChromeDriver _driver;

    [Given(@"a new game with the word ""(.*)""")]
    public void ANewGameWithTheWord(string word)
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Url = "https://localhost:53120/";
        Thread.Sleep(1000);
    }

    [Given(@"a new game")]
    public void ANewGame()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Url = "https://localhost:53120/";
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
        _driver.Quit();
    }

    [Then("a short word error happen")]
    public void AWordShortWordErrorHappen()
    {
        var messageElement = _driver.FindElement(By.Id("message"));
        messageElement.Text.Should().Be("Word must be 5 letters!");
        _driver.Quit();
    }
}