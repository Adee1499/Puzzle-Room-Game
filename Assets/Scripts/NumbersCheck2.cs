using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class NumbersCheck2 : MonoBehaviour
{
    public GameObject CubeConstraint1;
    public GameObject CubeConstraint2;
    public GameObject CubeConstraint3;
    public GameObject CubeConstraint4;
    public GameObject CubeConstraint5;
    public GameObject Cube3;
    public GameObject Cube1;
    public GameObject Cube0;
    public GameObject Cube2;
    public GameObject Cube4;
    
    // initialize cube constraint variables
    private int first;
    private int second;
    private int third;
    private int fourth;
    private int fifth;
    
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

    public bool solved2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // FIRST CONSTRAINT
        if (CollisionDetection.IsTouching(CubeConstraint1, Cube3)) first = 3;
        if (CollisionDetection.IsTouching(CubeConstraint1, Cube1)) first = 1;
        if (CollisionDetection.IsTouching(CubeConstraint1, Cube0)) first = 0;
        if (CollisionDetection.IsTouching(CubeConstraint1, Cube2)) first = 2;
        if (CollisionDetection.IsTouching(CubeConstraint1, Cube4)) first = 4;
        
        // SECOND CONSTRAINT
        if (CollisionDetection.IsTouching(CubeConstraint2, Cube3)) second = 3;
        if (CollisionDetection.IsTouching(CubeConstraint2, Cube1)) second = 1;
        if (CollisionDetection.IsTouching(CubeConstraint2, Cube0)) second = 0;
        if (CollisionDetection.IsTouching(CubeConstraint2, Cube2)) second = 2;
        if (CollisionDetection.IsTouching(CubeConstraint2, Cube4)) second = 4;
        
        // THIRD CONSTRAINT
        if (CollisionDetection.IsTouching(CubeConstraint3, Cube3)) third = 3;
        if (CollisionDetection.IsTouching(CubeConstraint3, Cube1)) third = 1;
        if (CollisionDetection.IsTouching(CubeConstraint3, Cube0)) third = 0;
        if (CollisionDetection.IsTouching(CubeConstraint3, Cube2)) third = 2;
        if (CollisionDetection.IsTouching(CubeConstraint3, Cube4)) third = 4;
        
        // FOURTH CONSTRAINT
        if (CollisionDetection.IsTouching(CubeConstraint4, Cube3)) fourth = 3;
        if (CollisionDetection.IsTouching(CubeConstraint4, Cube1)) fourth = 1;
        if (CollisionDetection.IsTouching(CubeConstraint4, Cube0)) fourth = 0;
        if (CollisionDetection.IsTouching(CubeConstraint4, Cube2)) fourth = 2;
        if (CollisionDetection.IsTouching(CubeConstraint4, Cube4)) fourth = 4;
        
        // FIFTH CONSTRAINT
        if (CollisionDetection.IsTouching(CubeConstraint5, Cube3)) fifth = 3;
        if (CollisionDetection.IsTouching(CubeConstraint5, Cube1)) fifth = 1;
        if (CollisionDetection.IsTouching(CubeConstraint5, Cube0)) fifth = 0;
        if (CollisionDetection.IsTouching(CubeConstraint5, Cube2)) fifth = 2;
        if (CollisionDetection.IsTouching(CubeConstraint5, Cube4)) fifth = 4;
        
        
        // LINE SUMS
        line1 = 12 + first;
        line2 = 6 + second + third;
        line3 = fourth + 8 + fifth;
        line4 = 11 + fourth;
        line5 = first + second + 8;
        line6 = 7 + third + fifth;
        line7 = 5 + second + fifth;
        line8 = fourth + second + 7;

        // UPDATE LIGHTS
        if (line1 == 12) light1.color = new Color(0, 1, 0);
        if (line2 == 12) light2.color = new Color(0, 1, 0);
        if (line3 == 12) light3.color = new Color(0, 1, 0);
        if (line4 == 12) light4.color = new Color(0, 1, 0);
        if (line5 == 12) light5.color = new Color(0, 1, 0);
        if (line6 == 12) light6.color = new Color(0, 1, 0);
        if (line7 == 12) light7.color = new Color(0, 1, 0);
        if (line8 == 12) light8.color = new Color(0, 1, 0);
        
        if (line1 != 12) light1.color = new Color(1, 0, 0);
        if (line2 != 12) light2.color = new Color(1, 0, 0);
        if (line3 != 12) light3.color = new Color(1, 0, 0);
        if (line4 != 12) light4.color = new Color(1, 0, 0);
        if (line5 != 12) light5.color = new Color(1, 0, 0);
        if (line6 != 12) light6.color = new Color(1, 0, 0);
        if (line7 != 12) light7.color = new Color(1, 0, 0);
        if (line8 != 12) light8.color = new Color(1, 0, 0);

        if (line1 == 12 && line2 == 12 && line3 == 12 && line4 == 12 && line5 == 12 && line6 == 12 && line7 == 12 &&
            line8 == 12)
        {
            solved2 = true;
        }
    }
}
