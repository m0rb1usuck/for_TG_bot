namespace Sandbox;

public class ReferenceVsValue
{
    public static void Test()
    {
        int number = 5;
        SomeMethod(number);
        Console.WriteLine("number: " + number);
        // Почему выведется 5, а не 6. Ответ должен состоять в хотя бы абстрактном понимании на уровне памяти
        // что происходит. Здесь важно разобраться что такое стек (stack), что такое куча (heap). 
        // Когда в ту или иную память записываются данные. Что такое ссылочные и значимые типы данных в языке.
        // Их особенности

        List<int> list = new List<int>() { 2, 3 };
        SomeMethod(list);
        Console.WriteLine("List has element: " + string.Join(", ", list));
        // Почему здесь в списке добавится элемент, ведь в предыдущем примере была 5, 5 и останется, а здесь
        // почему то все изменится. Ответ лежит в той же плоскости знания

        string stroka = "Im very tricky fucking thing";
        SomeMethod(stroka);
        Console.WriteLine("stroka: " + stroka);
        // Какой тип данных в языке строка? Ссылочный или значимый? Какие у нее особенности есть
        // Когда узнаешь тип следующий вопрос под звездочкой будет, а почему строка не изменилась после вызова метода?
        
        List<int> anotherList = new List<int>() { 12, 13 };
        AnotherFuckingMethodWithStar(list);
        Console.WriteLine("List has element: " + string.Join(", ", anotherList));
        // Вопрос под звездочкой. В примере с списком ранее мы изменили список в методе и кол-во элементов увеличилось
        // А здесь мы его тоже меняем по сути, а результат иной.
    }

    private static void SomeMethod(int someNumber)
    {
        someNumber = someNumber + 1;
    }

    private static void SomeMethod(List<int> someList)
    {
        someList.Add(1);
    }
    private static void SomeMethod(string someNumber)
    {
        someNumber = null;
    }
    private static void AnotherFuckingMethodWithStar(List<int> list)
    {
        list = new List<int>();
        list.Add(1);
    } 
}