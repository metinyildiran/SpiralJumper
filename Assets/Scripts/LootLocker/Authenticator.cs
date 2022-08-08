using System.Collections;
using LootLocker.Requests;
using UnityEngine;

public class Authenticator : MonoBehaviour
{
    public static Authenticator Instance { get; private set; }

    public bool IsLoggedIn { get; private set; }

    private void Awake()
    {
        Instance = this;

        StartCoroutine(LoginRoutine());
    }

    private IEnumerator LoginRoutine()
    {
        IsLoggedIn = false;

        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("successfully started LootLocker session");

                PlayerPrefs.SetString("PlayerID", response.player_id.ToString().Print("Player ID"));

                IsLoggedIn = true;
            }
            else
            {
                Debug.Log("error starting LootLocker session");

                IsLoggedIn = true;
            }
        });

        yield return new WaitWhile(() => IsLoggedIn == false);
    }
}
