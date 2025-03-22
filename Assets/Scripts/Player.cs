using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }

    public event EventHandler <OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs {
        public ClearCounter selectedCounter;
    }

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;
    
    private bool isWalking;
    private Vector3 lastInteractDir;
    private ClearCounter selectedCounter;




    private void Awake()
    {
        if (Instance != null){
            Debug.Log("There is more than one Player instance");
        }
        Instance = this;
    }


    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e){
        if (selectedCounter != null){
            selectedCounter.Interact();
        }
    }


    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }


    public bool IsWalking(){
        return isWalking;
    }

    private void HandleInteractions(){
        
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero){
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;

        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask)){
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter)){
                // Has ClearCounter
                // clearCounter.Interact();
                if (clearCounter != selectedCounter){
                    SetSelectedCounter(clearCounter);
                }
            } else {
                // If there is something but it is not the counter
                SetSelectedCounter(null);
            }
        } else {
            // Null if there is nothing
            SetSelectedCounter(null);
        }
    }

    private void HandleMovement(){

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);


        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        
        if(!canMove){
            //Cannot move towards moveDir-ection

            //Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0f, 0f).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if(canMove){
                // Can move only on X
                moveDir = moveDirX;
            } else {
                // Cannot move only on the X

                //Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0f, 0f, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if(canMove){
                    // Can move only on the Z 
                    moveDir = moveDirZ;
                } else {
                    // Can not move in any direction
                }

            }

        }
        if(canMove){
            transform.position += moveDir * moveDistance;
        }

        isWalking = moveDir != Vector3.zero ;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime *rotateSpeed);
    }


    private void SetSelectedCounter(ClearCounter selectedCounter){
        this.selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs {
            selectedCounter = selectedCounter
        });
    }
}
