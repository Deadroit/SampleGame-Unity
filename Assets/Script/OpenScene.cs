using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenScene : MonoBehaviour
{

    //  Dieksekusi pada saat object di buat atau scene di mulai
    void Start()
    {

    }

    // Di eksekusi berulang kali setiap frame 
    void Update()
    {
    }

    public void bukaScene(string namaScene)
    { // akan di ekseskusi ketika button StartButton di pencet
        SceneManager.LoadScene(namaScene); //merupakan method yang digunakan untuk membuka scene berdasarkan string inputan
    }

}
