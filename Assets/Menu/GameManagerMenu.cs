using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManagerMenu : MonoBehaviour
{
    public Canvas _menuCanvas, _gameCanvas, _pauseCanvas, _shopCanvas;
    public GameObject _buyButton1, _buyButton2, _selectButton1, _selectButton2, _player;
    public Text _scoreLast, _moneyLast, _scoreMenu, _moneyMenu, _AllMoney;
    public TextMesh _bestScore;
    public int hadSkin2=0, hadSkin3=0, shoosedSkin=0;
    //Общая логика
    public void Awake()
    {
        Time.timeScale = 0;
    }
    public void Start()
    {
        EnableObjects(_menuCanvas);
        CheckLastScrore();
        _player.GetComponent<JumpController>().colorSwap();
    }
    public void StartGame()
    {
        _player.GetComponent<JumpController>().colorSwap();
        EnableObjects(_gameCanvas);
        Time.timeScale = 1;
        _bestScore.text = PlayerPrefs.GetInt("BestScore")+"";
    }

    public void OpenShop()
    {
        EnableObjects(_shopCanvas);
        if (PlayerPrefs.HasKey("AllMoney"))
        {
            _AllMoney.text = PlayerPrefs.GetInt("AllMoney")+"";
        }
        HadSkins();
    }
    public void CloseAGame()
    {
        Application.Quit();
    }
    void EnableObjects(Canvas openThisShit)
    {
        _menuCanvas.enabled = false;
        _gameCanvas.enabled = false;
        _pauseCanvas.enabled = false;
        _shopCanvas.enabled = false;
        openThisShit.enabled = true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        EnableObjects(_pauseCanvas);
    }

  

    public void BackToMenu()
    {
        EnableObjects(_menuCanvas);
        _player.GetComponent<JumpController>().colorSwap();
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

 

    //Магазин

    //покупка
    public void BuySkin2() 
    {
        if (PlayerPrefs.HasKey("AllMoney") && PlayerPrefs.GetInt("AllMoney")>=10)
        {
            hadSkin2 = 1;
            PlayerPrefs.SetInt("BoughtSkin2", hadSkin2);
            SelectSkin2();
            showButton();
            PlayerPrefs.SetInt("AllMoney", (PlayerPrefs.GetInt("AllMoney") - 10));
            _AllMoney.text = PlayerPrefs.GetInt("AllMoney") + "";
        }
    }
    public void BuySkin3()
    {
        if (PlayerPrefs.HasKey("AllMoney") && PlayerPrefs.GetInt("AllMoney") >= 100)
        {

            hadSkin3 = 1;
            PlayerPrefs.SetInt("BoughtSkin3", hadSkin3);
            SelectSkin3();
            showButton();
            PlayerPrefs.SetInt("AllMoney", (PlayerPrefs.GetInt("AllMoney") - 100));
            _AllMoney.text = PlayerPrefs.GetInt("AllMoney") + "";
        }       
    }



    //стартовая проверка при входе в магазин
    public void HadSkins()
    {
        if (PlayerPrefs.HasKey("BoughtSkin2"))
        {
            hadSkin2 = PlayerPrefs.GetInt("BoughtSkin2");
        }
        if (PlayerPrefs.HasKey("BoughtSkin3"))
        {
            hadSkin3 = PlayerPrefs.GetInt("BoughtSkin3");
        }
        showButton();
    }
    public void showButton()
    {

        if (hadSkin2 == 1)
        {
            _buyButton1.SetActive(false);
            _selectButton1.SetActive(true);
        }
        else
        {
            _buyButton1.SetActive(true);
            _selectButton1.SetActive(false);
        }

        if (hadSkin3 == 1)
        {
            _buyButton2.SetActive(false);
            _selectButton2.SetActive(true);
        }
        else
        {
            _buyButton2.SetActive(true);
            _selectButton2.SetActive(false);
        }
    }

    public void SetDefault ()
    {
        PlayerPrefs.DeleteAll();
        hadSkin2 = 0;
        hadSkin3 = 0;
        shoosedSkin = 0;
        showButton();
    }

    //выбор скина
    public void SelectSkin1()
    {
        shoosedSkin = 0;
        PlayerPrefs.SetInt("choosedSkin", shoosedSkin);
    }
    public void SelectSkin2()
    {
        shoosedSkin = 1;
        PlayerPrefs.SetInt("choosedSkin", shoosedSkin);
    }
    public void SelectSkin3()
    {
        shoosedSkin = 2;
        PlayerPrefs.SetInt("choosedSkin", shoosedSkin);
    }


    //смерть
    public void Death()
    {

        PlayerPrefs.SetInt("LastMoney", Convert.ToInt32(_moneyLast.text));
        PlayerPrefs.SetInt("LastScore", Convert.ToInt32(_scoreLast.text));
        MoneyText.Coin = 0;
        Time.timeScale = 0;

        if (PlayerPrefs.HasKey("LastMoney") && !PlayerPrefs.HasKey("AllMoney"))
        {
            PlayerPrefs.SetInt("AllMoney", PlayerPrefs.GetInt("LastMoney"));
        }
        else if (PlayerPrefs.HasKey("LastMoney") && PlayerPrefs.HasKey("AllMoney"))
        {
            PlayerPrefs.SetInt("AllMoney", PlayerPrefs.GetInt("AllMoney") + PlayerPrefs.GetInt("LastMoney"));
        }

        if (!PlayerPrefs.HasKey("BestScore"))
        { 
            PlayerPrefs.SetInt("BestScore",PlayerPrefs.GetInt("LastScore"));
            Debug.Log("1");
        }
        if (PlayerPrefs.HasKey("BestScore"))
        {
            if (PlayerPrefs.GetInt("BestScore") < PlayerPrefs.GetInt("LastScore"))
            {
                PlayerPrefs.SetInt("BestScore", PlayerPrefs.GetInt("LastScore"));
                Debug.Log("22");
            }
            
            
        }

        RetryGame();
    }

    //показать счет
    public void CheckLastScrore()
    {
        if (PlayerPrefs.HasKey("LastMoney"))
        {
            _moneyMenu.text = "EARNED MONEY: " + PlayerPrefs.GetInt("LastMoney");
        }
        if (PlayerPrefs.HasKey("LastScore"))
        {
            _scoreMenu.text = "SCORE: " + PlayerPrefs.GetInt("LastScore");
        }        
    }
}

