using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    #region Variables
    public Text attemptLabel;
    public Text resultLabel;
    #endregion

    #region Unity Lifecycle
    private void Start()
    {
        HelloWorld helloWorld = FindObjectOfType<HelloWorld>();
        attemptLabel.text = $"Кол-во попыток: {helloWorld.countGuessesQuantity}";
        resultLabel.text = $"Загаданное число: {helloWorld.guessValue}";
    }

    #endregion
}
