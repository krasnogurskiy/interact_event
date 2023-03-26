using System;
using System.Threading;

namespace events_flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            // створення об'єктів
            Sun sun = new Sun();
            Flower dayFlower = new Flower(FlowerType.Day, 7);
            Flower nightFlower = new Flower(FlowerType.Night, 10);

            Bee bee = new Bee();
            Girl girl = new Girl();

            // додавання підписок на події
            sun.SunRise += dayFlower.OnSunRise;
            sun.SunRise += nightFlower.OnSunRise;
            sun.SunRise += (sender, e) =>
            {
                bee.VisitFlower(dayFlower);
                girl.TakeSelfie(dayFlower);
            };
            sun.SunSet += dayFlower.OnSunSet;
            sun.SunSet += nightFlower.OnSunSet;
            sun.SunSet += (sender, e) =>
            {
                girl.TakeSelfie(nightFlower);
            };

            // "симуляція" 30дневного життя квіток, подій, що з ними впродовж цих днів відбуваються
            for (int i = 1; i <= 30; i++)
            {
                Console.WriteLine($"Day {i}:");
                sun.Rise();
                Thread.Sleep(1000);
                sun.Set();
                Thread.Sleep(1000);
                dayFlower.BloomDuration--;
                nightFlower.BloomDuration--;
                Console.WriteLine('\n');
            }

            Console.ReadLine();
        }

    }
}
