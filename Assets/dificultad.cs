using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dificultad : MonoBehaviour
{
    public TextMeshProUGUI _dificulta;
    public string nombre;
    // Start is called before the first frame update

    public void nombrar()
    {
        _dificulta.text = nombre;
    }
    // Update is called once per frame
    
}
