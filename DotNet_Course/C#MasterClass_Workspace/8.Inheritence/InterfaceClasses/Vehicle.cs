namespace _8.Inheritence.InterfaceClasses
{
    internal class Vehicle
    {
        public float Speed { get; set; }

        public string Color { get; set; }
        public Vehicle()
        {
            Speed = 10.5f;
            Color = "Black";

        }

        public Vehicle(float speed, string color)
        {
            Speed = speed;
            Color = color;
        }
    }
}