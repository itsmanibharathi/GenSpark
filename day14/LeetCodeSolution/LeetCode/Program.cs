namespace LeetCode
{
    internal class Program
    {
        public async Task<int> MinDepthTree1()
        {
            Minimumdepth minimumdepth =  new Minimumdepth();
            Node root;

            //Create a tree 1
            root = new Node(3);
            root.left = new Node(9);
            root.right = new Node(20);
            root.right.left = new Node(15);
            root.right.right = new Node(7);
            return await minimumdepth.MinDepth(root);
        }

        public async Task<int> MinDepthTree2()
        {
            Minimumdepth minimumdepth =  new Minimumdepth();
            Node root;

            //Create a tree 2
            root = new Node(2);
            root.left = new Node(3);
            root.left.left = new Node(4);
            root.left.left.left = new Node(5);
            root.left.left.left.left = new Node(6);
            return await minimumdepth.MinDepth(root);
        }

        public async Task XLColumnTitle()
        {
            XLColumnTitle xlColumnTitle = new XLColumnTitle();
            for (int i = 1; i <= 100; i += 3)
            {
                xlColumnTitle.GetTitle(i);
            }
        }

        public async Task FindCycle1()
        {
            FindCycle findCycle = new FindCycle();
            ListNode head = new ListNode(3);
            head.next = new ListNode(2);
            head.next.next = new ListNode(0);
            head.next.next.next = new ListNode(-4);
            head.next.next.next.next = head.next;
            bool result = await findCycle.FindCycles(head);
            Console.WriteLine($"Cycle in the list : {result}");
        }

        public async Task FindCycle2()
        {
            FindCycle findCycle = new FindCycle();
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            bool result = await findCycle.FindCycles(head);
            Console.WriteLine($"Cycle in the list : {result}");
        }

        static async Task Main(string[] args)
        {
            Program program = new Program();

            // Minimumdepth in Binary Tree
            int result1 = await program.MinDepthTree1();
            Console.WriteLine($"Min depth Tree 1 : {result1}");

            int result2 = await program.MinDepthTree2();
            Console.WriteLine($"Min depth Tree 2 : {result2}");

            // XLColumnTitle
            program.XLColumnTitle().Wait();

            // FindCycle
            program.FindCycle1();

            program.FindCycle2();

        }
    }
}
