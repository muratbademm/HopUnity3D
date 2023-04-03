using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yerdemi : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask zeminim;
    public bool yerdemi_karakter;
    public Rigidbody2D rigidbo; //zıplama özelliğini buradaki fiziksel tanımlamadan aldık oyun motorunda script içinden zıplayacak nesneyi seçtik yani karakteri
    public float ziplamaguc;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (karakter_kontrol.oyun_basladimi == false)
        {
            return;
        }
        RaycastHit2D carp = Physics2D.Raycast(transform.position, Vector2.down, 0.1f,zeminim);//raycast zemine 0.1floatlık ışın gönderdi çarpınca if else devreye girdi
        if (carp.collider != null)
        {
            //zemine çarpmıştır karakterimiz
            yerdemi_karakter = true;
        }
        else
        {
            yerdemi_karakter = false;
            //havadadır hala karakter
        }
        if (Input.GetKeyDown(KeyCode.Space) && yerdemi_karakter == true) //space tuşunu karakter yerdeyse aktifleştirdik 
        {
            rigidbo.velocity += new Vector2(0,ziplamaguc); //zıplama hızı 2f olarak belirlendi
        }
    }
}
