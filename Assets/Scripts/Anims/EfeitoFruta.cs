using System.Collections;
using UnityEngine;

public class EfeitoFruta : MonoBehaviour
{
    [SerializeField]
    AudioClip clip;
    [SerializeField]
    AudioSource source;

    private void Start()
    {
        StartCoroutine("Finalizar"); 
    }

    IEnumerator Finalizar()
    {
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(()=>source.isPlaying);
        Destroy(gameObject);
    }
}
