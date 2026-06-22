using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadeMovimento = 4.0f;
    public float forcaPulo = 10.0f;
    public float forcaPuloAposRolagem = 10.0f;
    private bool podePular = true;
    private bool estaRolando = false;

    // Variáveis de ataque
    public bool estaAtacando = false;
    public Transform pontoAtaque;
    public float raioAtaque = 0.5f;
    public LayerMask camadaInimigos;
    public float tempoEntreAtaques = 1.0f;
    private float tempoProximoAtaque = 0.0f;
    public float duracaoDaAnimacaoDeAtaque = 0.5f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;

    private float tempoRolando = 0f;
    private float duracaoRolagem = 3f;

    private float tempoPuloAposRolar = 1.0f;
    private bool agendarPuloAposRolar = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.enabled = false;
    }

    private void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");

        Vector3 movimento = new Vector3(movimentoHorizontal, 0, 0) * velocidadeMovimento * Time.deltaTime;

        transform.Translate(movimento);

        if (Input.GetKeyDown(KeyCode.Space) && podePular)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            podePular = false;
            animator.SetBool("pulando", true);
            EncerrarRolagem(movimentoHorizontal);
        }

        if (Input.GetKeyDown(KeyCode.R) && movimentoHorizontal != 0)
        {
            animator.SetTrigger("rolando");
            estaRolando = true;
            tempoRolando = 0f;
            AgendarPuloAposRolar();
        }

        // Ataque
        if (Input.GetKeyDown(KeyCode.F) && !estaAtacando)
        {
            Atacar();
        }

        // Verifique se o jogador está se movendo
        if (movimentoHorizontal != 0)
        {
            // Encerre a animação de ataque e redefina a variável estaAtacando
            animator.ResetTrigger("ataque");
            estaAtacando = false;
        }

        if (estaRolando)
        {
            tempoRolando += Time.deltaTime;

            if (tempoRolando >= duracaoRolagem)
            {
                EncerrarRolagem(movimentoHorizontal);
            }

            boxCollider.enabled = false;
            circleCollider.enabled = true;
        }
        else
        {
            boxCollider.enabled = true;
            circleCollider.enabled = false;
        }

        animator.SetBool("correndo", movimentoHorizontal != 0);

        if (movimentoHorizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movimentoHorizontal < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            animator.SetTrigger("parar");
        }
    }

    private void AgendarPuloAposRolar()
    {
        if (!agendarPuloAposRolar)
        {
            agendarPuloAposRolar = true;
            Invoke("PuloAposRolar", tempoPuloAposRolar);
        }
    }

    private void PuloAposRolar()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcaPuloAposRolagem, ForceMode2D.Impulse);
        podePular = false;
        animator.SetBool("pulando", true);
        EncerrarRolagem(Input.GetAxisRaw("Horizontal"));
        agendarPuloAposRolar = false;
    }

    private void EncerrarRolagem(float movimentoHorizontal)
    {
        estaRolando = false;
        tempoRolando = 0f;

        if (Mathf.Approximately(movimentoHorizontal, 0f))
        {
            animator.SetTrigger("parar");
        }
    }

    private void Atacar()
    {
        estaAtacando = true;
        tempoProximoAtaque = Time.time + tempoEntreAtaques;
        animator.SetTrigger("ataque"); // Inicie a animação de ataque no Animator

        Collider2D[] inimigos = Physics2D.OverlapCircleAll(pontoAtaque.position, raioAtaque, camadaInimigos);

        // Lógica para causar dano aos inimigos aqui

        Invoke("FinalizarAtaque", duracaoDaAnimacaoDeAtaque);
    }

    private void FinalizarAtaque()
    {
        estaAtacando = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            podePular = true;
            animator.SetBool("pulando", false);
            CancelInvoke("AtivarBoxCollider");
            boxCollider.enabled = true;
            circleCollider.enabled = false;
        }
    }
}
