using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    public static GameManager controladorAplicacion;

    public GameState estadoJuego;
    public gameMode modoJuego;

    public static event System.Action<GameState> EnEstadoJuegoCambiado;

    public Material LEDPantallas;
    public Texture[] Instrucciones;

    public GameObject palparVena;
    public GameObject DesinfectarZona;
    public GameObject SecondCameraPlane;
    public GameObject Puncion;
    public GameObject QuitarTorniquete;
    public GameObject ConectarLlaveACateter;


    private void Awake()
    {
        controladorAplicacion = this;
    }

    private void Start()
    {
        CambiarEstadoJuego(GameState.MainMenuStep);
        modoJuego = gameMode.Normal;
        SecondCameraPlane.SetActive(true);
    }

    private void OnValidate() //Esto sirve para poder cambiar el estado desde el inspector, comentar si no es necesario.
    {
        CambiarEstadoJuego(estadoJuego);
    }

    public void CambiarEstadoJuego(GameState nuevoEstado)
    {
        estadoJuego = nuevoEstado;

        palparVena.SetActive(false);
        DesinfectarZona.SetActive(false);
        Puncion.SetActive(false);
        ConectarLlaveACateter.SetActive(false);

        switch (nuevoEstado)
        {
            case GameState.MainMenuStep:
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[17]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[17]);
                break;
            case GameState.PrimeraHigieneDeManos:
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[0]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[0]);
                break;
            case GameState.BuscarObjetos:
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[1]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[1]);
                break;
            case GameState.PrepararSistema:
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[2]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[2]);

                break;
            case GameState.ColocarCompresor:
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[3]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[3]);
                break;
            case GameState.PalparVena:
                palparVena.SetActive(true);
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[4]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[4]);
                break;
            case GameState.AplicarAntiseptico:
                DesinfectarZona.SetActive(true);
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[5]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[5]);
                break;
            case GameState.PonerseGuantes:
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[6]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[6]);
                break;
            case GameState.DesenfundarCateter:
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[7]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[7]);
                break;
            case GameState.FijarPielIntroducirAguja:
                Puncion.SetActive(true);
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[8]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[8]);
                break;
            case GameState.RetirarCompresor:
                QuitarTorniquete.SetActive(true);
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[9]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[9]);
                break;
            case GameState.ConectarEquipoInfusion:
                ConectarLlaveACateter.SetActive(true);
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[10]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[10]);

                break;
            case GameState.FijarCateter:
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[11]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[11]);
                break;
            case GameState.FijarLlave3Pasos:
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[12]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[12]);
                break;
            case GameState.DesecharAguja:
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[13]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[13]);
                break;
            case GameState.RecogerMaterial:
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[14]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[14]);
                break;
            case GameState.RetirarGuantes:
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[15]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[15]);
                break;
            case GameState.SegundaHigieneDeManos:
                if (modoJuego != gameMode.Normal) break;
                LEDPantallas.SetTexture("_BaseMap", Instrucciones[16]);
                LEDPantallas.SetTexture("_EmissionMap", Instrucciones[16]);
                break;
        }

        EnEstadoJuegoCambiado?.Invoke(nuevoEstado); //Con esto podemos hacer que algunos scripts se suscriban
                                                    //a este cambio, y llama a sus funciones correspondientes
                                                    //cada vez que el estado del juego cambia. Le dice a todos los suscriptores, Eh, he cambiado.

        //La estructura para suscribir una función a este cambio es --> GameManager.EnEstadoJuegoCambiado += NombreNuevaFuncion
        //(Dentro del script donde se encuentra dicha función);
    }
}

public enum GameState
{
    MainMenuStep,
    PrimeraHigieneDeManos,
    BuscarObjetos,
    PrepararSistema,
    ColocarCompresor,
    PalparVena,
    AplicarAntiseptico,
    PonerseGuantes,
    DesenfundarCateter,
    FijarPielIntroducirAguja,
    RetirarCompresor,
    ConectarEquipoInfusion,
    FijarCateter,
    FijarLlave3Pasos,
    DesecharAguja,
    RecogerMaterial,
    RetirarGuantes,
    SegundaHigieneDeManos
}

public enum gameMode
{
    Normal,
    Advanced,
    Expert
}