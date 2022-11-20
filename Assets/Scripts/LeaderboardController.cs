using UnityEngine.UI;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    public InputField name;

    public void setName() {
        PlayerName.name = name.text;
        Debug.Log(PlayerName.name);
    }
}
