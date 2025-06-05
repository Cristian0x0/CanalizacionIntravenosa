using UnityEngine;

public class ObjetosEnCarritoDetector : MonoBehaviour
{
    private int cantidadAlcohol = 0, cantidadCanula = 0, cantidadLlaves = 0, cantidadAposito = 0, cantidadTorniquete = 0, cantidadSuero = 0;
    private bool ScriptActivo = false;

    private void Start()
    {
        GameManager.EnEstadoJuegoCambiado += ComprobarActivacion;
    }

    private void OnDestroy()
    {
        GameManager.EnEstadoJuegoCambiado -= ComprobarActivacion;
    }

    private void ComprobarActivacion(GameState state)
    {
        ScriptActivo = state == GameState.BuscarObjetos;
    }

    private void Update()
    {
        if (!ScriptActivo) return;
        if (cantidadAlcohol != 0 && cantidadCanula != 0 && cantidadLlaves != 0 && cantidadAposito != 0 && cantidadTorniquete!= 0 && cantidadSuero!= 0)
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
        else if (other.CompareTag("Torniquete"))
        {
            cantidadTorniquete++;
            Debug.Log("entra" + other.name);
        }
        else if (other.CompareTag("Suero"))
        {
            cantidadSuero++;
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
        else if (other.CompareTag("Torniquete"))
        {
            cantidadTorniquete--;
        }
        else if (other.CompareTag("Suero"))
        {
            cantidadSuero--;
        }
    }
}
