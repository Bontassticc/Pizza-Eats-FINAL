using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sourcename)
    {
        SceneManager.LoadScene(sourcename);
    }
    public void TutorialScene(string sourcename)
    {
        SceneManager.LoadScene(sourcename);
    }
}
