using System;
using System.Collections.Generic;

// ===== БАЗОВЫЙ КЛАСС =====
class Worker
{
    public string FullName { get; set; }
    public float BaseSalary { get; set; }

    public virtual void Show()
    {
        Console.WriteLine($"Работник: ФИО={FullName}, Зарплата={BaseSalary}");
    }

    public virtual float Salary()
    {
        return BaseSalary;
    }
}

// ===== ПРОИЗВОДНЫЙ КЛАСС: Инженер =====
class Engineer : Worker
{
    public string Specialty { get; set; }

    public override void Show()
    {
        Console.WriteLine($"Инженер: ФИО={FullName}, специальность={Specialty}, зарплата={Salary()}");
    }

    public override float Salary()
    {
        return BaseSalary; // оклад без надбавок
    }
}

// ===== ПРОИЗВОДНЫЙ КЛАСС: Продавец =====
class Seller : Worker
{
    public float SalesVolume { get; set; }

    public override void Show()
    {
        Console.WriteLine($"Продавец: ФИО={FullName}, объём продаж={SalesVolume}, зарплата={Salary()}");
    }

    public override float Salary()
    {
        return BaseSalary + SalesVolume * 0.1f; // оклад + 10% от продаж
    }
}

// ===== ОСНОВНАЯ ПРОГРАММА =====
class Program
{
    static void Main()
    {
        // Создаём коллекцию объектов базового типа
        List<Worker> workers = new List<Worker>();

        // Создаём объекты разных классов
        Worker w1 = new Worker 
        { 
            FullName = "Петров И.И.", 
            BaseSalary = 50000 
        };

        Engineer eng = new Engineer 
        { 
            FullName = "Сидоров А.К.", 
            BaseSalary = 70000, 
            Specialty = "Программирование" 
        };

        Seller sel = new Seller 
        { 
            FullName = "Иванова М.С.", 
            BaseSalary = 40000, 
            SalesVolume = 150000 
        };

        // Добавляем в коллекцию
        workers.Add(w1);
        workers.Add(eng);
        workers.Add(sel);

        // Вызываем переопределённые методы в цикле
        Console.WriteLine("=== Список сотрудников ===");
        foreach (Worker worker in workers)
        {
            worker.Show();
        }

        Console.WriteLine("\n=== Зарплаты ===");
        foreach (Worker worker in workers)
        {
            Console.WriteLine($"{worker.FullName}: {worker.Salary()} руб.");
        }

        Console.ReadKey();
    }
}