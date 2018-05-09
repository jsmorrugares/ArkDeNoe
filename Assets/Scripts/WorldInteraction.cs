﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour 
{
	
	NavMeshAgent playerAgent;
	void Start()
	{
		playerAgent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ())
			GetInteraction ();

		Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
	}
	
	void GetInteraction()
	{
		Ray interactionRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit interactionInfo;
		if(Physics.Raycast(interactionRay, out interactionInfo , Mathf.Infinity))
		{
			GameObject interactedObject = interactionInfo.collider.gameObject;
			if (interactedObject.tag == "Enemy")
			{
				Debug.Log("move to enemy");
				interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
			} 

			if (interactedObject.tag == "Interactable Object")
			{
				//Debug.Log ("Interactable interacted.");
				interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
			}
			else
			{
				playerAgent.stoppingDistance = 0;
				playerAgent.destination = interactionInfo.point;
			}
		}
				
	}


}
