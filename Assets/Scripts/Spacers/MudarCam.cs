using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCam : MonoBehaviour
{
    public string nomeDaCena = "Cena1-1";
    public int numeroDaCamera = 1;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.Instance.LoadScene(nomeDaCena, LoadSceneMode.Additive);
            GameManager.Instance.CriarCam(numeroDaCamera);
            transform.gameObject.SetActive(false);
        }
    }
}
