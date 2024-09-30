using UnityEngine;

public class TiroOriginPos : MonoBehaviour
{
    [SerializeField]
    ControleDoJogador controle;

    private void Update()
    {
        if (!controle.Flipped)
        {
            transform.localPosition = new Vector3(-0.156f, -0.048f, 0f);
        }
        else if (controle.Flipped)
        {
            transform.localPosition = new Vector3(0.11f, -0.048f, 0f);
        }
    }
}
