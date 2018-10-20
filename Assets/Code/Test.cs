using UnityEngine;
using UnityEngine.AI;


namespace Code
{
    public class Test : MonoBehaviour
    {

        [SerializeField] private Transform _destination;

        private NavMeshAgent _navMeshAgent;

        // Use this for initialization
        void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();

            if (_navMeshAgent == null)
            {
                Debug.Log("The nav mash agent component is not attached to " + gameObject.name);
            }
            else
            {
                SetDestination();
            }
        }

        private void SetDestination()
        {
            if (_destination != null)
            {
                Vector3 targetVector = _destination.transform.position;
                _navMeshAgent.SetDestination(targetVector);
            }
        }
    }
}