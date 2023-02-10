using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Device;
//using UnityEngine.UIElements;
//using UnityEngine.WSA;


public class kamera_takip : MonoBehaviour
{
    public Transform hedef;
    public Vector3 ofsett;
    [SerializeField]
    private float farehassasiyet;
    float fareX, fareY;
    Vector3 objrot;
    public Transform karaktervucut;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }



    void Update()
    {

    }
    private void LateUpdate()
    {

        this.transform.position = Vector3.Lerp(this.transform.position, hedef.position + ofsett, Time.deltaTime * 10);
        fareX += Input.GetAxis("Mouse X") * farehassasiyet;
        fareY += Input.GetAxis("Mouse Y") * farehassasiyet;
        if (fareY >= 25)
        {
            fareY = 25;
        }
        if (fareY <= -25)
        {
            fareY = -25;
        }
        this.transform.eulerAngles = new Vector3(fareY, fareX, 0);
        hedef.transform.eulerAngles = new Vector3(0, fareX, 0);

        Vector3 gecici = this.transform.eulerAngles;
        gecici.z = 0;
        gecici.y = this.transform.localEulerAngles.y;
        gecici.x = this.transform.localEulerAngles.x + 10;
        objrot = gecici;
        karaktervucut.transform.eulerAngles = objrot;

    }
}
