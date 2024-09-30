using UnityEngine;

public class StompDeath : MonoBehaviour
{
    [SerializeField]
    GameObject deathAnim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "StompAtk")
        {
            MortePorContato();
        }

        if (collision.gameObject.tag == "TopCrush")
        {
            MortePorContato();
        }
    }

    void MortePorContato()
    {
        Instantiate(deathAnim, transform.position, Quaternion.identity);
        transform.parent.gameObject.SetActive(false);
    }
}
