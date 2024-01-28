using UnityEngine;

public class Jellyfier : MonoBehaviour
{
    public float pressureForce;
    public float pressureOffset;

	//A value that describes how fast our jelly object will be bouncing
    public float bounceSpeed;
    public float fallForce;

    //We need this value to eventually stop bouncing back and forth.
    public float stiffness;

    private MeshFilter meshFilter;
    private Mesh mesh;
    
    Vector3[] initialVertices;
    Vector3[] currentVertices;

    Vector3[] vertexVelocities;
    
    private Ray mouseRay;
    private RaycastHit raycastHit;
    
    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;

        initialVertices = mesh.vertices;

        currentVertices = new Vector3[initialVertices.Length];
        vertexVelocities = new Vector3[initialVertices.Length];
        for (int i = 0; i < initialVertices.Length; i++)
        {
            currentVertices[i] = initialVertices[i];
        }
    }

	private void Update()
	{
        if(Input.GetMouseButton(0))
        { 
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            //We need to check if we are clicking on a mesh we can deform
            if(Physics.Raycast(mouseRay, out raycastHit))
            {
                Jellyfier jellyfier = raycastHit.collider.GetComponent<Jellyfier>();
                if(jellyfier != null)
                {
                    Vector3 inputPoint = raycastHit.point + (raycastHit.normal * pressureOffset);
                    jellyfier.ApplyPressureToPoint(inputPoint, pressureForce);
                }
            }
			
        }
        UpdateVertices();
    }

	private void UpdateVertices()
	{
		//We are looping through every vertice  update them depending on their velocity.
        for (int i = 0; i < currentVertices.Length; i++)
		{
            //Before we add the current velocity to the vertice we need to make sure that
            //we consider the fact that our object is a jelly and should be able to bounce back 
            //to do so we first calculate the displacement value. 
            Vector3 currentDisplacement = currentVertices[i] - initialVertices[i];
            vertexVelocities[i] -= currentDisplacement * bounceSpeed * Time.deltaTime;

            //In order for us to be able to stop bouncing at one point we need to reduce the velocity over time. 
            vertexVelocities[i] *= 1f - stiffness * Time.deltaTime;
            currentVertices[i] += vertexVelocities[i] * Time.deltaTime;

        }

        mesh.vertices = currentVertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

    }

    public void OnCollisionEnter(Collision other)
    {
        ContactPoint[] collisonPoints = other.contacts;
        for (int i = 0; i < collisonPoints.Length; i++)
        {
            Vector3 inputPoint = collisonPoints[i].point + (collisonPoints[i].point * .1f);
            ApplyPressureToPoint(inputPoint, fallForce);
        }
    }

    public void ApplyPressureToPoint(Vector3 _point, float _pressure)
    {
        //We need to loop through every single vertice and apply the pressure to it.
        for (int i = 0; i < currentVertices.Length; i++)
        {
            ApplyPressureToVertex(i, _point, _pressure);
        }
    }

    public void ApplyPressureToVertex(int _index, Vector3 _position, float _pressure)
    {
        //In order to know how much pressure we need to apply to each vertice we need to 
        //calculate the distance between our vertice and the point where our extended finger (mouse thingey) 
        //touched our mesh
        Vector3 distanceVerticePoint = currentVertices[_index] - transform.InverseTransformPoint(_position);

        //now begins fun physiquee part.... we need to make use of the Inverse Square Law
        //we do this by dividing the pressure by the distance squared into an adapted pressure
        //TODO: CHANGE
        float adaptedPressure = _pressure / (1f + distanceVerticePoint.sqrMagnitude);

        float velocity = adaptedPressure * Time.deltaTime;
        //Our velocity now still needs a direction, we can calculate this using the
        //normalized distance vertex point from earlier
        vertexVelocities[_index] += distanceVerticePoint.normalized * velocity;
    }
}
