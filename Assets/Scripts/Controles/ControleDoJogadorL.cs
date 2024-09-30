using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoJogadorL : MonoBehaviour
{
    #region Campos
    float direcaoHorizontal;
    [SerializeField]
    float aceleracao, velocidadeMaximaX, velocidadeMaximaY, forcaDoPulo, desacell, gravidade;
    bool puleAgora, correndo;
    public bool flipped;
    PlayerActions pActions;
    [SerializeField]
    EventoAlavanca eventoAlavanca;
    Rigidbody2D rb2d;
    Animator anim;
    AnimatorStateInfo animStateInfo;
    SpriteRenderer spriteR;
    GroundControl groundControl;
    bool bPodeAtacar = true;
    #endregion

    #region Propriedades
    public bool Flipped
    {
        get { return flipped; }
    }
    #endregion

    #region Loop do Unity
    private void Awake()
    {
        pActions = new PlayerActions();
    }

    private void OnEnable()
    {
        pActions.Enable();
    }

    private void OnDisable()
    {
        pActions.Disable();
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
        groundControl = transform.GetChild(0).GetComponent<GroundControl>();
        pActions.MovesMap.JumpMove.started += _ => puleAgora = true;
        pActions.MovesMap.JumpMove.canceled += _ => puleAgora = false;
        pActions.MovesMap.Acionar.started += _ => Acionar();
        pActions.MovesMap.Atacar.started += _ => Atacar();
    }

    void Update()
    {
        direcaoHorizontal = pActions.MovesMap.HorizontalMove.ReadValue<Vector2>().x;

        if (direcaoHorizontal != 0)
        {
            Mover();
            correndo = true;
        }
        else
        {
            float xVel = rb2d.velocity.x;
            xVel = Mathf.Lerp(xVel, 0, Time.deltaTime * desacell);
            rb2d.velocity = new Vector2(xVel, rb2d.velocity.y);
            correndo = false;
        }

        LimiteDeVelocidade();

        Virar(direcaoHorizontal);

        if (puleAgora)
        {
            Pular();
        }
        else
        {
            if (!puleAgora && !groundControl.Contato)
                rb2d.AddForce(new Vector3(rb2d.velocity.x, -gravidade), ForceMode2D.Force);
        }

        if (rb2d.velocity.y < 2.5f)
        {
            rb2d.gravityScale = groundControl.Contato ? 1 : Mathf.Lerp(1f, 2f, 4f);
            puleAgora = false;
        }

        Animar();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Alavanca")
        {
            eventoAlavanca = collision.GetComponent<EventoAlavanca>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Alavanca")
        {
            eventoAlavanca = null;
        }
    }
    #endregion

    #region Métodos
    private void Virar(float direcaoHorizontal)
    {
        if (direcaoHorizontal > 0)
        {
            spriteR.flipX = false;
            flipped = false;
        }
        else if (direcaoHorizontal < 0)
        {
            spriteR.flipX = true;
            flipped = true;
        }
        else
        {
            return;
        }
    }

    void Acionar()
    {
        if (eventoAlavanca != null)
        {
            eventoAlavanca.Acionar();
        }
    }

    private void LimiteDeVelocidade()
    {
        float velocidadeGranpeadaX = Mathf.Clamp(rb2d.velocity.x, -velocidadeMaximaX, velocidadeMaximaX);
        float velocidadeGranpeadaY = Mathf.Clamp(rb2d.velocity.y, -velocidadeMaximaY, velocidadeMaximaY);
        rb2d.velocity = new Vector2(velocidadeGranpeadaX, velocidadeGranpeadaY);
    }

    private void Mover()
    {
        rb2d.AddForce(new Vector2(direcaoHorizontal * aceleracao * Time.deltaTime, 0), ForceMode2D.Force);
    }

    void Pular()
    {
        if (groundControl.Contato)
        {
            rb2d.AddForce(new Vector2(0, forcaDoPulo), ForceMode2D.Impulse);
        }

    }

    void Animar()
    {
        if (correndo)
        {
            anim.SetBool("isRunning", true);
        }
        else if (!correndo)
        {
            anim.SetBool("isRunning", false);
        }

        if (puleAgora)
        {
            anim.SetTrigger("isJumping");
        }
    }

    void Atacar()
    {
        if (!bPodeAtacar) return;
        anim.SetLayerWeight(1, 1.0f);
        anim.SetTrigger("isAttacking");
        bPodeAtacar = false;
    }

    public void DepoisDoAtaque()
    {
        anim.SetLayerWeight(1, 0.0f);
        bPodeAtacar = true;
    }


    #endregion
}
