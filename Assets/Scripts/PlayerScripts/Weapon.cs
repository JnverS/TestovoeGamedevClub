using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Joystick joystick;
    public Transform WeaponPosinion;
    public GameObject bullet;

    [SerializeField] private TMP_Text bulletText;
    [SerializeField] private float speed;
    [SerializeField] private float offset;

    private float dirX;
    private float dirY;
    private int bulletCount, maxBulletInMagazine = 30;
    private float timer = 1f;
    private void Awake()
    {
        bulletCount = maxBulletInMagazine;
    }
    void Update()
    {
        dirX = joystick.Horizontal * speed;
        dirY = joystick.Vertical * speed;
        bulletText.text = bulletCount.ToString() + "/" + maxBulletInMagazine.ToString();
    }

    void FixedUpdate()
    {
        if (dirX != 0 && dirY != 0)
        {
            float rotatez = Mathf.Atan2(dirY, dirX) * Mathf.Rad2Deg;
            if ((rotatez < 30 && rotatez > -50) ) 
            {
                transform.eulerAngles = new Vector3(0, 0, rotatez);
            }
            else if ((rotatez > 135 && rotatez < 180) || (rotatez < -135 && rotatez > -180))
            {
                transform.localRotation = Quaternion.Euler(0, 0, 180 - rotatez);
            }
        }
    }
    public void Shooting()
    {
        if (bulletCount > 0)
        {
            Instantiate(bullet, WeaponPosinion.position, transform.rotation);
            bulletCount--;
            bulletText.text = bulletCount.ToString() + "/" + maxBulletInMagazine.ToString();
        }
        if (bulletCount == 0)
            StartCoroutine(Ñooldown());

    }
    IEnumerator Ñooldown()
    {
        yield return new WaitForSeconds(timer);
        bulletCount = maxBulletInMagazine;
    }

}
