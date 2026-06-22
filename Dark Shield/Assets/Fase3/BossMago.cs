using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMago : MonoBehaviour
{
    public float speed = 5f;
    public float chaseRange = 10f;
    public float attackRange = 2f; // Alcance de ataque
    public float attackCooldown = 2f; // Tempo entre os ataques

    private Transform player;
    private Animator animator;
    private bool isMoving = false;
    private bool isAttacking = false;
    private float lastAttackTime = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            // Verifica a posição do jogador para mudar de dire��o
            if (direction.x > 0 && transform.localScale.x > 0)
            {
                Flip();
            }
            else if (direction.x < 0 && transform.localScale.x < 0)
            {
                Flip();
            }

            // Verifica se pode atacar
            if (distanceToPlayer <= attackRange && !isAttacking)
            {
                Attack();
            }
            else if (isAttacking && Time.time - lastAttackTime >= attackCooldown)
            {
                isAttacking = false;
            }
            else
            {
                // Move em direção ao jogador
                transform.Translate(direction * speed * Time.deltaTime);
                isMoving = true;
            }
        }
        else
        {
            isMoving = false;
        }

        // Atualiza os parametros do Animator
        animator.SetBool("correndo", isMoving);
        animator.SetBool("atacando", isAttacking);
        // Adicione outros par�metros, transições e estados conforme necess�rio.
    }

    // Função para inverter a direção horizontal do inimigo
    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Função para iniciar o ataque
    private void Attack()
    {
        isAttacking = true;
        // Adicione a logica de ataque aqui
        lastAttackTime = Time.time;
    }
}
