using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cargar : MonoBehaviour
{
    public string escena;
    
    // Start is called before the first frame update
   public void Load()
    {

        SceneManager.LoadScene(escena);
    }
}
