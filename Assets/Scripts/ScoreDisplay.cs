using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text textscore;
   GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
       gameSession = FindObjectOfType<GameSession>();
        textscore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textscore.text = gameSession.GetScore().ToString();
    }
}
