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
    [SerializeField] float playerHealth; //The health value of the balloon can be controlled with this variable.
    [SerializeField] int playerMoney;
    [SerializeField] float bulletDamage;

    int currentBulletDamageValue = 100, nextBulletDamageValue, currentHealthValue = 100, nextHealthValue;
    int bulletCost = 250, healthCost =250;

    [Header("Menu Items")]
    public GameObject restartMenu;
    public GameObject upgradeMenu;
    public GameObject settingsMenu;

    [Header("Buttons")]
    public Button bulletUpgradeButton;
    public Button healthUpgradeButton;
    public Button playButton;
    public Button settingsButton;

    [Header("Text")]
    public TextMeshProUGUI playerMoneyText;
    public TextMeshProUGUI bulletUpgradeValueText;
    public TextMeshProUGUI bulletUpgradeCostText;
    public TextMeshProUGUI baloonUpgradeValueText;
    public TextMeshProUGUI baloonUpgradeCostText;

    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;

        nextBulletDamageValue = currentBulletDamageValue + 20;
        nextHealthValue = currentHealthValue + 50;
        bulletDamage= currentBulletDamageValue;
        playerHealth = currentHealthValue;

        UpdateUIElements();
    }

    private void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    private void Awake()
    {
        MakeInstance();
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        GameOver(); //Checks if the game is over.
        UpdateUIElements();
        
    }
    /// <summary>
    /// Oyunu baslatir.
    /// </summary>
    public void PlayGame()
    {
        
        upgradeMenu.SetActive(false);
        Time.timeScale= 1.0f;
    }
    public void GameOver() //buraya reklam eklenebilir.
    {
        if (playerHealth <= 0)
        {
            restartMenu.SetActive(true);
            isGameActive = false;
            Time.timeScale= 0f;
        }
    }

    /// <summary>
    /// UI Elementlerini gunceller.
    /// </summary>
    void UpdateUIElements()
    {
        if(playerMoney < bulletCost) // Oyuncunun parasi gelistirme maliyetinden azsa buton inaktif olur.
        {
            bulletUpgradeButton.interactable = false;
        }
        else if(playerMoney >= bulletCost) // Oyuncunun parasi gelistirme maliyetinden fazlaysa buton aktif olur.
        {
            bulletUpgradeButton.interactable = true;
        }
        if(playerMoney < healthCost) // Oyuncunun parasi gelistirme maliyetinden azsa buton inaktif olur.
        {
            healthUpgradeButton.interactable = false;
        }
        else if(playerMoney >= healthCost) // Oyuncunun parasi gelistirme maliyetinden fazlaysa buton aktif olur.
        {
            healthUpgradeButton.interactable = true;
        }

        playerMoneyText.text = playerMoney.ToString();
        bulletUpgradeCostText.text = bulletCost.ToString();
        bulletUpgradeValueText.text = $"{currentBulletDamageValue} > {nextBulletDamageValue}";
        baloonUpgradeCostText.text = healthCost.ToString();
        baloonUpgradeValueText.text = $"{currentHealthValue} > {nextHealthValue}";
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene("Main"); //After the main menu is added, this will change and restart the game
    }

    public void SettingsMenuOpen()
    {
        settingsMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
        settingsMenu.SetActive(false);
    }
    /// <summary>
    /// Mermi hasarini guclendirir.
    /// </summary>
    public void UpgradeBullet()
    {
        if(playerMoney >= bulletCost)
        {
            playerMoney -= bulletCost;
            currentBulletDamageValue = nextBulletDamageValue;
            bulletDamage = currentBulletDamageValue;
            nextBulletDamageValue += 20;
            bulletCost *= 2;
        }
        
    }
    
    /// <summary>
    /// Balonun cani gelistirir.
    /// </summary>
    public void UpgradeHealth()
    {
        if(playerMoney >= healthCost)
        {
            playerMoney -= healthCost;
            currentHealthValue = nextHealthValue;
            nextHealthValue += 50;
            healthCost *= 2;
        }
    }
    
}
