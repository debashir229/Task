using System;
using System.Threading.Channels;

abstract class Vehicle
{
    public virtual bool move();
}

class Car : Vehicle
{
    Random chance = new Random();
    public override bool move()
    {
        int num = chance.Next(500, 1500);
        return (num > 550 && num < 820 && num != 666);
    }
}