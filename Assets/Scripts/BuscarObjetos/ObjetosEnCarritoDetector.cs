using UnityEngine;

public class ObjetosEnCarritoDetector : MonoBehaviour
{
    private int cantidadAlcohol = 0, cantidadCanula = 0, cantidadLlaves = 0, cantidadAposito = 0, cantidadTorniquete = 0, cantidadSuero = 0, cantidadGasa = 0;
    private bool ScriptActivo = false;

    [SerializeField] private Transform ObjetosFueraCarrito;
    [SerializeField] private Transform ObjetosDentroCarrito;

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
        if (cantidadAlcohol != 0 && cantidadCanula != 0 && cantidadLlaves != 0 && cantidadAposito != 0 && cantidadTorniquete!= 0 && cantidadSuero!= 0 && cantidadGasa!= 0)
        {
            KeepAchievements.instance.EverythingInPlaceAchievement();
            GameManager.controladorAplicacion.stepCompleted();
            GameManager.controladorAplicacion.CambiarEstadoJuego(GameState.PrepararSistema);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Alcohol"))
        {
            cantidadAlcohol++;
            other.transform.parent.SetParent(ObjetosDentroCarrito);
        }
        else if (other.CompareTag("Aposito"))
        {
            cantidadAposito++;
            other.transform.SetParent(ObjetosDentroCarrito);
        }
        else if (other.CompareTag("Canula"))
        {
            cantidadCanula++;
            other.transform.parent.SetParent(ObjetosDentroCarrito);
        }
        else if (other.CompareTag("Llave3Pasos"))
        {
            cantidadLlaves++;
            other.transform.SetParent(ObjetosDentroCarrito);
        }
        else if (other.CompareTag("Torniquete"))
        {
            cantidadTorniquete++;
            other.transform.parent.SetParent(ObjetosDentroCarrito);
        }
        else if (other.CompareTag("Suero"))
        {
            cantidadSuero++;
            other.transform.SetParent(ObjetosDentroCarrito);
        }
        else if (other.CompareTag("Gauze"))
        {
            cantidadGasa++;
            other.transform.parent.SetParent(ObjetosDentroCarrito);
        }
        else if (other.CompareTag("SistemaSuero"))
        {
            cantidadGasa++;
            other.transform.SetParent(ObjetosDentroCarrito);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Alcohol"))
        {
            cantidadAlcohol--;
            other.transform.parent.SetParent(ObjetosFueraCarrito);
        }
        else if (other.CompareTag("Aposito"))
        {
            cantidadAposito--;
            other.transform.SetParent(ObjetosFueraCarrito);
        }
        else if (other.CompareTag("Canula"))
        {
            cantidadCanula--;
            other.transform.parent.SetParent(ObjetosFueraCarrito);
        }
        else if (other.CompareTag("Llave3Pasos"))
        {
            cantidadLlaves--;
            other.transform.SetParent(ObjetosFueraCarrito);
        }
        else if (other.CompareTag("Torniquete"))
        {
            cantidadTorniquete--;
            other.transform.parent.SetParent(ObjetosFueraCarrito);
        }
        else if (other.CompareTag("Suero"))
        {
            cantidadSuero--;
            other.transform.SetParent(ObjetosFueraCarrito);
        }
        else if (other.CompareTag("Gauze"))
        {
            cantidadGasa--;
            other.transform.parent.SetParent(ObjetosFueraCarrito);
        }
        else if (other.CompareTag("SistemaSuero"))
        {
            other.transform.SetParent(ObjetosFueraCarrito);
        }
    }
}
