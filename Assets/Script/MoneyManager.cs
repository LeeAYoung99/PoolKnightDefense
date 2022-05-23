using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int gold = 200;
    public int mineral = 0;
    public int digger = 1;

    public Text goldText;
    public Text mineralText;
    public Text diggerText;

    float time = 0;
    float maxTime = 2.0f;
    int timeMineral = 2;

    GameManager gameManager;
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = gold.ToString();
        mineralText.text = mineral.ToString();
        diggerText.text = digger.ToString();

        if (gameManager.gameStart)
        {
            time += Time.deltaTime;
            if (time >= maxTime)
            {
                mineral += digger * timeMineral;
                time = 0;
            }
        }
    }

    public void BuyDigger()
    {
        if(digger<10 && gold>=70)
        {
            audioSource.PlayOneShot(audioClip);
            digger++;
            gold -= 70;
        }
    }
}
