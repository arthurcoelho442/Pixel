using System.Collections;
using UnityEngine;

public class DeathTransparence : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sp;
    bool now = false;

    void Update()
    {
        if (!now) return;
        StartCoroutine("TRoutine");
    }

    public void DigaQuandoTranp()
    {
        now = true;
    }

    public void Restart()
    {
        GameManager.Instance.LoadScene("Boot", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    IEnumerator TRoutine()
    {
        Color c = sp.color;
        Vector3 escala = transform.localScale;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            sp.color = c;
            escala *= alpha;
            transform.localScale = escala;
            yield return new WaitForSeconds(.05f);
        }
    }
}
