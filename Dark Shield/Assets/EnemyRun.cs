using UnityEngine;

public class EnemyRunner : MonoBehaviour
{
    public float moveSpeed = 3f; // Velocidade de movimento do inimigo
    public float followDistance = 3f; // Distância para iniciar o movimento em direção ao jogador
    public Transform player; // Referência ao transform do jogador

    private bool isFollowingPlayer = false;

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // Verifica se o jogador está próximo o suficiente para começar a seguir
        if (distanceToPlayer <= followDistance)
        {
            isFollowingPlayer = true;
        }
        else
        {
            isFollowingPlayer = false;
        }

        if (isFollowingPlayer)
        {
            // Move em direção ao jogador
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // Inverte a escala do sprite se o jogador estiver à esquerda do inimigo
            if (player.position.x < transform.position.x)
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
            else
            {
                Vector3 scale = transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }
    }
}
