using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabel : MonoBehaviour
{
   
   [SerializeField] Color defaultColor = Color.white;
   [SerializeField] Color blockedColor = Color.gray;
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WayPoint waypoint;
   public bool isPlaceable;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
       
        waypoint = GetComponentInParent<WayPoint>();
        DisplayCoordinates();
    }
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }
        SetLabelColor();
        ToggleLabel();
        {

    }

        void ToggleLabel()
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                label.enabled = !label.IsActive();
            }
        }
        void SetLabelColor()
        { 
          if(isPlaceable)
          {
            label.color = defaultColor;
          }  
          else
          {
            label.color = blockedColor;
          }
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
