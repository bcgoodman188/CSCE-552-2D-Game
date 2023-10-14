using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    EnemySpawner enemySpawner;
    [SerializeField] public int currency;
    [SerializeField] public int lifeTotal;
    [SerializeField] public int winningWave;
    public string gameOverScene;
    public string victoryScene;
    public TextMeshProUGUI currencyTextUI;
    public TextMeshProUGUI lifeTextUI;
    public TextMeshProUGUI mobTextUI;
    public TextMeshProUGUI waveTextUI;
    public AudioSource dmgSound;

    private void Start() {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Update()
    {
        currencyTextUI.text = "Currency: " + currency.ToString();
        lifeTextUI.text = "Life: " + lifeTotal.ToString();
        mobTextUI.text = "Mobs Left: " + enemySpawner.mobs.ToString();
        waveTextUI.text = "Wave: " + enemySpawner.wave.ToString();
        if(lifeTotal <= 0) {
            SceneManager.LoadScene(gameOverScene);
        }
        if(enemySpawner.wave == winningWave) {
            SceneManager.LoadScene(victoryScene);
        }
    }
}
