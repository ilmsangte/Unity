using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;

    int score;

    private void Update() {
        score = int.Parse(text.text);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "check"){
            score+=1;
            text.text=score.ToString();
        }
    }
}
