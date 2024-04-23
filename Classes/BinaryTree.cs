namespace Classes
{
    public class BinaryTree
    {
        public static async Task<BinaryTree> CreateFromFile(string file)
        {
            using FileStream stream = File.OpenRead(file);
            using StreamReader reader = new StreamReader(stream);

            string line = await reader.ReadToEndAsync();

            List<int> items = new List<int>();

            string[] strs = line.Split(new char[] {' ', '\n', '\t'});

            foreach(var s in strs)
            {
                if (s.Length > 0)
                    items.Add(int.Parse(s));
            }

            return new BinaryTree(items);
        }

        private TreeNode _Root { get; set; }

        public BinaryTree(List<int> items)
        {
            _Root = new TreeNode(items[0]);

            int cur = 1;

            _FillTree(ref cur, items, _Root);
        }

        private void _FillTree(ref int current, List<int> items, TreeNode node)
        {
            if (current >= items.Count)
                return;

            if (items[current] != 0)
            {
                node.Left = new TreeNode(items[current++]);
                _FillTree(ref current, items, node.Left);
            }
            else
            {
                current++;
            }

            if (items[current] != 0)
            {
                node.Right = new TreeNode(items[current++]);
                _FillTree(ref current, items, node.Right);
            }
            else
            {
                current++;
            }
        }

        public List<int> GetList()
        {
            List<int> result = new List<int>();

            InOrderTraversal(result, _Root);

            return result;
        }

        private void InOrderTraversal(List<int> result, TreeNode current)
        {
            if (current.Left != null)
                InOrderTraversal(result, current.Left);

            result.Add(current.Value);

            if (current.Right != null)
                InOrderTraversal(result, current.Right);
        }

        public void WriteValues(List<int> values)
        {
            int current = 0;
            InOrderTraversalWrite(ref current, values, _Root);
        }

        private void InOrderTraversalWrite(ref int current, List<int> values, TreeNode node)
        {
            if (node.Left != null)
                InOrderTraversalWrite(ref current, values, node.Left);

            node.Value = values[current++];

            if (node.Right != null)
                InOrderTraversalWrite(ref current, values, node.Right);
        }

        public List<List<int>> GetAllSums(int sum)
        {
            List<List<int>> result = new List<List<int>>();

            _GetAllSums(sum, _Root, result, new List<int>());

            return result;
        }

        private void _GetAllSums(int sum, TreeNode current, List<List<int>> result, List<int> trace)
        {
            trace.Add(current.Value);

            int sum_copy = sum;
            int i = trace.Count - 1;
            for (; i >= 0 && sum_copy > 0; i--)
            {
                sum_copy -= trace[i];
            }

            if (sum_copy == 0)
            {
                i++;
                List<int> new_res = new List<int>();
                while(i < trace.Count)
                {
                    new_res.Add(trace[i++]);
                }
                result.Add(new_res);
            }

            if (current.Left != null)
                _GetAllSums(sum, current.Left, result, trace);

            if (current.Right != null)
                _GetAllSums(sum, current.Right, result, trace);

            trace.RemoveAt(trace.Count - 1);
        }
    }
}
