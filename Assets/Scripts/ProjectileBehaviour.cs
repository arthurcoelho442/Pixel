using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject[] estilhacos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            foreach (var estilhaco in estilhacos)
            {
                GameObject obj = Instantiate(estilhaco, transform.position, Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-0.05f, 0.06f), 0.1f), ForceMode2D.Impulse);
            }
            Destroy(gameObject);
        }
    }
}
