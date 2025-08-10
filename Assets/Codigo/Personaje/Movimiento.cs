using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    float movH;
    [SerializeField] private float vel;
   
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        movH = Input.GetAxis("Horizontal") * Time.deltaTime * vel;
        Vector3 posicion = transform.position;
        transform.position = new Vector3(movH + posicion.x, posicion.y,0);


    }




}
