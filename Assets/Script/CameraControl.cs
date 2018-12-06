using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    //  Dieksekusi pada saat object di buat atau scene di mulai

    void Start()
    {
        player = GameObject.Find("Player");  //Mengisi GameObject bernama player  dan membuat
        offset = transform.position - player.transform.position;     //Mengetahui jarak awal antara kamera dan player
    }

    // Di eksekusi berulang kali setiap frame 
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; //Menjaga agar kamera tetap memiliki jarak yang sama dengan player
    }
}
