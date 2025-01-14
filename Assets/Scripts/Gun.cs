﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool boolIsFiring;

    public Bullet bullet;
    public float flBulletSpeed;

    public float flTimeBetweenShots;
    private float flShotCounter;

    public Transform trFirePoint;

    public int intGunType = 1;

    int intWaveShotTicker = 0;
    bool boolWaveShotDir = true;

    int intWaveShotTicker_DoubleLeft = 0;
    bool boolWaveShotDir_DoubleLeft = true;
    int intWaveShotTicker_DoubleRight = 0;
    bool boolWaveShotDir_DoubleRight = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            intGunType++;
            if (intGunType > 4) intGunType = 1;
            Debug.Log("Current Gun: " + intGunType);
        }



        if (intGunType == 1)
        {
            BasicShot();
        }
        if (intGunType == 2)
        {
            WideShot();
        }
        if (intGunType == 3)
        {
            WaveShot();
        }
        if (intGunType == 4)
        {
            FiveProngShot();
        }
    }

    void BasicShot()
    {
        if (boolIsFiring)
        {
            flShotCounter -= Time.deltaTime;
            if (flShotCounter <= 0)
            {
                flShotCounter = flTimeBetweenShots;
                Bullet newBullet = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation) as Bullet;
                newBullet.flSpeed = flBulletSpeed;
            }
        }

        else
        {
            flShotCounter = 0;
        }
    }

    void WideShot()
    {
        Vector3 v3FirePointLoc1 = new Vector3(trFirePoint.position.x - 0.5f, trFirePoint.position.y, trFirePoint.position.z);
        Vector3 v3FirePointLoc2 = new Vector3(trFirePoint.position.x, trFirePoint.position.y, trFirePoint.position.z);
        Vector3 v3FirePointLoc3 = new Vector3(trFirePoint.position.x + 0.5f, trFirePoint.position.y, trFirePoint.position.z);



        if (boolIsFiring)
        {
            flShotCounter -= Time.deltaTime;
            if (flShotCounter <= 0)
            {
                flShotCounter = flTimeBetweenShots;
                Bullet newBullet1 = Instantiate(bullet, v3FirePointLoc1, trFirePoint.rotation) as Bullet;
                Bullet newBullet2 = Instantiate(bullet, v3FirePointLoc2, trFirePoint.rotation) as Bullet;
                Bullet newBullet3 = Instantiate(bullet, v3FirePointLoc3, trFirePoint.rotation) as Bullet;
                newBullet1.flSpeed = flBulletSpeed;
                newBullet2.flSpeed = flBulletSpeed;
                newBullet3.flSpeed = flBulletSpeed;
            }
        }

        else
        {
            flShotCounter = 0;
        }
    }

    void WaveShot()
    {
        float[] a_flWaveLocs = {
            trFirePoint.position.x - 1f,
            trFirePoint.position.x - 0.5f,
            trFirePoint.position.x,
            trFirePoint.position.x + 0.5f,
            trFirePoint.position.x + 1f 
        };
        Vector3 v3FirePointWaveLoc;
        

        if (boolIsFiring)
        {
            flShotCounter -= Time.deltaTime;
            if (flShotCounter <= 0)
            {
                flShotCounter = flTimeBetweenShots;

                if (intWaveShotTicker > 3)
                {
                    boolWaveShotDir = false;
                }
                    
                if (intWaveShotTicker < 1)
                {
                    boolWaveShotDir = true;
                }

                if (!boolWaveShotDir) intWaveShotTicker--;

                if (boolWaveShotDir) intWaveShotTicker++;

                Debug.Log(intWaveShotTicker);
                v3FirePointWaveLoc = new Vector3(a_flWaveLocs[intWaveShotTicker], trFirePoint.position.y, trFirePoint.position.z);
                Bullet newBullet = Instantiate(bullet, v3FirePointWaveLoc, trFirePoint.rotation) as Bullet;
                newBullet.flSpeed = flBulletSpeed;
            }
        }

        else
        {
            flShotCounter = 0;
        }
    }

    void ThreeProngShot()
    {
        if (boolIsFiring)
        {
            flShotCounter -= Time.deltaTime;
            if (flShotCounter <= 0)
            {
                Quaternion leftFirePoint = Quaternion.Euler(0, -30, 0);
                Quaternion rightFirePoint = Quaternion.Euler(0, 30, 0);

                flShotCounter = flTimeBetweenShots;
                Bullet newBullet1 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation * leftFirePoint) as Bullet;
                Bullet newBullet2 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation) as Bullet;
                Bullet newBullet3 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation * rightFirePoint) as Bullet;
                newBullet1.flSpeed = flBulletSpeed;
                newBullet2.flSpeed = flBulletSpeed;
                newBullet3.flSpeed = flBulletSpeed;
            }
        }

        else
        {
            flShotCounter = 0;
        }
    }

    void FiveProngShot()
    {
        if (boolIsFiring)
        {
            flShotCounter -= Time.deltaTime;
            if (flShotCounter <= 0)
            {
                Quaternion leftFirePoint = Quaternion.Euler(0, -25, 0);
                Quaternion rightFirePoint = Quaternion.Euler(0, 25, 0);
                Quaternion leftFirePoint2 = Quaternion.Euler(0, -50, 0);
                Quaternion rightFirePoint2 = Quaternion.Euler(0, 50, 0);

                flShotCounter = flTimeBetweenShots;
                Bullet newBullet1 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation * leftFirePoint) as Bullet;
                Bullet newBullet2 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation) as Bullet;
                Bullet newBullet3 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation * rightFirePoint) as Bullet;
                Bullet newBullet4 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation * leftFirePoint2) as Bullet;
                Bullet newBullet5 = Instantiate(bullet, trFirePoint.position, trFirePoint.rotation * rightFirePoint2) as Bullet;
                newBullet1.flSpeed = flBulletSpeed;
                newBullet2.flSpeed = flBulletSpeed;
                newBullet3.flSpeed = flBulletSpeed;
                newBullet4.flSpeed = flBulletSpeed;
                newBullet5.flSpeed = flBulletSpeed;
            }
        }

        else
        {
            flShotCounter = 0;
        }
    }
}
