using UnityEngine;

public class BuildingHight : MonoBehaviour
{

    public float CurrentHight()
    {
        bool foundHight = false;

        while (!foundHight)
        {
            if(Physics.CheckBox(transform.position, new Vector3(15, 1, 15)))
            {
                transform.position += Vector3.up;
            }
            else
            {
                foundHight = true;
            }
        }

        return transform.position.y;
    }

}
