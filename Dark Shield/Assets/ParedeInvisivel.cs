using UnityEngine;
using UnityEngine.SceneManagement;

public class ParedeInvisivel : MonoBehaviour
{
    public string Scena; // Nome da cena que você deseja carregar
    private bool isNearHouse = false; // Variável para verificar se o jogador está em contato com o box


    // Função chamada quando o jogador entra na área de detecção da casa
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entrou em contato");
            isNearHouse = true;
        }
    }

    // Função chamada a cada frame
    void Update()
    {
        if (isNearHouse == true)
        {
            Debug.Log("Voltar ao inicio");
            SceneManager.LoadScene(Scena);
        }
    }
}
