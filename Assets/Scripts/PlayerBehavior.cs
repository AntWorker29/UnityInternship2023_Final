using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerBehavior : MonoBehaviour, IKitchenObjectParent
{
    #region FIELDS
    public static PlayerBehavior Instance { get; private set; }

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float playerWidth = 0.4f;
    [SerializeField] private float playerHeight = 0.6f;
    [SerializeField] private LayerMask countersLayerMask;
    [SerializeField] private KitchenObject kitchenObject;
    [SerializeField] private GameObject kitchenObjectHoldPoint;

    private Vector3 lastInteractDir;
    private float rotateSpeed = 6f;
    private bool isWalking;
    private BaseCounter selectedCounter;
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }

    public event EventHandler OnPickedSomething;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("trying to set multiple player Instances");
        }
        Instance = this;
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnInteractAlternateAction += GameInput_OnInteractAlternateAction;
    }


    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (!KitchenGameManager.Instance.IsGamePlaying()) return;
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }
    private void GameInput_OnInteractAlternateAction(object sender, System.EventArgs e)
    {
        if (!KitchenGameManager.Instance.IsGamePlaying()) return;
        if (selectedCounter != null)
        {
            selectedCounter.InteractAlternate(this);
        }
    }
    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }
    #endregion

    #region METHODS
    private void HandleInteractions()
    {
        var inputVector = gameInput.GetInputVector2Normalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }
        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                if (baseCounter != selectedCounter)
                {
                    SetSelectedCounter(baseCounter);
                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    private void HandleMovement()
    {
        var inputVector = gameInput.GetInputVector2Normalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = Time.deltaTime * moveSpeed;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.one * playerHeight, playerWidth, moveDir, moveDistance);
        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.one * playerHeight, playerWidth, moveDirX, moveDistance);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.one * playerHeight, playerWidth, moveDirZ, moveDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }
        isWalking = moveDir != Vector3.zero;
        if (isWalking)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDir * rotateSpeed, rotateSpeed);
        }
    }
    private void SetSelectedCounter(BaseCounter baseCounter)
    {
        this.selectedCounter = baseCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = baseCounter
        });
    }
    public Transform GetKitchenObjectTransform()
    {
        return kitchenObjectHoldPoint.transform;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        if (kitchenObject != null)
        {
            OnPickedSomething?.Invoke(this, EventArgs.Empty);
        }
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
    #endregion
}
