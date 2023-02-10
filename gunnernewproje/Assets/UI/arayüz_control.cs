using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class arayüz_control : MonoBehaviour
{
    public Text HPtext;
    GameObject oyuncu;
    public GameObject pause;
    bool oyundurdu;
    public Text sestext;
    

    void Start()
    {
        oyuncu = GameObject.Find("arrrow");

    }

    
    void Update()
    {
        HPtext.text = "HP:" + oyuncu.GetComponent<karakter_hareket>().GetHP();
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //if (oyundurdu == true)
            //{
            //    oyunudevamettir();
            //}
            if (oyundurdu == false)
            {
                oyunudurdur();
            }
        }
    }
    public void oyunudurdur()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
        oyundurdu = true;
        Cursor.lockState = CursorLockMode.Confined;


    }
    public void oyunudevamettir()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
        oyundurdu = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void çık()
    {
        Application.Quit();
    }
    public void tekrar_dene()
    {
        SceneManager.LoadScene(0);
    }
    

    public void ses(float value)
    {
        AudioListener.volume = value;
        sestext.text = ((int)(value * 100)).ToString();
    }


}
