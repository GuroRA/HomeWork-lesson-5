using System;
using System.Collections.Generic;
using System.Linq;


namespace File_leson_5
{
    /// <summary>
    /// Предметы ЕГЭ (информатика, англ, физика)
    /// </summary>
    public enum Subjects
    {
        Informatics,
        English,
        Physics,
    }
    class Student
    {
        public string LastName;
        public string FirstName;
        public DateTime BirthDay;
        public Subjects Subject;
        public int Score;


        public Student(string lastName, string firstName, string d, Subjects subject, int score)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthDay = DateTime.Parse(d);
            Subject = subject;
            Score = score;
        }
    }


    internal class Program
    {
        /// <summary>
        /// Создаёт список ссылок на картинки и рандомизирует его
        /// </summary>
        static void GetRandomListOrder()
        {
            List<string> images = new List<string> {
                "image1.jpg", "image1.jpg",
                "image2.jpg", "image2.jpg",
                "image3.jpg", "image3.jpg",
                "image4.jpg", "image4.jpg",
                "image5.jpg", "image5.jpg",
                "image6.jpg", "image6.jpg",
                "image7.jpg", "image7.jpg",
                "image8.jpg", "image8.jpg",
                "image9.jpg", "image9.jpg",
                "image10.jpg", "image10.jpg",
                "image11.jpg", "image11.jpg",
                "image12.jpg", "image12.jpg",
                "image13.jpg", "image13.jpg",
                "image14.jpg", "image14.jpg",
                "image15.jpg", "image15.jpg",
                "image16.jpg", "image16.jpg",
                "image17.jpg", "image17.jpg",
                "image18.jpg", "image18.jpg",
                "image19.jpg", "image19.jpg",
                "image20.jpg", "image20.jpg",
                "image21.jpg", "image21.jpg",
                "image22.jpg", "image22.jpg",
                "image23.jpg", "image23.jpg",
                "image24.jpg", "image24.jpg",
                "image25.jpg", "image25.jpg",
                "image26.jpg", "image26.jpg",
                "image27.jpg", "image27.jpg",
                "image28.jpg", "image28.jpg",
                "image29.jpg", "image29.jpg",
                "image30.jpg", "image30.jpg",
                "image31.jpg", "image31.jpg",
                "image32.jpg", "image32.jpg",
            };

            Console.WriteLine("Порядок картинок до перемешивания: ");
            images.ForEach(p => Console.WriteLine(p));

            Random rnd = new Random();

            for (int i = 0; i < images.Count; i++)
            {
                string tmp = images[0];
                images.RemoveAt(0);
                images.Insert(rnd.Next(images.Count), tmp);

            }
            Console.WriteLine("\nПорядок картинок после перемешивания: ");
            images.ForEach(p => Console.WriteLine(p));
            return;
        }

        /// <summary>
        /// Список судентов
        /// </summary>
        /// <returns></returns>
        static Dictionary<int, Student> GetStudents()
        {
            Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                { 1, new Student( "Гуро", "Руслан", "17.09.2006", Subjects.Informatics, 242) },
                { 2, new Student( "Балобанова", "Арина", "13.03.2006", Subjects.English, 247) },
                { 3, new Student( "Валеев", "Сергей", "25.08.2006", Subjects.Physics, 278) },
                { 4, new Student( "Габов", "Алексей", "05.07.2006", Subjects.Informatics, 252) },
                { 5, new Student( "Дорожан", "Андрей", "14.05.2006", Subjects.Informatics, 255) },
                { 6, new Student( "Лисюткина", "Руслана", "28.06.2006", Subjects.Informatics, 241) },
                { 7, new Student( "Назарова", "Дарья", "11.05.2006", Subjects.English, 239) },
                { 8, new Student( "Сабирова", "Далия", "14.05.2006", Subjects.English, 287) },
                { 9, new Student( "Спиридонова", "Весна", "15.04.2006", Subjects.Physics, 253) },
                { 10, new Student( "Халикова", "Данна", "03.11.2006", Subjects.English, 262) },
            };
            return students;

        }
        static void Main(string[] args)
        {
            //Создать List на 64 элемента, скачать из интернета 32 пары картинок (любых). В List
            //должно содержаться по 2 одинаковых картинки. Необходимо перемешать List с
            //картинками.Вывести в консоль перемешанные номера(изначальный List и полученный
            //List).Перемешать любым способом.
            Console.WriteLine("Задание 1");
            GetRandomListOrder();

            //Создать студента из вашей группы (фамилия, имя, год рождения, с каким экзаменом
            //поступил, баллы). Создать словарь для студентов из вашей группы(10 человек).
            //Необходимо прочитать информацию о студентах с файла.В консоли необходимо создать
            //меню:
            //a.Если пользователь вводит: Новый студент, то необходимо ввести
            //информацию о новом студенте и добавить его в List
            //b.Если пользователь вводит: Удалить, то по фамилии и имени удаляется
            //студент
            //c.Если пользователь вводит: Сортировать, то происходит сортировка по баллам
            //(по возрастанию)
            Console.WriteLine("\nЗадание 2");

            Dictionary<int, Student> students = GetStudents();
            Console.WriteLine("Существующий список студентов: ");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key}: {student.Value.FirstName} {student.Value.LastName} {student.Value.Subject} {student.Value.Score}");
            }
            Console.WriteLine("\nЕсли вы хотите добавить нового пользователя введите: Новый студент\nЕсли вы хотите удалить пользователя введите: Удалить\nЕсли вы хотите отсортировать пользователей по балам введите: Отсортировать");

            switch (Console.ReadLine().ToLower())
            {
                case "новый студент":
                    students.Add(students.Count+1, new Student("Мустафин", "Олег", "12.12.2006", Subjects.English, 234));
                    break;
                case "удалить":
                    Console.WriteLine("\nВведите имя и фамилию студента которого хотите удалить: ");
                    string firstNameToRemove = Console.ReadLine().ToLower();
                    string LastNameToRemove = Console.ReadLine().ToLower();
                    students.Remove(students.FirstOrDefault(x => x.Value.FirstName.ToLower() == firstNameToRemove && x.Value.LastName.ToLower() == LastNameToRemove).Key);
                    break;
                case "отсортировать":
                    students = students.OrderBy(d => -d.Value.Score).ToDictionary(d => d.Key, d => d.Value);
                    break;

            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key}: {student.Value.FirstName} {student.Value.LastName} {student.Value.Subject} {student.Value.Score}");
            }
            Console.ReadKey();
        }
    }
}
