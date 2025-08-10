using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    public Animator animator;
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

        animator.SetFloat("Movimiento", movH*vel);

        if (vel < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
            

        if (vel >= 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
            

        Vector3 posicion = transform.position;
        transform.position = new Vector3(movH + posicion.x, posicion.y,0);


    }




}
