using System;

namespace PreOrderTraversal
{
    public class TreeNode
    {
        public string Value;// Значение узла
        public TreeNode Left;// Левое поддерево
        public TreeNode Right;// Правое поддерево

        public TreeNode(string value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        private TreeNode root;// Корень дерева

        public void Insert(string value)
        {
            root = InsertNode(root, value);// Вставка нового узла в дерево
        }

        private TreeNode InsertNode(TreeNode current,
            string value)
        {
            if (current == null)// Если текущий узел пустой, создаем новый узел с заданным значением
            {
                return new TreeNode(value);
            }

            if (string.Compare(value, current.Value) < 0)// Сравниваем значение с текущим узлом для определения, в какое поддерево вставить
            {
                current.Left = InsertNode(current.Left, value);// Рекурсивный вызов для левого поддерева
            }
            else
            {
                current.Right = InsertNode(current.Right, value);// Рекурсивный вызов для правого поддерева
            }

            return current;
        }

        public void PreorderTraversal()
        {
            PreorderTraversal(root);// Запуск прямого обхода с корня дерева
        }

        private void PreorderTraversal(TreeNode node)
        {
            if (node == null)// Если узел пустой, выходим из рекурсии
            {
                return;
            }

            Console.WriteLine(node.Value);// Вывод значения текущего узла
            PreorderTraversal(node.Left);// Рекурсивный вызов для левого поддерева
            PreorderTraversal(node.Right);// Рекурсивный вызов для правого поддерева
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();// Создание объекта двоичного дерева

            Console.WriteLine("Введите слова (для завершения введите пустую строку):");

            while (true)
            {
                string input = Console.ReadLine();// Чтение слова с клавиатуры

                if (string.IsNullOrEmpty(input))// Проверка на пустую строку для завершения ввода
                {
                    break;
                }

                binaryTree.Insert(input);// Вставка слова в дерево
            }

            Console.WriteLine("Прямой обход дерева:");

            binaryTree.PreorderTraversal();// Выполнение прямого обхода дерева и вывод результата
        }
    }
}