using TMPro;
using UnityEngine;

public class HUDHP : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private PlayerHealth _playerHealth;

    // Update is called once per frame
    void Update()
    {
        _text.text = "Player Health:" + _playerHealth.PlayersHealth.ToString();
    }
}
