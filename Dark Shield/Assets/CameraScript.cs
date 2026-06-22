using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaDeCamera : MonoBehaviour
{
    public Camera[] cameras; // Coloque aqui todas as câmeras que você deseja alternar.
    private int cameraAtual = 0;
    private bool Fogueira = false; // Variável para verificar se o jogador está perto da fogueira

    void Start()
    {
        // Desativa todas as câmeras, exceto a primeira na lista.
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
    }

    // Função chamada quando o jogador entra na área de detecção da casa
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entrou na área da Fogueira");
            Fogueira = true;
        }
    }

    // Função chamada quando o jogador sai da área de detecção da casa
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Saiu da área da Fogueira");
            Fogueira = false;
            if (Fogueira == false)
            {
                cameras[1].gameObject.SetActive(false);
                cameras[0].gameObject.SetActive(true);

                Debug.Log("teste");
            }
        }
    }

    void Update()
    {
        // Verifica se a tecla "E" foi pressionada.
        if (Fogueira && Input.GetKeyDown(KeyCode.E))
        {
            // Desativa a câmera atual.
            cameras[cameraAtual].gameObject.SetActive(false);

            // Avança para a próxima câmera.
            cameraAtual = (cameraAtual + 1) % cameras.Length;

            // Ativa a próxima câmera.
            cameras[cameraAtual].gameObject.SetActive(true);
        }
    }
}
