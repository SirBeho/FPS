using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemig : MonoBehaviour
{
    public int enemy = 5;
    public TextMeshProUGUI enemigos;
    public TextMeshProUGUI scorefinal;
    public TextMeshProUGUI score;
    public GameObject fin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemigos.text = enemy.ToString();
        if (enemy <= 0)
        {
            scorefinal.text = "Score: " + score.text;
            Cursor.lockState = CursorLockMode.None;
            fin.SetActive(true);

            //fin de juego
        }
    }
    public void eliminado()
    {
        enemy--;
    }
}
