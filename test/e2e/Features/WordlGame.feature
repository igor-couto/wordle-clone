Feature: Wordl Game

Scenario: Starting a New Game
    Given a new game
    Then the game is in the default playable state

Scenario: Correct Guess
    Given a new game with the word "phone"
    When submiting the word "phone"
    Then the game is won

Scenario: Unrecognized word
    Given a new game
    When submiting the word "abcde"
    Then a word not found error happen

Scenario: Word too short
    Given a new game
    When submiting the word "a"
    Then a short word error happen