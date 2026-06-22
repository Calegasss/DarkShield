using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10; // Dano causado pelo inimigo

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o jogador colidiu com o inimigo
        if (collision.gameObject.CompareTag("Player"))
        {
            // Acesse o componente da barra de vida do jogador
            PlayerHealth healthBar = collision.gameObject.GetComponent<PlayerHealth>();

            if (healthBar != null)
            {
                // Causa dano ao jogador
                healthBar.currentHealth -= damage; // Reduz a vida do jogador

                // Adicione aqui qualquer lógica adicional, como animações ou efeitos sonoros
            }
        }
    }
}
