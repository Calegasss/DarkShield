using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Velocidade de movimento do inimigo
    public float moveDistance = 5f; // Distância que o inimigo percorre em uma direção

    private Vector3 initialPosition; // Posição inicial do inimigo
    private bool movingRight = true; // Flag para controlar a direção do movimento

    private void Start()
    {
        initialPosition = transform.position; // Armazena a posição inicial do inimigo
    }

    private void Update()
    {
        // Move o inimigo para a direita ou para a esquerda
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        // Verifica se o inimigo atingiu a distância máxima e precisa virar
        if (Vector3.Distance(initialPosition, transform.position) >= moveDistance)
        {
            // Inverte a direção do movimento
            movingRight = !movingRight;

            // Inverte a escala do sprite para fazer o inimigo olhar na direção correta
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
