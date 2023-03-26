using System;
using System.Collections.Generic;
using System.Text;

namespace events_flowers
{
    public class Sun
    {
        /*події "SunRise" та "SunSet" що спрацьовуватимуть, коли сонце сходитиме та заходитиме
         Використовував тип делегата "EventHandler<SunEventArgs>" що містить посилання на метод, 
        якмй буде викликаний при спрацюванні події, і передається два параметри: об'єкт, 
        який генерує подію (у даному випадку - об'єкт "Sun") і об'єкт "SunEventArgs", 
        який містить додаткову інформацію про подію.
        */
        public event EventHandler<SunEventArgs> SunRise;
        public event EventHandler<SunEventArgs> SunSet;

        /*методи "Rise" i "Set" викликають методи, що викликають події (для Rise - SunRise, Set - SunSet) 
          та виводять повідомлення в консоль
         */
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
        
        /*  методи ''OnSunRise'' та ''OnSunSet'' викликають події,
        також оператор ? перевіряє чи делегат не є нульовим.          
         */
        public void OnSunRise(SunEventArgs e)
        {
            SunRise?.Invoke(this, e);
        }

        public void OnSunSet(SunEventArgs e)
        {
            SunSet?.Invoke(this, e);
        }
    }

    /* визначаєм новий клас ''SunEventArgs'' для передачі додаткової інформації разом з подіями,
    наразі мої події не потребують передачі додактових даних, тому клас ''SunEventArgs'' без додаткових полів та можливостей.
    наслідуємся від базового класу ''EventArgs'' 
    (базовий клас для створення спеціалізованих аргументів подій,
    шо можуть передавитись в обробники подій) */
    public class SunEventArgs : EventArgs { }

    /* клас ''Flower'' - наша квітка
    містить перелічувальний тип enum FlowerType, що вказує чи денна квітка чи нічна,
    BloomDuration - цілочислове значення ( тривалість цвітіння квітки)
    та методи OnSunRise, OnSunSet (обробники подій), котрі викликаються відповідно від події
    і залежно від типу (денна\нічна) виводять відповідний текст.
    */
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

    /*
     перелічуваний тип enum FlowerType з двома значеннями Day, Night.
     */
    public enum FlowerType { Day, Night }

    /*
     клас Bee описує бджолу, яка відвідує квіти при сході сонця
     */
    public class Bee
    {
        public void VisitFlower(Flower flower)
        {
            Console.WriteLine($"Bee visits {flower.Type} flower.");
        }
    }

    /*
     клас Girl описує дівчинку, яка робить селфі з відкритими квітками
     */
    public class Girl
    {
        public void TakeSelfie(Flower flower)
        {
            Console.WriteLine($"Girl takes selfie with {flower.Type} flower.");
        }
    }
}
