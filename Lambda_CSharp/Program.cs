namespace Lambda_CSharp;

internal class Program
{
    static void Main(string[] args)
    {
        //Especifica a fonte de dados
        int[] numbers = new int[] { 2, 3, 4, 5 };

        // Define a quary(consulta) operaçoes do LINQ
        var result = numbers.
            Where(x => x % 2 == 0).
            Select(x => x * 10);
        
        //Executando a quary
        foreach (int x in result)
        {
            Console.WriteLine(x);
        }
    }
}