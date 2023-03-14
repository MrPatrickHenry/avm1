using UnityEngine;
using System.Collections;

public class NewMonoBehaviour : MonoBehaviour
{


    public static int Score;
    [SerializeField]
    private TextMeshProUGUI ScoreText;

    public float timeRemaining = 10;
    public GameObject Puck;
    private int PlayerHelathUpdate;
    public static int AlexHealth = 100;
    public static string damgeUpdate;
    public GameObject spawnPoint;
    public int glooperDamage = 5;
    public GameObject RoboDog;

}
