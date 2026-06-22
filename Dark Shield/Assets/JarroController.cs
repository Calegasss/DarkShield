using UnityEngine;

public class JarroController : MonoBehaviour
{
    public float vidaGanhaPercent = 0.2f; // Porcentagem da vida que o jogador ganha ao interagir com o jarro

    private bool isNearJarro = false;

    private GameObject player; // Referência ao jogador

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearJarro = true;
            player = other.gameObject; // Armazena uma referência ao jogador
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearJarro = false;
            player = null; // Limpa a referência ao jogador quando ele sai da área do jarro
        }
    }

    private void Update()
    {
        if (isNearJarro && Input.GetKeyDown(KeyCode.E))
        {
            AumentarVidaDoJogador();
            DestruirJarro();
        }
    }

    private void AumentarVidaDoJogador()
    {
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                float vidaGanha = playerHealth.maxHealth * vidaGanhaPercent;
                playerHealth.IncreaseHealth(vidaGanha);
            }
        }
    }

    private void DestruirJarro()
    {
        Destroy(gameObject);
    }
}
