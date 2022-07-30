namespace Sandbox;

public class ReferenceVsValue
{
    public static void Test()
    {
        
        int number = 5;
        //5
        SomeMethod(number);
        //5
        Console.WriteLine("number: " + number);
        // Почему выведется 5, а не 6. Ответ должен состоять в хотя бы абстрактном понимании на уровне памяти
        // что происходит. Здесь важно разобраться что такое стек (stack), что такое куча (heap). 
        // Когда в ту или иную память записываются данные. Что такое ссылочные и значимые типы данных в языке.
        // Их особенности


        List<int> list = new List<int>() { 2, 3 };
        //link1 s h list
        SomeMethod(list);
        //link1 s h list{2,3,1}
        Console.WriteLine("List has element: " + string.Join(", ", list));
        // Почему здесь в списке добавится элемент, ведь в предыдущем примере была 5, 5 и останется, а здесь
        // почему то все изменится. Ответ лежит в той же плоскости знания

        string stroka = "Im very tricky fucking thing";
        //link2 s h stroka
        SomeMethod(stroka);
        //link2 s h stroka
        Console.WriteLine("stroka: " + stroka);
        // Какой тип данных в языке строка? Ссылочный или значимый? Какие у нее особенности есть
        // Когда узнаешь тип следующий вопрос под звездочкой будет, а почему строка не изменилась после вызова метода?
        
        List<int> anotherList = new List<int>() { 12, 13 };
        //link3 s h alist
        AnotherFuckingMethodWithStar(list);
        //link3 s h alist{12,13} alist{1}
        Console.WriteLine("List has element: " + string.Join(", ", anotherList));
        // Вопрос под звездочкой. В примере с списком ранее мы изменили список в методе и кол-во элементов увеличилось
        // А здесь мы его тоже меняем по сути, а результат иной.
    }

    private static void SomeMethod(int someNumber)
    {
        //5 5
        someNumber = someNumber + 1;
        //5 6
    }

    private static void SomeMethod(List<int> someList)
    {
        //link1 link1 s h list{2,3}
        someList.Add(1);
        //link1 link1 s h list{2,3,1}
    }
    private static void SomeMethod(string someNumber)
    {
        //link2 link2 s h stroka""
        someNumber = null;
        //link2 link2=0 s h stroka""
    }
    private static void AnotherFuckingMethodWithStar(List<int> list)
    {
        //link3 link3 s h alist{12,13}
        list = new List<int>();
        //link3 link4 s h alist{12,13} alist{}
        list.Add(1);
        //link3 link4 s h alist{12,13} alist{1}
    }
}