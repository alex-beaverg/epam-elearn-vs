using System.Collections.Generic;

namespace CarsFromConsole
{
    // Singleton class
    internal class AllCars
    {
        private static AllCars instance;
        private List<Car> allCars;

        protected AllCars(List<Car> c_list)
        {
            allCars = c_list;
        } 
        
        public static AllCars getInstance(List<Car> get_list)
        {
            if (instance == null)
            {
                instance = new AllCars(get_list);
            }
            return instance;
        }

        public List<Car> getAllCars() 
        {
            return allCars;
        }        
    }
}
