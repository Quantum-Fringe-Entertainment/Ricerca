using UnityEngine;

public class Seagull : MonoBehaviour
{

    public float flyawayRange = 5f;
    public float flyawayTime = 0.1f;
    public float detectionRange = 1.5f;
    public Transform testFlyPos;
    public Vector3 targetSPhereOffset = new Vector3(0,5,0);

    private Animator _seagullAC;
    private float t = 0;
    private bool didFly;
    private Vector3 _flyPos;
    private bool posChoosen;

    // Start is called before the first frame update
    void Start()
    {
        _seagullAC = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.SphereCast(transform.position, detectionRange, Vector3.forward * -1,out RaycastHit hitInfo))
        {
            if (hitInfo.collider.tag == Characters.Player && !didFly)
            {
                Debug.DrawLine(transform.position, hitInfo.point, color: Color.cyan);
                _seagullAC.SetBool(AnimalAC_Parameters.isFlying,true);
                didFly = true;
                posChoosen = true;
                _flyPos = transform.position + targetSPhereOffset;
                _flyPos += Random.insideUnitSphere.normalized * flyawayRange;
            }
        }

        if(didFly)
            FlyAway(_flyPos);

    }

    private void FlyAway(Vector3 flyPos)
    {

        print("The target flying positoin is :" + flyPos);
        //if (flyPos.y < -17.5 && posChoosen)
        //{
        //    //Do some correction here
        //    flyPos.y = Random.Range(-8, -14);
        //    posChoosen = false;
        //    print("The target flying positoin after correction :" + flyPos);
        //}
        transform.LookAt(flyPos);
            transform.position = Vector3.Lerp(transform.position, flyPos, flyawayTime * t);
            t += Time.deltaTime;

        if(t > 1)
        {
            print("Reached");
            t = 0f;
            _flyPos = transform.position;
            _flyPos += Random.insideUnitSphere.normalized * flyawayRange;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.DrawWireSphere(transform.position + targetSPhereOffset, flyawayRange);
    }
}


