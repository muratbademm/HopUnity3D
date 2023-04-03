using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //canvas objesini yani arayüzlerimizi görmemizi sağlayan kütüphane
using UnityEngine.SceneManagement;// sahnelerimizi getiren değiştiren kütüphane

public class karakter_kontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float hız;
    public Animator animasyonum;
    float horizontal;
    public int altin_miktari;
    public Text text_altin_sayisi;
    public GameObject panel_oyun;
    public Text oyun_sonu_altin;
    public static bool oyun_basladimi = false; // yerdemi scriptinden ulaşmak için static yaptık
    public GameObject panel_oyun_basi;
    public AudioSource altin_Sesi;
    public int level_kac = 1;
    void Start()
    {
        oyun_basladimi = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (oyun_basladimi == false)
        {
            return;// oyun başlamadıysa karakter hareketi yok geri dönğyor
        }
        Dusme(); 
        horizontal = Input.GetAxis("Horizontal"); // klavye yon tuşlarına basınca hareket etmemizi sağlayan yön komutu 
        hız = 2f;

        /* horizantal -1 ve 1 aralığında değişir sola veya sağa gidiyor 0 da hiçbirine
        basmıyoruz demektir klavye için geçerli */
        bool kosmakontrol = false;
        if (horizontal != 0)
        {
            kosmakontrol = true;
            animasyonum.speed = Mathf.Abs(horizontal); // koşarken -1,0,1 yani horizontal değerine eşitledik hızı horizontal 0 olunca otamatik hız 0 lanacak ve idle animasyonuna geçecek idle( durma pozisyonunda ki animosyonun ismi )

        }
        else
        {
            //dururken
            animasyonum.speed = Mathf.Abs(1);
        }
        animasyonum.SetBool("kosmakontrol", kosmakontrol);
        transform.position += new Vector3(horizontal * hız * Time.deltaTime, 0, 0);
        Yonduzeltme();

    }

    void Yonduzeltme()
    {
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // horizantal 0 dan küçükken -1 yönüne yani sola dönsün sol tuşu veya a ya basılınca

        }
        else if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }


    }
    void OnTriggerEnter2D(Collider2D carpilanobje)//çarpışmaları anlayan fonksiyonumuz stay olsaydı çarpışma sürdüğü sürece mesaja deva ederdi
    {
        if (carpilanobje.tag == "altinlar")
        {

            altin_miktari++;
            text_altin_sayisi.text = altin_miktari.ToString(); // altın miktarı integer olduğu için stringe çevirip text içine yazdırdık atadık
            altin_Sesi.Play();
            Destroy(carpilanobje.gameObject); // çarpılan altın objesini oyundan siler
        }
        else if (carpilanobje.tag == "tuzak")
        {
            Olme();
        }
        else if (carpilanobje.tag == "kapi")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// aktif sahneyi 1 arttırarak diğer sahneye geç build settingsteki sıraya göre
            if (PlayerPrefs.GetInt("level") < level_kac)//levelimizi getirdi  ve önceden açtığımız level varsa küçükse son açtığımız değerden kaydını hala son levelde tuttu
            {
                PlayerPrefs.SetInt("level", level_kac); // kullanıcının levelleri kaydolur playprefs kayıt dosyası oluşturmamıza yaradı
            }
            
        }
    }
    public void Olme()
    {
        Debug.Log("öldün");
        Destroy(gameObject); //objeyi kaldır
        panel_oyun.SetActive(true); // panel tekrar oyunu canvasını tekrar aktifleştirdi
        oyun_sonu_altin.text = text_altin_sayisi.text; // texteki altın sayısını oyun sonu gösterdik
    }
    public void oyuna_basla()
    {
        oyun_basladimi = true;
        panel_oyun_basi.SetActive(false); //hazırmısın panelini kapat
    }
    public void Dusme()
    {
        if (transform.position.y < -5f)
        {
           
            Olme(); // -5f değerinde herhangi bir zemine 0.1 ışında rigidbody ile algılanmadıysa bu fonksiyon devreye girer
            
        }
    } 
}
