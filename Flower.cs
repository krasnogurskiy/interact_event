using System;
using System.Collections.Generic;
using System.Text;

namespace events_flowers
{
    public class Sun
    {
        public event EventHandler<SunEventArgs> SunRise;
        public event EventHandler<SunEventArgs> SunSet;

        public void Rise()
        {
            Console.WriteLine("Sun rises.");
            OnSunRise(new SunEventArgs());
        }

        public void Set()
        {
            Console.WriteLine("Sun sets.");
            OnSunSet(new SunEventArgs());
        }

        protected virtual void OnSunRise(SunEventArgs e)
        {
            SunRise?.Invoke(this, e);
        }

        protected virtual void OnSunSet(SunEventArgs e)
        {
            SunSet?.Invoke(this, e);
        }
    }

    public class SunEventArgs : EventArgs { }

    public class Flower
    {
        public FlowerType Type { get; set; }
        public int BloomDuration { get; set; }

        public Flower(FlowerType type, int bloomDuration)
        {
            Type = type;
            BloomDuration = bloomDuration;
        }

        public void OnSunRise(object sender, SunEventArgs e)
        {
            switch (Type)
            {
                case FlowerType.Day:
                    Console.WriteLine($"{Type} flower opens.");
                    break;
                case FlowerType.Night:
                    Console.WriteLine($"{Type} flower closes.");
                    break;
            }
        }

        public void OnSunSet(object sender, SunEventArgs e)
        {
            switch (Type)
            {
                case FlowerType.Day:
                    Console.WriteLine($"{Type} flower closes.");
                    break;
                case FlowerType.Night:
                    Console.WriteLine($"{Type} flower opens.");
                    break;
            }
        }
    }

    public enum FlowerType { Day, Night }

    public class Bee
    {
        public void VisitFlower(Flower flower)
        {
            Console.WriteLine($"Bee visits {flower.Type} flower.");
        }
    }

    public class Girl
    {
        public void TakeSelfie(Flower flower)
        {
            Console.WriteLine($"Girl takes selfie with {flower.Type} flower.");
        }
    }
}
