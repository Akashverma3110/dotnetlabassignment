namespace ParamArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array ");
            int size=Convert.ToInt32(Console.ReadLine());
            int[] arr=new int[size];
            for(int i=0; i<size; i++)
            {
                Console.Write($"Enter the {i+1} element");
                arr[i]=Convert.ToInt32(Console.ReadLine());
            }
            Class1 class1 = new Class1();
            

            AddDeligate ad = class1.Add;
            int result=ad(arr);
            Console.WriteLine(result);
        }
    }

    public delegate int AddDeligate(int[] arr);

    public class Class1
    {

        
        public int Add( int[] arr)
        {
            int sum = 0;
            for(int i=0;i<arr.Length; i++)
            {
                sum+= arr[i];
            }
            return sum;
        }
    }
}