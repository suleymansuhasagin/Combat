using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sword : MonoBehaviour
{
   private PlayerControls playerControls;
   private Animator anim;
   private PlayerController playerController;
   private ActiveWeapons activeWeapons;
   private void Awake() 
   {
        playerController = GetComponentInParent<PlayerController>();
        activeWeapons = GetComponentInParent<ActiveWeapons>();
        anim = GetComponent<Animator>();
        playerControls = new PlayerControls();
   }

   private void OnEnable() 
   {
        playerControls.Enable();
   }
   private void Start() 
   {
        playerControls.Combat.Attack.started += _ => Attack();
   }

   private void Update() 
   {
      MouseFollowWithOffset();  
   }
   private void MouseFollowWithOffset() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x) {
            activeWeapons.transform.rotation = Quaternion.Euler(0, -180, angle);
        } else {
            activeWeapons.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

   private void Attack()
   {
        anim.SetTrigger("Attack");
   }
}
