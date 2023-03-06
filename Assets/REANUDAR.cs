using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REANUDAR : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pausa;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void reanudar()
    {

        pausa.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
