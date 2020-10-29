using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float totalEnemies;
    public TextMeshProUGUI enemiesLeftText;
    public int wave;
    public GameObject _enemiesContainer;
    public GameObject _spawnContainer;
    public Spawn _spawn;
    public List<Spawn> _spawnsList = new List<Spawn>();
    private int _spawnToUse;
    public Player player;
    public Image fireIcon;
    public Image iceIcon;
    public Color midAlpha;
    public Color fullAlpha;
    public Image lifeBar;
    public Image orange;
    public float playerMaxHP;
    public Ads adManager;
    public bool adPlayed = false;
    public GameObject revive;
    public TextMeshProUGUI waveText;
    public GameObject bossHPContainer;
    public Image bossLifeBar;
    public float bossMaxHP;
    public float bossCurrentHP;
    public Console console;
    public GameObject consoleObj;
    public GameObject consoleOpen;
    public GameObject consoleClose;

    private void Awake()
    {
        wave = 1;
        _enemiesContainer = GameObject.Find("Enemies");
        _spawnContainer = GameObject.Find("Spawns");
        
        iceIcon.color = midAlpha;
        GetSpawns();
        SpawnEnemies();

    }
    // Start is called before the first frame update
    void Start()
    {
        bossHPContainer.SetActive(false);
        //consoleObj.SetActive(false);
        consoleOpen.SetActive(true);
        consoleClose.SetActive(false);
        player = FindObjectOfType<Player>();
        playerMaxHP = player.maxHP;
        CheckEnemiesInWave();
        waveText.text = "Wave " + wave;
        StartCoroutine(WaveTextOff());
    }

    // Update is called once per frame
    void Update()
    {
        LifeBar();
        enemiesLeftText.text = "Enemies left: " + totalEnemies;
        if (totalEnemies == 0 && wave < 3)
        {
            waveText.gameObject.SetActive(true);
            wave++;
            waveText.text = "Wave " + wave;
            StartCoroutine(WaveTextOff());
            SpawnEnemies();
            CheckEnemiesInWave();
            if (wave == 3)
                bossHPContainer.SetActive(true);
        }

        if (wave == 3)
            BossLifeBar();

        if (totalEnemies == 0 && wave == 3)
        {
            SceneManager.LoadScene("Win");
        }

        if (player.hp <= 0 && adPlayed == false)
        {
            revive.SetActive(true);
        }

        if (adPlayed)
            revive.SetActive(false);
        if (player.hp <= 0 && adPlayed)
            SceneManager.LoadScene("Lose");
    }



    private void GetSpawns()
    {
        foreach (Transform spawn in _spawnContainer.transform)
        {
            _spawnsList.Add(spawn.gameObject.GetComponent<Spawn>());
        }
    }
    private void SpawnEnemies()
    {
        _spawnToUse = 0;
        while (_spawnToUse < _spawnsList.Count)
        {
            _spawnsList[_spawnToUse].SpawnDragon(wave);

            if (wave == 3)
                _spawnToUse = _spawnsList.Count;
            else _spawnToUse += Random.Range(1, 4);
        }
    }
    private void CheckEnemiesInWave()
    {
        foreach (var enemy in _enemiesContainer.transform)
        {
            totalEnemies++;
        }
    }

    public void ChangeToFire()
    {
        player.element = "Fire";
        fireIcon.color = fullAlpha;
        iceIcon.color = midAlpha;
    }

    public void ChangeToIce()
    {
        player.element = "Ice";
        iceIcon.color = fullAlpha;
        fireIcon.color = midAlpha;
    }

    private void LifeBar()
    {
        lifeBar.fillAmount = player.hp / playerMaxHP;
        if (lifeBar.fillAmount >= 0.7f)
            lifeBar.color = Color.green;
        if (lifeBar.fillAmount < 0.7f && lifeBar.fillAmount > 0.5f)
            lifeBar.color = Color.yellow;
        if (lifeBar.fillAmount < 0.5f && lifeBar.fillAmount > 0.3f)
            lifeBar.color = orange.color;
        if (lifeBar.fillAmount < 0.3f)
            lifeBar.color = Color.red;
    }

    private void BossLifeBar()
    {
        bossLifeBar.fillAmount = bossCurrentHP / bossMaxHP;
    }

    public void Lose()
    {
        SceneManager.LoadScene("Lose");
    }

    public void HealPlayer()
    {
        player.hp = playerMaxHP;
    }

    IEnumerator WaveTextOff()
    {
        yield return new WaitForSeconds(5);
        waveText.gameObject.SetActive(false);
    }

    public void ReduceEnemiesCount()
    {
        totalEnemies--;
    }

    public void OpenConsole()
    {
        consoleObj.SetActive(true);
        consoleOpen.SetActive(false);
        consoleClose.SetActive(true);
    }

    public void CloseConsole()
    {
        print("cierro");
        console.CloseConsole();
        consoleOpen.SetActive(true);
        consoleClose.SetActive(false);
    }
}
