namespace CarsFromConsole
{
    // Class Cars
    internal class Car
    {
        // Fields
        string type;
        string model;
        int count;
        double price;
        
        // Constructor
        internal Car(string c_type, string c_model, int c_count, double c_price)
        {
            type = c_type;
            model = c_model;
            count = c_count;
            price = c_price;
        }

        // Getters
        internal string getType()
        { 
            return type; 
        }
        internal int getCount()
        {
            return count;
        }
        internal double getPrice()
        {
            return price;
        }
    }
}
