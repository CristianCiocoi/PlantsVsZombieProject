using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    
    [SerializeField] GameObject projectile, gun;
    //[SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner; //because we access a few time we use a global parameter
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();//because our shooter script is on the same level as the gameobject 
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }

    }
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);///if we not in the same lane thats gonna resolve into a number bigger than math epsilon and if we are in the same lane thats   gonna be 0 which is gonna be less than mathf epsilon
            //'spawner.transform.position.y' spawners position - 'transform.position.y' defenders position, that should equal to 0 if it is 0 then its true. math.epsilon just to make sure that things dont get exactly 0. that says that is it smaller than the smallest number math.epsilon
            //abs value so whether its + or minus it will turn into a plus 
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }



    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {

        GameObject newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform; //the same as defenders
    }
    
}
