using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int danoAtaque = 20;
    public float velocidadeMovimento = 2.0f;
    public float alcanceAtaque = 2.0f;

    private int vidaAtual;
    private Transform jogador;
    private Animator animator;
    private bool estaAtacando = false;
    private bool estaMorto = false;

    private void Start()
    {
        vidaAtual = vidaMaxima;
        jogador = GameObject.FindGameObjectWithTag("Player").transform; // Supõe que o jogador tenha a tag "Player".
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (estaMorto)
            return;

        float distanciaJogador = Vector3.Distance(transform.position, jogador.position);

        if (distanciaJogador <= alcanceAtaque)
        {
            Atacar();
        }
        else
        {
            PerseguirJogador();
        }
    }

    private void PerseguirJogador()
    {
        animator.SetBool("correndo", true);
        animator.SetBool("atacando", false);

        transform.position = Vector2.MoveTowards(transform.position, jogador.position, velocidadeMovimento * Time.deltaTime);
        FlipSprite();
    }

    private void Atacar()
    {
        animator.SetBool("correndo", false);
        animator.SetBool("atacando", true);

        if (!estaAtacando)
        {
            // Realize a lógica para causar dano ao jogador aqui
            // Por exemplo: jogador.GetComponent<PlayerController>().SofrerDano(danoAtaque);

            estaAtacando = true;
            Invoke("ResetAtaque", 1.0f); // Tempo de recarga do ataque
        }
    }

    private void ResetAtaque()
    {
        estaAtacando = false;
    }

    public void SofrerDano(int quantidadeDano)
    {
        if (!estaMorto)
        {
            vidaAtual -= quantidadeDano;

            if (vidaAtual <= 0)
            {
                Morrer();
            }
        }
    }

    private void Morrer()
    {
        estaMorto = true;
        animator.SetBool("morto", true);
        // Realize a lógica de morte, como desativar colisores, emitir partículas, etc.
        Destroy(gameObject, 2.0f); // Remover o inimigo após 2 segundos.
    }

    private void FlipSprite()
    {
        if (jogador.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (jogador.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
