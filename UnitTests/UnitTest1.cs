using CinemaApp;
using NUnit.Framework;

namespace CinemaAppTests
{
    [TestFixture]
    public class TestingTicketPriceController
    {

        //Test cases for Adult Before 5pm
        [TestCase(1, "Adult", "Monday", 4, 14.50)]
        [TestCase(2, "Adult", "Monday", 4, 29.00)]
        [TestCase(0, "Adult", "Monday", 4, -1)]
        [TestCase(1, "Child", "Monday", 4, -1)]
        [TestCase(1, "Adult", "Tuesday", 4, -1)]
        [TestCase(1, "Adult", "Monday", 9, -1)]
        public void Adult_Before_5_Test(int quantity,string person, string day,decimal time,decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Adult_Before_5(quantity, person, day, time);

            //Assert
            Assert.That(price == expected);
        }

        //Test Cases for Adult After 5pm
        [TestCase(1, "Adult", "Monday", 8, 17.50)]
        [TestCase(2, "Adult", "Monday", 8, 35.00)]
        [TestCase(0, "Adult", "Monday", 8, -1)]
        [TestCase(1, "Child", "Monday", 8, -1)]
        [TestCase(1, "Adult", "Tuesday", 8, -1)]
        [TestCase(1, "Adult", "Monday", 4, -1)] 
        public void Adult_After_5_Test(int quantity, string person, string day, decimal time, decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Adult_After_5(quantity, person, day, time);

            //Assert
            Assert.That(price == expected);
        }

        //Test cases for Adult ticket on Tuesdays
        [TestCase(1, "Adult", "Tuesday", 13.00)]
        [TestCase(2, "Adult", "Tuesday", 26.00)]
        [TestCase(1, "Adult", "Monday", -1)]
        [TestCase(0, "Adult", "Tuesday", -1)]
        [TestCase(1, "Child", "Tuesday", -1)]
        [TestCase(1, "Adult", "Friday", -1)]
        public void Adult_Tuesday_Test(int quantity, string person, string day,decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Adult_Tuesday(quantity, person, day);

            //Assert
            Assert.That(price == expected);
        }


        //Test Cases for Children under 16 tickets
        [TestCase(1, "Child", 12.00)]
        [TestCase(2, "Child", 24.00)]
        [TestCase(0, "Child", -1)]
        [TestCase(1, "Adult", -1)]
        [TestCase(1, "Senior", -1)]
        
        public void Child_Under_16_Test(int quantity, string person, decimal expected)
        {

            //Arrange 
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Child_Under_16(quantity, person);

            //Assert
            Assert.That(price == expected);
        }


        //Test Cases for Senior tickets
        [TestCase(1, "Senior", 12.50)]
        [TestCase(2, "Senior", 25.00)]
        [TestCase(0, "Senior", -1)]
        [TestCase(1, "Adult", -1)]

        public void Senior_Test(int quantity, string person, decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Senior(quantity, person);

            //Assert
            Assert.That(price == expected);
        }

        //Test Cases for Student tickets
        [TestCase(1, "Student", 14.00)]
        [TestCase(2, "Student", 28.00)]
        [TestCase(0, "Student", -1)]
        [TestCase(1, "Adult", -1)]

        public void Student_Test(int quantity, string person, decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Student(quantity, person);

            //Assert
            Assert.That(price == expected);
        }


        //Test Cases for Family Pass tickets
        [TestCase(1, 2, 2, 46.00)] //Accepts 2 Adults and 2 Children
        [TestCase(1, 1, 3, 46.00)] //Also accepts 1 Adult and 3 Children
        [TestCase(1, 2, 1, -1)]
        [TestCase(1, 2, 3, -1)]
        [TestCase(1, 0, 4, -1)]

        public void Family_Pass_Test(int quantity_ticket, int quantity_adult, int quantity_child, decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Family_Pass(quantity_ticket, quantity_adult, quantity_child);

            //Assert
            Assert.That(price == expected);
        }


        //Test Cases for Chick Flick Thursday tickets
        [TestCase(1, "Adult", "Thursday", 21.50)]
        [TestCase(2, "Adult", "Thursday", 43.00)]
        [TestCase(0, "Adult", "Thursday", -1)]
        [TestCase(1, "Child", "Thursday", -1)]
        [TestCase(1, "Adult", "Tuesday", -1)]
        public void Chick_Flick_Thursday_Test(int quantity, string person, string day, decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Chick_Flick_Thursday(quantity, person, day);

            //Assert
            Assert.That(price == expected);
        }

        //Test Cases for Kids and Carers tickets
        [TestCase(1, "Wednesday", false, 12.00)]
        [TestCase(2, "Wednesday", false, 24.00)]
        [TestCase(0, "Wednesday", false, -1)]
        [TestCase(1, "Thursday", false, -1)]
        [TestCase(1, "Wednesday", true, -1)]
        [TestCase(1, "Thursday", true, -1)]
        public void Kids_Carers_Test(int quantity, string day, bool holiday, decimal expected)
        {
            //Act
            TicketPriceController TPC = new TicketPriceController();

            //Arrange
            decimal price = TPC.Kids_Careers(quantity, day, holiday);

            //Assert
            Assert.That(price == expected);
        }

    }
    }
