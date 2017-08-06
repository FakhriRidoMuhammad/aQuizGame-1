using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LoadLevel (string LevelName)
    {
        Application.LoadLevel(LevelName);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

}
