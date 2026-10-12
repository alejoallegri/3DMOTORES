
using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    public Transform jugador;
    public Vector3 distancia = new Vector3(0f, 8f, -10f);

    void LateUpdate()
    {
        if (jugador == null) return;

        transform.position = jugador.position + distancia;
        transform.LookAt(jugador);
    }
}

