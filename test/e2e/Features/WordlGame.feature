Feature: Wordl Game

Scenario: [scenario name]
    Given a new game with the word "phone"
    When submiting the word "phone"

Scenario: Unrecognized word
    Given a new game
    When submiting the word "abcde"
    Then a word not found error happen

Scenario: Word too short
    Given a new game
    When submiting the word "a"
    Then a short word error happen