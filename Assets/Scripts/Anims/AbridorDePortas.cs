using System.Collections;
using UnityEngine;

public class AbridorDePortas : MonoBehaviour
{
    [SerializeField]
    Animator[] animators;
    IEnumerator abrirAosPoucos;
    [SerializeField]
    float tempoDeAbertura = 0.2f;

    private void Start()
    {
        abrirAosPoucos = Abrindo();
    }

    public void AbrirTodasAsPortas()
    {
        StartCoroutine(abrirAosPoucos);
    }

    IEnumerator Abrindo()
    {
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].SetTrigger("IsOpening");
            yield return new WaitForSeconds(tempoDeAbertura);    
        }
    }
}
