using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    public void CriarJogador()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
