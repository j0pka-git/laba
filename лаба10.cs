using System;

class GenericArray<T>
{
    private T[] _items = Array.Empty<T>();
    
    public int Count => _items.Length;
    
    public void Add(T item)
    {
        Array.Resize(ref _items, _items.Length + 1);
        _items[^1] = item; // Используем индекс от конца
    }
    
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _items.Length)
            throw new IndexOutOfRangeException();
        
        var newArray = new T[_items.Length - 1];
        Array.Copy(_items, 0, newArray, 0, index);
        Array.Copy(_items, index + 1, newArray, index, _items.Length - index - 1);
        _items = newArray;
    }
    
    public T Get(int index)
    {
        if (index < 0 || index >= _items.Length)
            throw new IndexOutOfRangeException();
        
        return _items[index];
    }
 
    public T this[int index]
    {
        get => Get(index);
        set
        {
            if (index < 0 || index >= _items.Length)
                throw new IndexOutOfRangeException();
            _items[index] = value;
        }
    }
}

class World
{
    static void Main()
    {
        try
        {
            var numbers = new GenericArray<int>();
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            
            Console.WriteLine($"Всего элементов: {numbers.Count}");
            Console.WriteLine($"Первый элемент: {numbers[0]}");
            
            numbers.RemoveAt(1);
            Console.WriteLine($"Элемент после удаления: {numbers[1]}");
            
            var strings = new GenericArray<string>();
            strings.Add("Hello");
            strings.Add("World");
            Console.WriteLine($"Строки: {strings[0]}, {strings[1]}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
