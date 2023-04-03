using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahne_değistir : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Tekrar_oyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//sahne yükleme kodumuz numara veya sahne ismi yazarız ...... aktif sahneyi getir ismiyle dedik
    }
}
