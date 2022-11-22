using UnityEngine.UI;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    public InputField name;

    public void setName() {
        PlayerPrefs.SetString("name", name.text);
    }
}
