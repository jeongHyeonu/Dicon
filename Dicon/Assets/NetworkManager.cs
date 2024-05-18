using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour
{
    public NetworkRunner networkRunnerPrefab;
    NetworkRunner runner;

    // Start is called before the first frame update
    void Start()
    {
        runner = Instantiate(networkRunnerPrefab);
        runner.name = "networkRunnerPlayer";
        //var clientTask = InitializeNetworkRunner(runner, GameMode.AutoHostOrClient, NetAddress.Any(), null);
    }

    protected virtual Task InitializeNetworkRunner(NetworkRunner _runner, GameMode _gm, NetAddress _address, Action<NetworkRunner> _init)
    {
        var sceneManager = _runner.GetComponents(typeof(MonoBehaviour)).OfType<INetworkSceneManager>().FirstOrDefault();

        if (sceneManager == null) {
            sceneManager = _runner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        }
        runner.ProvideInput = true;

        return runner.StartGame(new StartGameArgs
        {
            GameMode = _gm,
            Address = _address,
            //Scene = _scene,
            SessionName = "Test",
            SceneManager = sceneManager,
        });
    }
}
