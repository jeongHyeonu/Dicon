using Fusion;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    public Joystick joyStick;
    public Button btn;

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            NetworkObject runner = Runner.Spawn(PlayerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
            runner.GetComponent<PlayerController>().sJoystick = joyStick;
            btn.onClick.AddListener(() => runner.GetComponent<PlayerController>().PlayerAttack());
        }
    }
}