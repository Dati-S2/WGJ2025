using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    float movH;
    [SerializeField] private float vel;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        movH = Input.GetAxis("Horizontal")*Time.deltaTime*vel;
        Vector3 posicion = transform.position;
        transform.position = new Vector3(movH + posicion.x, posicion.y, posicion.z);
    }

   
}
