using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    public static GameManager controladorAplicacion;

    public GameState estadoJuego;

    public static event System.Action<GameState> EnEstadoJuegoCambiado;


    private void Awake()
    {
        controladorAplicacion = this;
    }

    private void Start()
    {
        CambiarEstadoJuego(GameState.BuscarObjetos);
    }

    public void CambiarEstadoJuego(GameState nuevoEstado)
    {
        estadoJuego = nuevoEstado;

        switch (nuevoEstado)
        {
            case GameState.BuscarObjetos:
                break;
            case GameState.PrepararSistema:
                break;
            case GameState.ColocarCompresor:
                break;
            case GameState.PalparVena:
                break;
            case GameState.AplicarAntiseptico:
                break;
            case GameState.PonerseGuantes:
                break;
            case GameState.DesenfundarCateter:
                break;
            case GameState.FijarPiel:
                break;
            case GameState.InsertarCateter:
                break;
            case GameState.ExtraerAguja:
                break;
            case GameState.RetirarCompresor:
                break;
            case GameState.AbrirLlave:
                break;
            case GameState.LimpiarZona:
                break;
            case GameState.ColocarAposito:
                break;
            case GameState.FijarSistema:
                break;
            case GameState.DesecharAguja:
                break;
            case GameState.RecogerMaterial:
                break;
            case GameState.RetirarGuantes:
                break;
        }

        EnEstadoJuegoCambiado?.Invoke(nuevoEstado); //Con esto podemos hacer que algunos scripts se suscriban
                                                    //a este cambio, y llama a sus funciones correspondientes
                                                    //cada vez que el estado del juego cambia.

        //La estructura para suscribir una función a este cambio es --> GameManager.EnEstadoJuegoCambiado += NombreNuevaFuncion
        //(Dentro del script donde se encuentra dicha función);
    }
}

public enum GameState
{
    BuscarObjetos,
    PrepararSistema,
    ColocarCompresor,
    PalparVena,
    AplicarAntiseptico,
    PonerseGuantes,
    DesenfundarCateter,
    FijarPiel,
    InsertarCateter,
    ExtraerAguja,
    RetirarCompresor,
    AbrirLlave,
    LimpiarZona,
    ColocarAposito,
    FijarSistema,
    DesecharAguja,
    RecogerMaterial,
    RetirarGuantes
}