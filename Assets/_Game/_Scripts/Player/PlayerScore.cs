using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;



public class PlayerScore : MonoBehaviour
{
    
public NetworkVariable<int> Score = new NetworkVariable<int>(10);
public TMPro.TMP_Text txtScoreDisplay;   

    public void OnNetworkSpawn() {
        Score.OnValueChanged += ClientOnScoreChanged;
        DisplayScore();
    }

    private void ClientOnScoreChanged(int previous, int current) {
        DisplayScore();
    }

    public void OnCollisionEnter(Collision collision) {
            Score.Value -= 1;
            
    }

    [ServerRpc]
    private void RequestSetScoreServerRpc(int value) {
        Score.Value = value;
    }

    public void DisplayScore() {
        txtScoreDisplay.text = Score.Value.ToString();
    }
}
