
using UnityEngine;
using TMPro;

public class ControlJuego : MonoBehaviour
{
    public TextMeshProUGUI textoItems;
    public GameObject panelVictoria;

    public int totalItems = 5;
    private int itemsRecolectados = 0;

    void Start()
    {
        ActualizarTexto();
        panelVictoria.SetActive(false);
    }

    public void RecolectarItem()
    {
        itemsRecolectados++;
        ActualizarTexto();

        if (itemsRecolectados >= totalItems)
        {
            panelVictoria.SetActive(true);
        }
    }

    void ActualizarTexto()
    {
        textoItems.text = "Items: " + itemsRecolectados + " / " + totalItems;
    }
}
