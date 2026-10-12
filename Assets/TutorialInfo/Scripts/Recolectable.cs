
using UnityEngine;

public class Recolectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            ControlJuego control = FindFirstObjectByType<ControlJuego>();

            if (control != null)
            {
                control.RecolectarItem();
            }

            Destroy(gameObject);
        }
    }
}
