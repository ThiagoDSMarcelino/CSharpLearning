using System;

BinaryTree<int> bt = new BinaryTree<int>();
bt.Add(4);
bt.Add(5);
bt.Add(1);
bt.Add(5);

Console.WriteLine(bt.Contains(5));