using UnityEngine;
using UnityEngine.AI;

namespace i5.VirtualAgents
{
    /// <summary>
    /// Component for synchronizing the agent's movement with the shown animation
    /// </summary>
    public class AgentAnimationUpdater : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Animator animator;

        // animation Parameter Names
        [SerializeField] private string forwardSpeed = "Speed";
        [SerializeField] private string angularSpeed = "Turn";

        // animation IDs
        private int _animIDSpeed;
        private int _animIDAngularSpeed;

        private void Awake()
        {
            AssignAnimationIDs();
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            animator.applyRootMotion = false;
        }

        private void AssignAnimationIDs()
        {
            _animIDSpeed = Animator.StringToHash(forwardSpeed);
            _animIDAngularSpeed = Animator.StringToHash(angularSpeed);
        }



        // Updates the animation parameters for the blend trees
        private void UpdateAnimatorParameters()
        {
            animator.SetFloat(_animIDSpeed, agent.velocity.magnitude);
        }

        private void Update()
        {
            UpdateAnimatorParameters();
        }
    }
}