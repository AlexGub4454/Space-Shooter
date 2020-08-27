using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
     int score=4;
     // Start is called before the first frame update
    void Awake()
    {
        if (FindObjectsOfType<GameSession>().Length>1) {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore() => score;
      
    // Update is called once per frame
   public void AddScore(int score1)
    {
        score += score1;
        
    }
    public void Reset()
    {
        Destroy(gameObject);
    }
    
}
