using System;
using System.Text;

namespace Bartkivskyi_Lab6_VOOP
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            FlyingSmartCar flyCar = new FlyingSmartCar();

            flyCar.LoadPassangers(new Person[] { new Person("Олексій"), new Person("Антон") });
            flyCar.StartTrip(false, 70);

            flyCar.Transform();
            flyCar.TakeOff();

            // Помилки
            SmartCar car = new SmartCar();

            Person[] people = { new Person("Аня"), new Person("Олег"), new Person("Іван"), new Person("Марія"), new Person("Максим") };
            Person[] carSeats = new Person[4];

            try
            {
                Console.WriteLine("Посадка пасажирів");
                for (int i = 0; i < people.Length; i++)
                {
                    carSeats[i] = people[i];
                    Console.WriteLine($"{people[i].Name} сів/сіла в авто.");
                }

                Console.WriteLine("Спроба запуску");
                car.StartEngine();

                File.WriteAllText("trip_log.txt", "Поїздка пройшла успішно.");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"\nВ автомобілі не вистачає місць. Деталі: {ex.Message}");
            }
            catch (CarMalfunctionException ex)
            {
                Console.WriteLine($"\nТехнічна поломка: {ex.Message}");
                try
                {
                    File.AppendAllText("error_log.txt", ex.Message + "\n");
                    Console.WriteLine("Помилку записано до error_log.txt.");
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine($"Не вдалося записати лог у файл: {ioEx.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nНевідома помилка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nСистема діагностики автомобіля завершила роботу.");
            }
            car.OnEmergency += CallAmbulance;

            car.OnEmergency += BlockDoors;
            car.OnEmergency += SendSmsToOwner;

            Console.WriteLine("Автомобіль їде по трасі");

            car.TriggerEmergency("Різке падіння тиску в передньому колесі!");
        }
        static void CallAmbulance(string msg)
        {
            Console.WriteLine($"Отримано сигнал тривоги: \"{msg}\".");
        }

        static void BlockDoors(string msg)
        {
            Console.WriteLine($"Двері заблоковано для безпеки пасажирів.");
        }

        static void SendSmsToOwner(string msg)
        {
            Console.WriteLine($"Відправка SMS власнику: \"Ваше авто повідомило про проблему: {msg}\"");
        }
    }
}
