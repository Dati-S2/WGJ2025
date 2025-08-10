using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool Completado;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }    
    }
}
