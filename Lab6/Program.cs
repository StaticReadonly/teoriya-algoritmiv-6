using Classes;

namespace Lab6
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            BinaryTree tree = await BinaryTree
                .CreateFromFile("D:\\KPI Labs\\Теорія алгоритмів\\lab6\\Lab6\\task_06_examples\\input_1000b.txt");

            List<int> getItems = tree.GetList();

            getItems.Sort();

            tree.WriteValues(getItems);

            int sum = 1025;
            var sums = tree.GetAllSums(sum);

            string outputFile = "D:\\KPI Labs\\Теорія алгоритмів\\lab6\\Lab6\\Tests\\output_1000b_1025.txt";

            using FileStream stream = File.Create(outputFile);
            using StreamWriter writer = new StreamWriter(stream);

            foreach(var s in sums)
            {
                writer.WriteLine(string.Join(' ', s));
            }
        }
    }
}
