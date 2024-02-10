using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuessTheNumber : MonoBehaviour
{
    public Text headerText;
    public InputField inputField;
    private int targetNumber;
    private int attemptsLeft = 3;
    private bool gameEnded = false;

    void Start()
    {
        GameSetup();
    }

    public void GameSetup()
    {
        targetNumber = Random.Range(1, 101);
        attemptsLeft = 3;
        gameEnded = false;
        UpdateHeaderText();
        inputField.text = "";
    }

    public void SubmitGuess()
    {
        if (gameEnded)
            return;

        if (inputField.text == "")
            return;

        int guess;
        bool isNumeric = int.TryParse(inputField.text, out guess);

        if (!isNumeric)
        {
            headerText.text = "Please enter a valid number!";
            return;
        }

        if (guess < 1 || guess > 100)
        {
            headerText.text = "Please enter a number between 1 and 100!";
            return;
        }

        attemptsLeft--;

        if (guess == targetNumber)
        {
            headerText.text = "Congratulations! You've guessed the number!";
            gameEnded = true;
        }
        else
        {
            if (attemptsLeft > 0)
            {
                UpdateHeaderText();
            }
            else
            {
                headerText.text = "Game over! The number was " + targetNumber;
                gameEnded = true;
            }
        }
    }

    void UpdateHeaderText()
    {
        headerText.text = "Attempts left: " + attemptsLeft;
    }

    public void ResetGame()
    {
        GameSetup();
    }
}
