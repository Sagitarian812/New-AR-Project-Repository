using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TowerBuild : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject turret;
    public Bullet bulletDamage;
    public GameObject buildTurretButton;
    public GameObject upgradeButton;
   

    void Start()
    {
        turret.GetComponent<Turret>();
        buildTurretButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        upgradeButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if(buildTurretButton)
        {
            turret.SetActive(true);
            Debug.Log("Turret built");
        }
     
        if (upgradeButton)
        {
            turret.GetComponent<Turret>().fireRate++;
                turret.GetComponent<Turret>().range++;
                turret.GetComponent<Turret>().turretDamage += 10;
            Debug.Log(turret.GetComponent<Turret>().turretDamage);
        }

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (buildTurretButton)
        {
            buildTurretButton.SetActive(false);
            upgradeButton.SetActive(true);
        }

    }
}
