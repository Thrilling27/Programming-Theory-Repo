using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    //ABSTRACTION
    public void startNew()
    {
        SceneManager.LoadScene(1);
    }
}
