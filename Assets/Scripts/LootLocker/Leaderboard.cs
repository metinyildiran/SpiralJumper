using System.Collections;
using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private const int LEADERBOARD_ID = 5265;

    private UIManager uiManager;

    [SerializeField] private TMP_InputField nicknameField;

    [SerializeField] private TextMeshProUGUI playerNames;
    [SerializeField] private TextMeshProUGUI playerScores;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        GameManager.Instance.OnGameFailed += () => { StartCoroutine(SubmitScoreRoutine()); };

        StartCoroutine(FetchScoreRoutine());
    }

    public IEnumerator FetchScoreRoutine()
    {
        yield return new WaitUntil(() => Authenticator.Instance.IsLoggedIn == true);

        bool isDone = false;
        LootLockerSDKManager.GetScoreList(LEADERBOARD_ID, 10, 0, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("FetchScore Successful");

                playerNames.text = "";
                playerScores.text = "";

                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }

                isDone = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("FetchScore Failed: " + response.Error);

                isDone = true;
            }
        });

        yield return new WaitWhile(() => isDone == false);
    }

    private IEnumerator SubmitScoreRoutine()
    {
        bool isDone = false;
        LootLockerSDKManager.SubmitScore(PlayerPrefs.GetString("PlayerID"), GameManager.Instance.Score, LEADERBOARD_ID, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("SubmitScore Successful");

                isDone = true;
            }
            else
            {
                Debug.Log("SubmitScore Failed: " + response.Error);

                isDone = true;
            }
        });

        yield return new WaitWhile(() => isDone == false);
    }

    public void SetPlayerName()
    {
        StartCoroutine(SetPlayerNameRoutine());

        StartCoroutine(FetchScoreRoutine());
    }

    private IEnumerator SetPlayerNameRoutine()
    {
        yield return new WaitUntil(() => Authenticator.Instance.IsLoggedIn == true);

        bool isDone = false;

        if (nicknameField.text.Equals(""))
        {
            uiManager.ShowMessage("Name cannot be empty!");

            isDone = true;
        }
        else
        {
            LootLockerSDKManager.SetPlayerName(nicknameField.text, (response) =>
            {
                if (response.success)
                {
                    Debug.Log("SetPlayerName Successfull");

                    uiManager.ShowMessage("Successfully set!");

                    nicknameField.text = "";

                    isDone = true;
                }
                else
                {
                    Debug.Log("SetPlayerName Failed: " + response.Error);

                    uiManager.ShowMessage("Failed!");

                    isDone = true;
                }
            });
        }

        yield return new WaitWhile(() => isDone == false);
    }
}
