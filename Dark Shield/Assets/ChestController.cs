using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject itemToActivate; // Objeto que será ativado

    private bool hasActivated = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasActivated)
        {
            ActivateItem();
            hasActivated = true;

            // Destrua o baú após ativá-lo
            Destroy(gameObject);
        }
    }

    private void ActivateItem()
    {
        if (itemToActivate != null)
        {
            // Ative o item
            itemToActivate.SetActive(true);
        }
    }
}
