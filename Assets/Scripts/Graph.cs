using UnityEngine;

// MonoBehavior extends Behavior, which extends Component, which extends Object. That is
// why we can use the Instatiate method in Graph as Instantiate comes from Object.
public class Graph : MonoBehaviour {

    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    void Awake() {

        //The Vector3 struct has three floating-point fields: x, y, and z. These fields are public, so we can change them.
        float step = 2f / resolution;
        Vector3 position = Vector3.zero; //Assigning all x, y, z of position to 0 so as to not err as an unassigned var
        var scale = Vector3.one * step;
        for (int i = 0; i < resolution; i++) {
            Transform point = Instantiate(pointPrefab); //creates a clone of pointPrefab into scen
            //point.localPosition = Vector3.right * ((i + 0.5f) / 5f - 1f); //transforms the new clone by 1 * i on the X axis
            position.x = ((i + 0.5f) * step - 1f); // we no longer have to multiply by Vector3.right
            position.y = position.x * position.x;
            point.localPosition = position;
            pointPrefab.localScale = scale; //reducing the scale of clones to prevent overlap
            point.SetParent(transform, false); //So all the cloned Points don't clutter the hierarchy
        }

    }
}
