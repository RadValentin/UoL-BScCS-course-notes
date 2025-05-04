using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSwingMovement : MonoBehaviour
{
    //GameObjects
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject Camera_;
    public GameObject ForwardDirection;

    //Vector3 positions
    //hands
    private Vector3 PreviousFrameLeftHand;
    private Vector3 PreviousFrameRightHand;
    private Vector3 CurrentFramePositionRightHand;
    private Vector3 CurrentFramePositionLeftHand;

    //Player
    private Vector3 PlayerPreviousFrame;
    private Vector3 PlayerCurrentFrame;

    //Speed
    public float Speed = 60;
    private float Speed_hand;

    // Start is called before the first frame update
    void Start()
    {
        //Previous positions
        PlayerPreviousFrame = transform.position;
        PreviousFrameLeftHand = LeftHand.transform.position;
        PreviousFrameRightHand = RightHand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //forward direction
        float yRotation = Camera_.transform.eulerAngles.y;
        ForwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);

        //Get the current hand pos
        CurrentFramePositionLeftHand = LeftHand.transform.position;
        CurrentFramePositionRightHand = RightHand.transform.position;

        //Get the current playe pos
        PlayerCurrentFrame = transform.position;

        //Get distance from previous frame
        float playerDistanceMoved = Vector3.Distance(PlayerCurrentFrame, PlayerPreviousFrame);
        float leftHandDistanceMoved = Vector3.Distance(CurrentFramePositionLeftHand, PreviousFrameLeftHand);
        float rightHandDistanceMoved = Vector3.Distance(CurrentFramePositionRightHand, PreviousFrameRightHand);

        Speed_hand = ((leftHandDistanceMoved - playerDistanceMoved) + (rightHandDistanceMoved - playerDistanceMoved));

        if (Time.timeSinceLevelLoad > 2f)
            transform.position += ForwardDirection.transform.forward * Speed_hand * Speed * Time.deltaTime;


        //Set previous frame of hands for next frame
        PreviousFrameRightHand = CurrentFramePositionRightHand;
        PreviousFrameLeftHand = CurrentFramePositionLeftHand;
        //Update for player also
        PlayerPreviousFrame = PlayerCurrentFrame;
    }



    
}
