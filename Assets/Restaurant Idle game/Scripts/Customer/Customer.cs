using UnityEngine;

public class Customer : MonoBehaviour
{
    enum State
    {
        Idle = 0,
        Walking = 1,
        Drinking = 2,
    }


    private State state;

    [Header(" Components ")]
    [SerializeField] private CustomerAnimator animator;
    [SerializeField] private NavigationAbility navigationAbility;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleStateMachine();
    }

    private void HandleStateMachine()
    {
        switch (state)
        {
            case State.Idle:
                HandleIdleState();
                break;

            case State.Walking:
                HandleWalkingState();
                break;

        }
    }


    private void HandleIdleState()
    {
        if (navigationAbility.IsMoving())
            StartWalkingState();
    }

    private void HandleWalkingState()
    {
        if (navigationAbility.HasReachedDestination())
        {
            ReachDestination();
            return;
        }

        if (navigationAbility.IsMoving())
            animator.ManageAnimations(navigationAbility.Velocity);
        else
            StartIdleState();
    }

    private void ReachDestination()
    {
        StartIdleState();
    }

    public void Initialize(Vector3 targetPosition)
    {
        GoTo(targetPosition);
    }

    public void GoTo(Vector3 targetPosition)
    {
        bool canReachDestination = navigationAbility.TryGoTo(targetPosition);

        if (canReachDestination)
            StartWalkingState();
    }

    private void StartWalkingState()
    {
        state = State.Walking;
        animator.StartWalking();
    }

    private void StartIdleState()
    {
        state = State.Idle;
        animator.Stop();
    }

}
