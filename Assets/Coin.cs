using Fusion;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : NetworkBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>())
        {
            if (HasStateAuthority)
            {
                Runner.Despawn(GetComponent<NetworkObject>());
            }
        }
    }
}
