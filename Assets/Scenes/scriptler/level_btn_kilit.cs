using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level_btn_kilit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
   
        string isim = gameObject.name;
        int level_sirasi = int.Parse(isim);
        if (PlayerPrefs.GetInt("level")+1<level_sirasi)
        {
            GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
