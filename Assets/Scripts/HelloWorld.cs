using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    #region Variables
    public int minimalValue = 1;
    public int maximalValue = 1000;
    public int guessValue;
    public int countGuessesQuantity = 1;
    public SceneLoader sceneLoader;
    private bool isPlayed = true;
    public Text label;
    public Text title;
    public Text instructions;

    public static HelloWorld helloWorld;
    #endregion
    #region Unity Lifecycle
    private void Awake()
    {
        /*if (helloWorld == null)
        {
            helloWorld = this;
        }
        else
        {
            Destroy(gameObject);
        }*/
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        showTitleAndInstructions();
        calculateNextPossibleNumber();
    }

    private void Update()
    {
        if (!isPlayed)
        {
            return;
        }
        /*if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            endGame();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            minimalValue = 1;
            maximalValue = 1000;
            restartTheGame();
            calculateNextPossibleNumber();
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            minimalValue = guessValue;
            calculateNextPossibleNumber();
            countGuessesQuantity++;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            maximalValue = guessValue;
            calculateNextPossibleNumber();
            countGuessesQuantity++;
        }*/
    }
    #endregion
    #region Private Methods
    private void calculateNextPossibleNumber()
    {
        guessValue = (minimalValue + maximalValue) / 2;
        label.text = "Загаданное вами число " + guessValue + "?\n Количество попыток: " + countGuessesQuantity;
    }
    private void showTitleAndInstructions()
    {
        title.text = "Давайте выберем число от " + minimalValue + " до " + maximalValue;
        //instructions.text = "Нажмите СТРЕЛКУ ВВЕРХ, если число больше того, что на экране;\nСТРЕЛКУ ВНИЗ, если число меньше того, что на экране.\n Нажмите ВВОД, если на экране ваше число.";
        instructions.text = "Нажмите соответсвующую кнопку, чтобы угадать свое число! ";
        
    }
    private void endGame()
    {
        //title.text = "Поздравляю!";
        //instructions.text = "Нажмите пробел, чтобы начать сначала!";
        //label.text = "Ваше число " + guessValue + "! \n Количество попыток " + countGuessesQuantity + "!";
        sceneLoader.ChangeScene(2);
        isPlayed = false;

    }
    private void restartTheGame()
    {
        countGuessesQuantity = 0;
        showTitleAndInstructions();
    }
    #endregion
    #region Public Methods
    public void HighTheGuessNumber()
    {
        minimalValue = guessValue;
        calculateNextPossibleNumber();
        countGuessesQuantity++;
        label.text = "Загаданное вами число " + guessValue + "?\n Количество попыток: " + countGuessesQuantity;
    }
    public void LowTheGuessNumber()
    {
        maximalValue = guessValue;
        calculateNextPossibleNumber();
        countGuessesQuantity++;
        label.text = "Загаданное вами число " + guessValue + "?\n Количество попыток: " + countGuessesQuantity;
    }
    public void ConfirmTheGuessNumber()
    {
        endGame();
    }
    #endregion
}
