using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ObjectsPool objectsPool;
    public EnemyManager enemyManager;

    [Header("Player Stats")]
    [SerializeField]float playerHealth = 10; //The health value of the balloon can be controlled with this variable.
    [SerializeField]float playerCoin = 10000f;
    private readonly float[] bulletUpgradeCosts = { 100, 250, 500, 750, 1000, 1250, 1750, 2500, 5000, 10000 };
    private readonly float[] baloonUpgradeCosts = { 100, 250, 500, 750, 1000, 1250, 1750, 2500, 5000, 10000 };
    float currentBulletCost;//Mermi gelistirmenin mevcut maliyeti
    float currentBaloonCost;//Balon gelistirmenin mevcut maliyeti
    private float bulletUpgradeCurrentValue = 0;//Mermi sliderini güncellemek icin gerekli olan degisken
    private float baloonUpgradeCurrentValue = 0;//Balon sliderini güncellemek icin gerekli olan degisken
    private int bulletUpgradeCostIndex = 0;//Yukarida tanimlanan mermi maliyet dizisi icin gerekli olan index degiskeni
    private int baloonUpgradeCostIndex = 0;//Yukarida tanimlanan mermi maliyet dizisi icin gerekli olan index degiskeni
    //public TextMeshProUGUI gameOverText;
    //public Image restartBackground;
    //public Button mainMenuButton;
    //public Button restartButton;
    
    [Header("Menu Items")]
    public GameObject restartMenu; //Game over menusunu bos bir gameobject icerisinde toplayip bu gameobject ile kontrol etmeyi dusundum.
    public GameObject upgradeMenu; // Game over menusu ile ayni mantik.

    [Header("Buttons")]
    public Button bulletUpgradeButton;
    public Button baloonUpgradeButton;

    [Header("Slider")]
    public Slider bulletUpgradeSlider;
    public Slider baloonUpgradeSlider;

    [Header("Text")]
    public TextMeshProUGUI playerCoinText;
    public TextMeshProUGUI bulletUpgradeValueText;
    public TextMeshProUGUI baloonUpgradeValueText;


    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        currentBulletCost = bulletUpgradeCosts[bulletUpgradeCostIndex];
        currentBaloonCost = baloonUpgradeCosts[baloonUpgradeCostIndex];

    }

    private void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    private void Awake()
    {
        MakeInstance();
    }


    // Update is called once per frame
    void Update()
    {
        GameOver(); //Checks if the game is over.
        UpdateUIElements();
        UpdateCosts();
        
    }

    public void GameOver() //buraya reklam eklenebilir.
    {
        if (playerHealth <= 0)
        {
            //restartBackground.gameObject.SetActive(true);
            //restartButton.gameObject.SetActive(true);
            //mainMenuButton.gameObject.SetActive(true);
            //gameOverText.gameObject.SetActive(true);
            restartMenu.SetActive(true);
            isGameActive = false;
        }
    }

    void UpdateUIElements()
    {
        playerCoinText.text = playerCoin.ToString();
        if(bulletUpgradeCurrentValue == 10)
        {
            bulletUpgradeValueText.text = "Full";
            bulletUpgradeButton.interactable = false;
        }
        else
        {
            bulletUpgradeValueText.text = currentBulletCost.ToString();
        }
        if(baloonUpgradeCurrentValue == 10)
        {
            baloonUpgradeValueText.text = "Full";
            baloonUpgradeButton.interactable = false;
        }
        else
        {
            baloonUpgradeValueText.text = currentBaloonCost.ToString();
        }
        
    }
    void UpdateCosts()
    {
        currentBaloonCost = baloonUpgradeCosts[baloonUpgradeCostIndex];
        currentBulletCost = bulletUpgradeCosts[bulletUpgradeCostIndex];
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Main"); //After the main menu is added, this will change and restart the game
    }

    //public void BackToMainMenu()
    //{
    //    SceneManager.LoadScene("Main"); //When the main menu is added, this will return to the main menu
    //}

    /// <summary>
    /// Upgrade menuyu acar.
    /// </summary>
    public void OpenUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
        
    }
    /// <summary>
    /// Upgrade menuyu kapatir.
    /// </summary>
    public void CloseUpgradeMenu()
    {
        upgradeMenu.SetActive(false);
    }
    /// <summary>
    /// UpgradeBullet metodu icin kullanilir. Mermi slider indexini ve maliyet miktarini degistirir.
    /// </summary>
    void IncreaseBulletUpgradeValue()
    {
        if(bulletUpgradeCurrentValue < 10)
        {
            bulletUpgradeCurrentValue += 1;
            if(bulletUpgradeCurrentValue == 10)
            {
                bulletUpgradeCostIndex = 9;
                
            }
            else
            {
                bulletUpgradeCostIndex += 1;
            }

        }
        
    }
    /// <summary>
    /// Mermiyi guclendirir.
    /// </summary>
    public void UpgradeBullet()
    {
        if(bulletUpgradeCurrentValue < 10 && playerCoin >= currentBulletCost)
        {
            playerCoin -= currentBulletCost;
            IncreaseBulletUpgradeValue();
            bulletUpgradeSlider.value = bulletUpgradeCurrentValue;
        }
        
    }
    /// <summary>
    /// UpgradeBaloon metodu icin kullanilir.Balon slider indexini ve maliyet miktarini degistirir.
    /// </summary>
    void IncreaseBaloonUpgradeValue()
    {
        if (bulletUpgradeCurrentValue < 10)
        {
            baloonUpgradeCurrentValue += 1;
            if (baloonUpgradeCurrentValue == 10)
            {
                baloonUpgradeCostIndex = 9;
                
            }
            else
            {
                baloonUpgradeCostIndex += 1;
            }
            
        }

    }
    /// <summary>
    /// Balonu gelistirir.
    /// </summary>
    public void UpgradeBaloon()
    {
        if(baloonUpgradeCurrentValue < 10 && playerCoin >= currentBaloonCost)
        {
            playerCoin -= currentBaloonCost;
            IncreaseBaloonUpgradeValue();
            baloonUpgradeSlider.value = baloonUpgradeCurrentValue;
        }
    }
    
}
