using UnityEngine;
using UnityEngine.Tilemaps;

public class LivrosController : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject objectToActivate;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(mousePosition);

            if (tilemap.HasTile(cellPosition))
            {
                // Ative o objeto desejado quando um bloco for clicado
                objectToActivate.SetActive(true);
            }
        }

        // Use Input.GetKeyDown para verificar a tecla "esc" e desativar o objeto
        if (objectToActivate.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            objectToActivate.SetActive(false);
        }
    }
}
