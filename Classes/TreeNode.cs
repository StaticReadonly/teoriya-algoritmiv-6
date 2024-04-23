namespace Classes
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode? Left { get; set; } = null;
        public TreeNode? Right { get; set; } = null;

        public TreeNode(int value)
        {
            Value = value;
        }
    }
}
