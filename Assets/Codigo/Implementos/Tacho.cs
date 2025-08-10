using UnityEngine;
using UnityEngine.SceneManagement;

public class Tacho : MonoBehaviour
{
    bool AreaTacho;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            AreaTacho = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        AreaTacho = false;
    }
    private void Update()
    {
        if (AreaTacho == true)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                GameController.instance.Completado = true;
            }
            

        }
        
    }
}
