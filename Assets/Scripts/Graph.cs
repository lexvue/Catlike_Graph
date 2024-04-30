using UnityEngine;

// MonoBehavior extends Behavior, which extends Component, which extends Object. That is
// why we can use the Instatiate method in Graph as Instantiate comes from Object.
public class Graph : MonoBehaviour {

    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    Transform[] points;

    void Awake() {

        //The Vector3 struct has three floating-point fields: x, y, and z. These fields are public, so we can change them.
        float step = 2f / resolution;
        Vector3 position = Vector3.zero; //Assigning all x, y, z of position to 0 so as to not err as an unassigned var
        var scale = Vector3.one * step;
        points = new Transform[resolution];
        
        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i] = Instantiate(pointPrefab); //creates a clone of pointPrefab into scen
            //point.localPosition = Vector3.right * ((i + 0.5f) / 5f - 1f); //transforms the new clone by 1 * i on the X axis
            position.x = ((i + 0.5f) * step - 1f); // we no longer have to multiply by Vector3.right
            //position.y = position.x * position.x * position.x; //setting Y in Update
            point.localPosition = position;
            pointPrefab.localScale = scale; //reducing the scale of clones to prevent overlap
            point.SetParent(transform, false); //So all the cloned Points don't clutter the hierarchy
        }

    }

    void Update() {
        float time = Time.time;
        for (int i=0; i < points.Length; i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = position.x * position.x * position.x;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time)); //Scaling the sine of X by pi to see the sine in its entirity
            point.localPosition = position; //loading position back into localposition 
        }
    }
}
