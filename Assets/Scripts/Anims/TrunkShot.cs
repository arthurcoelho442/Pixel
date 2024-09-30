using UnityEngine;

public class TrunkShot : MonoBehaviour
{
    [SerializeField]
    ControleDoJogador controle;
    [SerializeField]
    GameObject tiroPrefab;
    [SerializeField]
    Transform tiroSpawnPoint;
    [SerializeField]
    float force = 10f;
    public void Atirar()
    {
        GameObject tiro = Instantiate(tiroPrefab, tiroSpawnPoint.position, Quaternion.identity);
        Rigidbody2D rigidbody2D = tiro.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(new Vector2(controle.Flipped == true? 0.1f:-0.1f, 0.01f) * force, ForceMode2D.Impulse);
    }
}
