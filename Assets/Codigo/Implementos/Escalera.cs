using UnityEngine;
using UnityEngine.SceneManagement;

public class Escalera : MonoBehaviour
{
    [SerializeField] bool Direccion, AreaPuerta;
    [SerializeField] Transform Der, Izq;
    private GameObject Jugador;

    private void Update()
    {
        if (AreaPuerta == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameController.instance.Completado)
                {
                    if (!Direccion)
                    {
                        SceneManager.LoadScene("Nivel 3");
                        Debug.Log ("ño");
                    }
                        

                }
                else
                {
                    if (Direccion)
                    {
                        Jugador.transform.position = Der.position;
                    }
                    else
                    {
                        Jugador.transform.position = Izq.position;
                    }
                }                
            }                       
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AreaPuerta = true;
            Jugador = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AreaPuerta = false;
            Jugador = null;
        }
    }
}
