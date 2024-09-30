using UnityEngine;

public class BlockerTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject[] blocker;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < blocker.Length; i++)
            {
                blocker[i].SetActive(true);
            }
        }
    }
}
