using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_gecis : MonoBehaviour
{
    // Start is called before the first frame update
    public void level_ac(string level_ismi)
    {
        SceneManager.LoadScene(level_ismi);

    }
    public void level_ac_siradaki()
    {
        string level_ismi = ( PlayerPrefs.GetInt("level")+1).ToString();
        SceneManager.LoadScene(level_ismi);
    }
}
