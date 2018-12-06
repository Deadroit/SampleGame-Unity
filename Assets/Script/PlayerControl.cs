using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public float kecepatan;
    private Rigidbody rb;
    private int countPoint;
    private int nyawa;
    private int goalPoint;
    public Text PointUI;
    public Text HealthUI;
    private GameObject targetParent;
    public Text winText;
    public AudioSource kenaMusuh;
    public AudioSource kenaPoint;
    private float waktuDisplay = 2;
    private float waktuDisplayDeath = 2;

    //  Dieksekusi pada saat object di buat atau scene di mulai
    void Start()
    {
        //Mendapatkan component RigidBody dari gameObject yang tertanam
        rb = GetComponent<Rigidbody>(); 
        nyawa = 3; //Inisialisasi nyawa untuk kararkter
        countPoint = 0; //Inisialisasi point saat pertama mulai 
        targetParent = GameObject.Find("Pick Ups"); // Memanggil game object yang menjadi parent pickup 
        goalPoint =  targetParent.transform.childCount; //Menghitung jumlah pickup yang menjadi child dari object parent 
        SetCountText(); //menginisialisasi teks UI
    }

    // Di eksekusi berulang kali setiap frame 
    void Update() {
        
    }

    //Dieksekusi berulangkali setiap frame tetapi dengan deltaTime yang sama
    private void FixedUpdate() 
    {
        float gerakHorizontal = Input.GetAxis("Horizontal"); //Mengambil nilai orientasi horizontal nilainya adalah 1 jika Kanan(D,->) -1 jika kiri(A.<-)
        float gerakVertikal = Input.GetAxis("Vertical"); //Mengambil nilai orientasi horizontal nilainya adalah 1 jika Atas(W, Arah atas) -1 jika  Bawah(S, Arah Bawah)

        Vector3 pergerakan = new Vector3(gerakHorizontal, 0.0f, gerakVertikal); //Membuat vektor3D berupa gerakan 3 Dimensi
        rb.AddForce(pergerakan * kecepatan);// Menerpakan gaya 3D pada rigidbody dari player agar player  bergerak

        if (countPoint == goalPoint) //Ketika point yang di kumpulkan 
        {
            winText.gameObject.SetActive(true); //menampilkan winText 
            waktuDisplay -= Time.deltaTime; //Membuat delay agar wintext terbaca, time.delta time adalah sebuah variable yang berisi selisih waktu antar frame game
            if (waktuDisplay <= 0) { //jika waktu delay  habis
                SceneManager.LoadScene("StartMenu"); //Memuat scene yan bernama "StartMenu"
            }
        }
        if (nyawa <= 0)//Ketika nyawa habis 
        {


            winText.text = "You Die"; //mengganti win text menjadi you die
            winText.gameObject.SetActive(true); // menampilkan wintext
            waktuDisplayDeath -= Time.deltaTime; //Membuat delay agar wintext terbaca, time.delta time adalah sebuah variable yang berisi selisih waktu antar frame game
            if (waktuDisplayDeath <= 0)//jika waktu delay  habis
            {
                SceneManager.LoadScene("GameOver");//Memuat scene yan bernama "GameOver"
            }
        }
    }

    void OnTriggerEnter(Collider other) //di eksekusi jika player menabrak object yang memiliki collider bertipe isTrigger, other adalah collider lawan tabrayk
    {
        if (other.gameObject.CompareTag("Pick Up"))  //Membandingkan tag dari object yang di tabrak
        {
            kenaPoint.Play(); //play musik
            other.gameObject.SetActive(false); //Membuat object yang di tabrak menghilang
            countPoint = countPoint + 1; //menambah nilai point
            SetCountText();//Merefresh nilai text UI
        }
     
        if (other.gameObject.CompareTag("Enemy")) //Membandingkan tag dari object yang di tabrak
        {
            kenaMusuh.Play();//play musik

            other.gameObject.SetActive(false);//Membuat object yang di tabrak menghilang
            nyawa = nyawa -1;//Mengurangi nyawa
            SetCountText(); // Merefresh nilai text UI

        }
    }

    void SetCountText()
    {
        PointUI.text = "Point: " + countPoint.ToString(); //Mengisi text Point UI 
        HealthUI.text = "Health: " + nyawa.ToString(); //Mengisi text health

    }
    
}
