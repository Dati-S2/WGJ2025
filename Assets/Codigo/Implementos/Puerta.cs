using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    public bool AreaJugador = false;
    public int Nivel;

    private void Update()
    {
      if (AreaJugador ==true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(Nivel);
            }                        
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            AreaJugador = true;
    }
}
