using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void GameScene()
    {
       
        SceneManager.LoadScene(1);
    }
   public static IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
