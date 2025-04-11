using UnityEngine;

public class ObjetosEnCarritoDetector : MonoBehaviour
{
    private int cantidadAlcohol, cantidadCanula, cantidadLlaves, cantidadAposito = 0;

    private void Update()
    {
        if (cantidadAlcohol != 0 && cantidadCanula != 0 && cantidadLlaves != 0 && cantidadAposito != 0)
        {
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.PrepararSistema);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Alcohol"))
        {
            cantidadAlcohol++;
            Debug.Log("entra" + other.name);
        }
        else if (other.CompareTag("Aposito"))
        {
            cantidadAposito++;
            Debug.Log("entra" + other.name);
        }
        else if (other.CompareTag("Canula"))
        {
            cantidadCanula++;
            Debug.Log("entra" + other.name);
        }
        else if (other.CompareTag("Llave3Pasos"))
        {
            cantidadLlaves++;
            Debug.Log("entra" + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Alcohol"))
        {
            cantidadAlcohol--;
        }
        else if (other.CompareTag("Aposito"))
        {
            cantidadAposito--;
        }
        else if (other.CompareTag("Canula"))
        {
            cantidadCanula--;
        }
        else if (other.CompareTag("Llave3Pasos"))
        {
            cantidadLlaves--;
        }
    }
}
