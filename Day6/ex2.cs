using System;

public class Vehicle

{

    public virtual void StartEngine()

    {

        Console.WriteLine("Vehicle engine started.");

    }
}

public class Car : Vehicle

{

    public override void StartEngine()

    {
        Console.WriteLine("Car-specific checks...");

        base.StartEngine();
    }
}