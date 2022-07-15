using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void restart()
    {
        Debug.Log("Restart button pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);

    }

}
