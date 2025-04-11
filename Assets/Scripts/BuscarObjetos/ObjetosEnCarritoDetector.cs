using UnityEngine;

public class ObjetosEnCarritoDetector : MonoBehaviour
{
    private int cantidadAlcohol, cantidadCanula, cantidadLlaves, cantidadAposito = 0;

    private void Update()
    {
        if (cantidadAlcohol == 1 && cantidadCanula == 1 && cantidadLlaves == 1 && cantidadAposito == 1)
        {
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.PrepararSistema);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Alcohol"))
        {
            cantidadAlcohol++;
        }
        else if (other.CompareTag("Aposito"))
        {
            cantidadAposito++;
        }
        else if (other.CompareTag("Canula"))
        {
            cantidadCanula++;
        }
        else if (other.CompareTag("Llave3Pasos"))
        {
            cantidadLlaves++;
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
