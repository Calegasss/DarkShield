using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorsController : MonoBehaviour
{
    public string Menu; // Nome da cena que você deseja carregar
    private bool isNearHouse = false; // Variável para verificar se o jogador está perto da casa


    // Função chamada quando o jogador entra na área de detecção da casa
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entrou na área da casa");
            isNearHouse = true;
        }
    }

    // Função chamada quando o jogador sai da área de detecção da casa
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Saiu da área da casa");
            isNearHouse = false;
        }
    }

    // Função chamada a cada frame
    void Update()
    {
        if (isNearHouse && Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Trocar de cena");
            SceneManager.LoadScene(Menu);
        }
    }
}
