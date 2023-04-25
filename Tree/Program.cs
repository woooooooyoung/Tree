namespace Tree
{
    internal class Program
    {
        void BinarySearchTree()
        {
            SortedSet<int> sortedSet = new SortedSet<int>();

            sortedSet.Add(1);
            sortedSet.Add(2);
            sortedSet.Add(3);
            sortedSet.Add(4);
            sortedSet.Add(5);

            sortedSet.TryGetValue(3, out searchValue1);

            sortedSet.Remove(3);
        }
        static void Main(string[] args)
        {
            DataStructure.BinarySearchTree<int> bst = new DataStructure.BinarySearchTree<int>();

            bst.Add(3);
            bst.Add(2);
            bst.Add(1);
            bst.Add(4);
            bst.Add(5);
            bst.Add(6);
        }
    }
}