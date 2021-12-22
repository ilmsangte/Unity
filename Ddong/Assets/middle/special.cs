using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class special : MonoBehaviour
{
    private static special _instance;
    public static special Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<special>();
            }
            return _instance;
        }
    }
    [SerializeField]
    private GameObject poop;

    [SerializeField]
    private GameObject fruit;

    private int score;

    [SerializeField]
    private Text scoreTxt;

    [SerializeField]
    private Transform objbox;

    [SerializeField]
    private Text bestScore;
    [SerializeField]
    private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreatepoopRoutine());
        panel.SetActive(false);
        StartCoroutine(CreateFruitRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool stopTrigger = true;

    public void GameOver()
    {
        stopTrigger = false;

        StopCoroutine(CreatepoopRoutine());
        if (score >= PlayerPrefs.GetInt("BestScore", 0))
            PlayerPrefs.SetInt("BestScore", score);
        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        panel.SetActive(true);
    }

    public void GameStart()
    {
        score = 0;
        scoreTxt.text = "Score :" + score;
        stopTrigger = true;
        panel.SetActive(false);
    }


    public void Score()
    {
        score++;
        scoreTxt.text = "Score :" + score;
    }

    public void Score2()
    {
        score++;
        scoreTxt.text = "Score :" + score;
    }

    IEnumerator CreatepoopRoutine()
    {
        while (true)
        {
            CreatePoop();
            yield return new WaitForSeconds(0.3f);
        }    
    }

    IEnumerator CreateFruitRoutine()
    {
        while (true)
        {
            Createfruit();
            yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 2f));
        }
    }

    private void CreatePoop()
    {
        Vector3 pos = new Vector3(UnityEngine.Random.Range(-2.8f, 2.8f), 7.1f, 0);
        pos.z = 0.0f;
        Instantiate(poop, pos, Quaternion.identity);
    }

    private void Createfruit()
    {
        Vector3 pos = new Vector3(UnityEngine.Random.Range(-2.8f, 2.8f), 7.1f, 0);
        pos.z = 0.0f;
        Instantiate(fruit, pos, Quaternion.identity);
    }
}
