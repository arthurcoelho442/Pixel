
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    private bool contato = false;

    public bool Contato { get => contato; set => contato = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Contato = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Contato = false; 
        }  
    }
}
