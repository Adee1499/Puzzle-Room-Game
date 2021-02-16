using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class NumbersCheck1 : MonoBehaviour
{
    public GameObject CubeConstraint1;
    public GameObject CubeConstraint2;
    public GameObject CubeConstraint3;
    public GameObject CubeConstraint4;
    public GameObject CubeConstraint5;
    public GameObject CubeConstraint6;
    public GameObject Cube7;
    public GameObject Cube9;
    public GameObject Cube3;
    public GameObject Cube8;
    public GameObject Cube6;
    public GameObject Cube2;
    
    // initialize cube constraint variables
    private int first;
    private int second;
    private int third;
    private int fourth;
    private int fifth;
    private int sixth;
    
    // initialize line (sum holders)
    private int line1;
    private int line2;
    private int line3;
    private int line4;
    private int line5;
    private int line6;
    private int line7;
    private int line8;
    
    // LIGHTS
    public Light light1;
    public Light light2;
    public Light light3;
    public Light light4;
    public Light light5;
    public Light light6;
    public Light light7;
    public Light light8;

    public bool solved1 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // FIRST CONSTRAINT
        if (CollisionDetection.IsTouching(CubeConstraint1, Cube7)) first = 7;
        if (CollisionDetection.IsTouching(CubeConstraint1, Cube9)) first = 9;
        if (CollisionDetection.IsTouching(CubeConstraint1, Cube3)) first = 3;
        if (CollisionDetection.IsTouching(CubeConstraint1, Cube8)) first = 8;
        if (CollisionDetection.IsTouching(CubeConstraint1, Cube6)) first = 6;
        if (CollisionDetection.IsTouching(CubeConstraint1, Cube2)) first = 2;
        
        // SECOND CONSTRAINT
        if (CollisionDetection.IsTouching(CubeConstraint2, Cube7)) second = 7;
        if (CollisionDetection.IsTouching(CubeConstraint2, Cube9)) second = 9;
        if (CollisionDetection.IsTouching(CubeConstraint2, Cube3)) second = 3;
        if (CollisionDetection.IsTouching(CubeConstraint2, Cube8)) second = 8;
        if (CollisionDetection.IsTouching(CubeConstraint2, Cube6)) second = 6;
        if (CollisionDetection.IsTouching(CubeConstraint2, Cube2)) second = 2;
        
        // THIRD CONSTRAINT
        if (CollisionDetection.IsTouching(CubeConstraint3, Cube7)) third = 7;
        if (CollisionDetection.IsTouching(CubeConstraint3, Cube9)) third = 9;
        if (CollisionDetection.IsTouching(CubeConstraint3, Cube3)) third = 3;
        if (CollisionDetection.IsTouching(CubeConstraint3, Cube8)) third = 8;
        if (CollisionDetection.IsTouching(CubeConstraint3, Cube6)) third = 6;
        if (CollisionDetection.IsTouching(CubeConstraint3, Cube2)) third = 2;
        
        // FOURTH CONSTRAINT
        if (CollisionDetection.IsTouching(CubeConstraint4, Cube7)) fourth = 7;
        if (CollisionDetection.IsTouching(CubeConstraint4, Cube9)) fourth = 9;
        if (CollisionDetection.IsTouching(CubeConstraint4, Cube3)) fourth = 3;
        if (CollisionDetection.IsTouching(CubeConstraint4, Cube8)) fourth = 8;
        if (CollisionDetection.IsTouching(CubeConstraint4, Cube6)) fourth = 6;
        if (CollisionDetection.IsTouching(CubeConstraint4, Cube2)) fourth = 2;
        
        // FIFTH CONSTRAINT
        if (CollisionDetection.IsTouching(CubeConstraint5, Cube7)) fifth = 7;
        if (CollisionDetection.IsTouching(CubeConstraint5, Cube9)) fifth = 9;
        if (CollisionDetection.IsTouching(CubeConstraint5, Cube3)) fifth = 3;
        if (CollisionDetection.IsTouching(CubeConstraint5, Cube8)) fifth = 8;
        if (CollisionDetection.IsTouching(CubeConstraint5, Cube6)) fifth = 6;
        if (CollisionDetection.IsTouching(CubeConstraint5, Cube2)) fifth = 2;
        
        // SIXTH CONSTRAINT
        if (CollisionDetection.IsTouching(CubeConstraint6, Cube7)) sixth = 7;
        if (CollisionDetection.IsTouching(CubeConstraint6, Cube9)) sixth = 9;
        if (CollisionDetection.IsTouching(CubeConstraint6, Cube3)) sixth = 3;
        if (CollisionDetection.IsTouching(CubeConstraint6, Cube8)) sixth = 8;
        if (CollisionDetection.IsTouching(CubeConstraint6, Cube6)) sixth = 6;
        if (CollisionDetection.IsTouching(CubeConstraint6, Cube2)) sixth = 2;
        
        
        // LINE SUMS
        line1 = first + second + third;
        line2 = fourth + 6;
        line3 = 4 + fifth + sixth;
        line4 = first + fourth + 4;
        line5 = second + 5 + fifth;
        line6 = third + 1 + sixth;
        line7 = first + 5 + sixth;
        line8 = 9 + third;

        
        // UPDATE LIGHTS
        if (line1 == 15) light1.color = new Color(0, 1, 0);
        if (line2 == 15) light2.color = new Color(0, 1, 0);
        if (line3 == 15) light3.color = new Color(0, 1, 0);
        if (line4 == 15) light4.color = new Color(0, 1, 0);
        if (line5 == 15) light5.color = new Color(0, 1, 0);
        if (line6 == 15) light6.color = new Color(0, 1, 0);
        if (line7 == 15) light7.color = new Color(0, 1, 0);
        if (line8 == 15) light8.color = new Color(0, 1, 0);
        
        if (line1 != 15) light1.color = new Color(1, 0, 0);
        if (line2 != 15) light2.color = new Color(1, 0, 0);
        if (line3 != 15) light3.color = new Color(1, 0, 0);
        if (line4 != 15) light4.color = new Color(1, 0, 0);
        if (line5 != 15) light5.color = new Color(1, 0, 0);
        if (line6 != 15) light6.color = new Color(1, 0, 0);
        if (line7 != 15) light7.color = new Color(1, 0, 0);
        if (line8 != 15) light8.color = new Color(1, 0, 0);
        
        if (line1 == 15 && line2 == 15 && line3 == 15 && line4 == 15 && line5 == 15 && line6 == 15 && line7 == 15 &&
            line8 == 15)
        {
            solved1 = true;
        }
    }
}
