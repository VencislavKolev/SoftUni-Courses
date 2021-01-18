
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Bakery.Core.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using Bakery.Models.BakedFoods;
using Bakery.Utilities.Messages;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IDrink> drinks;
        private readonly ICollection<ITable> tables;
        private readonly ICollection<IBakedFood> bakedFoods;

        private decimal restaurantIncome = 0;
        public Controller()
        {
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.bakedFoods = new List<IBakedFood>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            switch (type)
            {
                case "Tea": drink = new Tea(name, portion, brand); break;
                case "Water": drink = new Water(name, portion, brand); break;
                default:
                    break;
            }
            this.drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            switch (type)
            {
                case "Cake": food = new Cake(name, price); break;
                case "Bread": food = new Bread(name, price); break;
                default:
                    break;
            }
            this.bakedFoods.Add(food);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            switch (type)
            {
                case "InsideTable": table = new InsideTable(tableNumber, capacity); break;
                case "OutsideTable": table = new OutsideTable(tableNumber, capacity); break;
                default:
                    break;
            }
            this.tables.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var freeTable in this.tables
                                          .Where(x => x.IsReserved == false))
            {
                sb.AppendLine(freeTable.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            //return $"Total income: {totalIncome:f2}lv";
            return string.Format(OutputMessages.TotalIncome, restaurantIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            decimal tableBill = table.GetBill();
            restaurantIncome += tableBill;
            table.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}")
              .AppendLine($"Bill: {tableBill:f2}");

            return sb.ToString().TrimEnd();

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables
                .FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IDrink drink = this.drinks
               .FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            //TODO check
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";

        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables
                .FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IBakedFood food = this.bakedFoods
                .FirstOrDefault(x => x.Name == foodName);
            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables
                .FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);
            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}
