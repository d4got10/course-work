using Coursework_ServerLibrary;
using System;
using System.Collections.Generic;

namespace CourseWork_Server.DataStructures.Danil
{
    public class RedBlackTree<TKey, TValue> : ITreeFinder<TKey, TValue>, ITreeRangeFinder<TKey, TValue>, IDisplayable
        where TKey : IComparable<TKey> 
        where TValue : IEquatable<TValue>
    {
        #region Private Variables
        //Корень дерева
        private Node<TKey, TValue> _root;
        //Нулевой указатель
        private Node<TKey, TValue> _nil;

        //Количество сравнений
        private int _comparisons = 0;
        //Имя дерева, использующееся для отладки
        private string _name;
        #endregion

        #region Constructor
        //Конструктор объекта класса RedBlackTree
        //Формальные параметры: пусто
        //Входные данные: пусто
        //Выходные данные: объект класса RedBlackTree
        public RedBlackTree(string name)
        {
            _nil = new Node<TKey, TValue>();
            _root = _nil;
            _name = name;
        }
        #endregion

        #region Public Functions
        //TODO
        public IEnumerable<TValue> GetValuesRange(TKey min, TKey max)
        {
            var values = new List<TValue>();

            var minNode = _root;
            var maxNode = _root;
            while (minNode != _nil || maxNode != _nil)
            {
                if (minNode == maxNode)
                {
                    bool added = false;
                    bool goneLeft = false;
                    if (min.CompareTo(minNode.Key) < 0)
                    {
                        minNode = minNode.LeftChild;
                        goneLeft = true;
                    }
                    else if (min.CompareTo(minNode.Key) > 0)
                    {
                        minNode = minNode.RightChild;
                    }
                    else
                    {
                        foreach(var value in minNode.Values)
                            values.Add(value);
                        minNode = _nil;
                        added = true;
                    }

                    if(max.CompareTo(maxNode.Key) < 0)
                    {
                        maxNode = maxNode.LeftChild;
                    }
                    else if(max.CompareTo(maxNode.Key) > 0)
                    {
                        if (goneLeft)
                        {
                            foreach (var value in maxNode.Values)
                                values.Add(value);
                        }
                        maxNode = maxNode.RightChild;
                    }
                    else
                    {
                        if (added == false)
                        {
                            foreach (var value in maxNode.Values)
                                values.Add(value);
                        }
                        maxNode = _nil;
                        added = true;
                    }

                    if(minNode == maxNode)
                    {
                        if(added)
                            minNode = maxNode = _nil;
                    }
                }
                else
                {
                    if (minNode != null)
                    {
                        if(min.CompareTo(minNode.Key) < 0)
                        {
                            foreach (var value in minNode.Values)
                                values.Add(value);
                            GetValuesFromTree(minNode.RightChild, ref values);
                            minNode = minNode.LeftChild;
                        }
                        else if (min.CompareTo(minNode.Key) > 0)
                        {
                            minNode = minNode.RightChild;
                        }
                        else
                        {
                            foreach (var value in minNode.Values)
                                values.Add(value);
                            GetValuesFromTree(minNode.RightChild, ref values);
                            minNode = _nil;
                        }
                    }

                    if (maxNode != _nil)
                    {
                        if (max.CompareTo(maxNode.Key) < 0)
                        {
                            maxNode = maxNode.LeftChild;
                        }
                        else if (max.CompareTo(maxNode.Key) > 0)
                        {
                            foreach (var value in maxNode.Values)
                                values.Add(value);
                            GetValuesFromTree(maxNode.LeftChild, ref values);
                            maxNode = maxNode.RightChild;
                        }
                        else
                        {
                            foreach (var value in maxNode.Values)
                                values.Add(value);
                            GetValuesFromTree(maxNode.LeftChild, ref values);
                            maxNode = _nil;
                        }
                    }
                }
            }

            return values;
        }

        //TODO
        private void GetValuesFromTree(Node<TKey, TValue> root, ref List<TValue> values)
        {
            if (root == _nil) return;

            GetValuesFromTree(root.LeftChild, ref values);
            foreach(var value in root.Values)
            {
                values.Add(value);
            }
            GetValuesFromTree(root.RightChild, ref values);
        }

        //Метод поиска по значению
        //Формальные параметры: объект типа T
        //Входные данные: значение для поиска
        //Выходные данные: найден или нет + обьект или пустой указатель
        public bool TryFind(TKey key, out IEnumerable<TValue> found)
        {
            _comparisons = 0;
            var node = Find(key);
            if(node != null)
            {
                found = node.Values;
                return true;
            }
            found = default;
            return false;
        }

        //Метод удаления по значению
        //Формальные параметры: объект типа T
        //Входные данные: значение для удаления
        //Выходные данные: пусто
        public void Remove(TKey key, TValue value)
        {
            _comparisons = 0;
            var node = Find(key);
            node.Values.Remove(value);
            if (node.Values.IsEmpty())
            {
                Delete(node);
            } 
        }

        //Метод очистки дерева
        //Формальные параметры: пусто
        //Входные данные: объект класса RedBlackTree
        //Выходные данные: пусто
        public void Clear() => Clear(_root);

        //Метод прямого вывода дерева на экран
        //Формальные параметры: пусто
        //Входные данные: объект класса RedBlackTree
        //Выходные данные: Отображение дерева в консоли
        public void DisplayStraight()
        {
            DisplayTreeStraight(_root);
            Debug.WriteLine();
        }

        //Метод вывода дерева на экран
        //Формальные параметры: пусто
        //Входные данные: объект класса RedBlackTree
        //Выходные данные: Отображение дерева в консоли
        public void Display()
        {
            DisplayTree(_root, 0);
            Debug.WriteLine();
        }

        //Метод вывода дерева на экран
        //Формальные параметры: пусто
        //Входные данные: объект класса RedBlackTree
        //Выходные данные: Отображение дерева в консоли
        public void DisplayReverse()
        {
            DisplayTreeReverse(_root);
            Debug.WriteLine();
        }

        //Метод вывода дерева на экран
        //Формальные параметры: пусто
        //Входные данные: объект класса RedBlackTree
        //Выходные данные: Отображение дерева в консоли
        public void DisplaySimmetrical()
        {
            DisplayTreeSimmetrical(_root);
            Debug.WriteLine();
        }

        //Метод добавления значения
        //Формальные параметры: объект типа T
        //Входные данные: значение для добавления
        //Выходные данные: пусто
        public void Add(TKey key, TValue value)
        {
            var currentNode = _root;
            if(currentNode == _nil)
            {
                _root = new Node<TKey, TValue>(key, value, _nil);
                _root.IsBlack = true;
                return;
            }
            
            var parentNode = currentNode;
            while(currentNode != _nil)
            {
                parentNode = currentNode;
                if (currentNode.Key.CompareTo(key) > 0)
                    currentNode = currentNode.LeftChild;
                else if (currentNode.Key.CompareTo(key) < 0)
                    currentNode = currentNode.RightChild;
                else
                {
                    currentNode.Values.Add(value);
                    return;
                }
            }

            bool isLeftChild = parentNode.Key.CompareTo(key) >= 0;

            var node = new Node<TKey, TValue>(key, value, parentNode, isLeftChild, _nil);
            InsertCase1(node);
        }
        #endregion

        #region Delete Private Functions
        //Метод перестановки двух узлов
        //Формальные параметры: объект типа Node<T>, объект типа Node<T> 
        //Входные данные: два узла дерева
        //Выходные данные: пусто
        private void Transplant(Node<TKey, TValue> u, Node<TKey, TValue> v)
        {
            if (u.Parent == _nil)
                _root = v;
            else if (u == u.Parent.LeftChild)
                u.Parent.LeftChild = v;
            else
                u.Parent.RightChild = v;
            v.Parent = u.Parent;
        }

        //Метод удаления узла из дерева
        //Формальные параметры: объект типа Node<T>
        //Входные данные: узел для удаления
        //Выходные данные: пусто
        private void Delete(Node<TKey, TValue> z)
        {
            var y = z;
            bool yWasBlack = y.IsBlack;
            Node<TKey, TValue> x;
            if(z.LeftChild == _nil)
            {
                x = z.RightChild;
                Transplant(z, z.RightChild);
            }
            else if(z.RightChild == _nil)
            {
                x = z.LeftChild;
                Transplant(z, z.LeftChild);
            }
            else
            {
                y = FindMinimum(z.RightChild);
                yWasBlack = y.IsBlack;
                x = y.RightChild;
                if(y.Parent == z)
                {
                    x.Parent = y;
                }
                else
                {
                    Transplant(y, y.RightChild);
                    y.RightChild = z.RightChild;
                    y.RightChild.Parent = y;
                }
                Transplant(z, y);
                y.LeftChild = z.LeftChild;
                y.LeftChild.Parent = y;
                y.IsBlack = z.IsBlack;
            }
            if (yWasBlack)
                DeleteFixup(x);
        }

        //Метод ребалансировки дерева при удалении
        //Формальные параметры: объект типа Node<T>
        //Входные данные: узел для которого будет проведена ребалансировка
        //Выходные данные: пусто
        private void DeleteFixup(Node<TKey, TValue> x)
        {
            Node<TKey, TValue> w;
            while(x != _root && x.IsBlack)
            {
                if(x == x.Parent.LeftChild)
                {
                    w = x.Parent.RightChild;
                    if(w.IsBlack == false)
                    {
                        w.IsBlack = true;
                        x.Parent.IsBlack = false;
                        RotateLeft(x.Parent);
                        w = x.Parent.RightChild;
                    }
                    if(w.LeftChild.IsBlack && w.RightChild.IsBlack)
                    {
                        w.IsBlack = false;
                        x = x.Parent;
                    }
                    else
                    {
                        if (w.RightChild.IsBlack)
                        {
                            w.LeftChild.IsBlack = true;
                            w.IsBlack = false;
                            RotateRight(w);
                            w = x.Parent.RightChild;
                        }

                        w.IsBlack = x.Parent.IsBlack;
                        x.Parent.IsBlack = true;
                        w.RightChild.IsBlack = true;
                        RotateLeft(x.Parent);
                        x = _root;
                    }
                }
                else
                {
                    w = x.Parent.LeftChild;
                    if (w.IsBlack == false)
                    {
                        w.IsBlack = true;
                        x.Parent.IsBlack = false;
                        RotateRight(x.Parent);
                        w = x.Parent.LeftChild;
                    }
                    if (w.RightChild.IsBlack && w.LeftChild.IsBlack)
                    {
                        w.IsBlack = false;
                        x = x.Parent;
                    }
                    else
                    {
                        if (w.LeftChild.IsBlack)
                        {
                            w.RightChild.IsBlack = true;
                            w.IsBlack = false;
                            RotateLeft(w);
                            w = x.Parent.LeftChild;
                        }

                        w.IsBlack = x.Parent.IsBlack;
                        x.Parent.IsBlack = true;
                        w.LeftChild.IsBlack = true;
                        RotateRight(x.Parent);
                        x = _root;
                    }
                }
            }
            x.IsBlack = true;
        }

        //Метод нахождения узла с минимальным значением в поддереве
        //Формальные параметры: объект типа Node<T>
        //Входные данные: корень поддерева
        //Выходные данные: узел с минимальным значением
        private Node<TKey, TValue> FindMinimum(Node<TKey, TValue> root)
        {
            Node<TKey, TValue> currentNode = root;
            while (currentNode.LeftChild != _nil)
                currentNode = currentNode.LeftChild;
            return currentNode;
        }

        #endregion

        #region Insert Private Functions

        //Метод ребалансировки при добавлении значения (1 случай)
        //Формальные параметры: объект типа Node<T>
        //Входные данные: узел, который был добавлен
        //Выходные данные: пусто
        private void InsertCase1(Node<TKey, TValue> node)
        {
            if (node.Parent == _nil)
                node.IsBlack = true;
            else if (node.GrandParent == _nil)
                node.Parent.IsBlack = true;
            else
                InsertCase2(node);
        }

        //Метод ребалансировки при добавлении значения (2 случай)
        //Формальные параметры: объект типа Node<T>
        //Входные данные: узел, который был добавлен
        //Выходные данные: пусто
        private void InsertCase2(Node<TKey, TValue> node)
        {
            if (node.Parent.IsBlack)
                return;
            else
                InsertCase3(node);
        }

        //Метод ребалансировки при добавлении значения (3 случай)
        //Формальные параметры: объект типа Node<T>
        //Входные данные: узел, который был добавлен
        //Выходные данные: пусто
        private void InsertCase3(Node<TKey, TValue> node)
        {
            if (node.Uncle != _nil && node.Uncle.IsBlack == false)
            {
                node.Parent.IsBlack = true;
                node.Uncle.IsBlack = true;
                node.GrandParent.IsBlack = false;

                InsertCase1(node.GrandParent);
            }
            else
                InsertCase4(node);
        }

        //Метод ребалансировки при добавлении значения (4 случай)
        //Формальные параметры: объект типа Node<T>
        //Входные данные: узел, который был добавлен
        //Выходные данные: пусто
        private void InsertCase4(Node<TKey, TValue> node)
        {
            if(node == node.Parent.RightChild && node.Parent == node.GrandParent.LeftChild)
            {
                RotateLeft(node.Parent);

                node = node.LeftChild;
            }
            else if (node == node.Parent.LeftChild && node.Parent == node.GrandParent.RightChild)
            {
                RotateRight(node.Parent);

                node = node.RightChild;
            }

            InsertCase5(node);
        }

        //Метод ребалансировки при добавлении значения (5 случай)
        //Формальные параметры: объект типа Node<T>
        //Входные данные: узел, который был добавлен
        //Выходные данные: пусто
        private void InsertCase5(Node<TKey, TValue> node)
        {
            node.Parent.IsBlack = true;
            node.GrandParent.IsBlack = false;

            if(node == node.Parent.LeftChild && node.Parent == node.GrandParent.LeftChild)
            {
                RotateRight(node.GrandParent);
            }
            else
            {
                RotateLeft(node.GrandParent);
            }
        }

        #endregion

        #region Rotate Functions
        //Метод правого поворота дерева вокруг узла
        //Формальные параметры: объект типа RedBlackTree, объект типа Node<T>
        //Входные данные: узел вокруг, которого будет поворот
        //Выходные данные: пусто
        private void RotateRight(Node<TKey, TValue> node)
        {
            var pivot = node.LeftChild;

            pivot.Parent = node.Parent;
            if (node.Parent != _nil)
                if (node.Parent.LeftChild == node)
                    node.Parent.LeftChild = pivot;
                else
                    node.Parent.RightChild = pivot;

            node.LeftChild = pivot.RightChild;
            if (pivot.RightChild != _nil)
                pivot.RightChild.Parent = node;

            node.Parent = pivot;
            pivot.RightChild = node;

            if (pivot.Parent == _nil)
                _root = pivot;
        }

        //Метод левого поворота дерева вокруг узла
        //Формальные параметры: объект типа RedBlackTree, объект типа Node<T>
        //Входные данные: узел вокруг, которого будет поворот
        //Выходные данные: пусто
        private void RotateLeft(Node<TKey, TValue> node)
        {
            var pivot = node.RightChild;

            pivot.Parent = node.Parent;
            if (node.Parent != _nil)
                if (node.Parent.LeftChild == node)
                    node.Parent.LeftChild = pivot;
                else
                    node.Parent.RightChild = pivot;

            node.RightChild = pivot.LeftChild;
            if (pivot.LeftChild != _nil)
                pivot.LeftChild.Parent = node;

            node.Parent = pivot;
            pivot.LeftChild = node;

            if (pivot.Parent == _nil)
                _root = pivot;
        }
        #endregion

        #region Private Functions
        private void GetValuesRangeInternal(Node<TKey, TValue> root, TKey min, TKey max, List<TValue> values)
        {
            if (root != _nil)
            {
                //Если текущий не является левой границей диапозона и имеет левого потомка идем в него
                if (root.LeftChild != _nil && root.Key.CompareTo(min) >= 0) 
                    GetValuesRangeInternal(root.LeftChild, min, max, values);

                //Если текущий входит в диапозон то добавляем его в список значений
                if (root.Key.CompareTo(min) >= 0 && root.Key.CompareTo(max) <= 0)
                {
                    foreach(var value in root.Values)
                    {
                        values.Add(value);
                    }
                }

                //Если текущий не является правой границей диапозона и имеет правого потомка идем в него
                if (root.RightChild != _nil && root.Key.CompareTo(max) <= 0) 
                    GetValuesRangeInternal(root.RightChild, min, max, values);
            }
        }

        //Метод нахождения узла по значению
        //Формальные параметры: объект типа RedBlackTree, объект типа T
        //Входные данные: значение для поиска
        //Выходные данные: узел с заданным значением
        private Node<TKey, TValue> Find(TKey key)
        {
            var node = _root;
            while(node != _nil)
            {
                if (node.Key.CompareTo(key) > 0)
                {
                    node = node.LeftChild;
                    _comparisons += 1;
                }
                else if (node.Key.CompareTo(key) < 0)
                {
                    node = node.RightChild;
                    _comparisons += 2;
                }
                else
                {
                    _comparisons += 2;
                    Debug.WriteLine($"ДАННЫЕ [{_name}]: поиск потребовал {_comparisons} сравнений");
                    return node;
                }
            }
            Debug.WriteLine($"ДАННЫЕ [{_name}]: поиск потребовал {_comparisons} сравнений");
            return null;
        }

        //Метод обратного вывода поддерева
        //Формальные параметры: обьект типа Node<T>
        //Входные данные: корень поддерева
        //Выходные данные: вывод поддерева в консоль
        private void DisplayTree(Node<TKey, TValue> root, int tabs)
        {
            if (root == _nil) return;

            if (root.RightChild != _nil)
            {
                DisplayTree(root.RightChild, tabs+1);
            }
            for (int i = 0; i < tabs; i++) Debug.Write("\t");
            Debug.WriteLine($"{root.Key}_{(root.IsBlack ? "B" : "R")} ");
            if (root.LeftChild != _nil)
            {
                DisplayTree(root.LeftChild, tabs+1);
            }
        }

        //Метод обратного вывода поддерева
        //Формальные параметры: обьект типа Node<T>
        //Входные данные: корень поддерева
        //Выходные данные: вывод поддерева в консоль
        private void DisplayTreeReverse(Node<TKey, TValue> root)
        {
            if (root == _nil) return;

            if (root.LeftChild != _nil)
            {
                DisplayTreeReverse(root.LeftChild);
            }
            if (root.RightChild != _nil)
            {
                DisplayTreeReverse(root.RightChild);
            }
            Debug.Write($"{root.Key} ");
        }

        //Метод симметричного вывода поддерева
        //Формальные параметры: обьект типа Node<T>
        //Входные данные: корень поддерева
        //Выходные данные: вывод поддерева в консоль
        private void DisplayTreeSimmetrical(Node<TKey, TValue> root)
        {
            if (root == _nil) return;

            if (root.LeftChild != _nil)
            {
                DisplayTreeSimmetrical(root.LeftChild);
            }
            Debug.Write($"{root.Key} ");
            if (root.RightChild != _nil)
            {
                DisplayTreeSimmetrical(root.RightChild);
            }
        }

        //Метод прямого вывода поддерева
        //Формальные параметры: обьект типа Node<T>
        //Входные данные: корень поддерева
        //Выходные данные: вывод поддерева в консоль
        private void DisplayTreeStraight(Node<TKey, TValue> root)
        {
            if (root == _nil) return;

            Debug.Write($"{root.Key}_{(root.IsBlack ? "B" : "R")} ");
            if (root.LeftChild != _nil)
            {
                DisplayTreeStraight(root.LeftChild);
            }
            if (root.RightChild != _nil)
            {
                DisplayTreeStraight(root.RightChild);
            }
        }

        //Метод очистки поддерева
        //Формальные параметры: объект типа Node<T>
        //Входные данные: корень поддерева
        //Выходные данные: пусто
        private void Clear(Node<TKey, TValue> root)
        {
            if (root != _nil)
            {
                if (root.LeftChild != _nil) Clear(root.LeftChild);
                if (root.RightChild != _nil) Clear(root.RightChild);
                root.Dispose();
            }
        }
        #endregion

        #region Internal Node Class
        private class Node<UKey, UValue> : IDisposable where UValue : IEquatable<UValue>
        {
            public readonly UKey Key;
            public List<UValue> Values;

            public Node<UKey, UValue> LeftChild;
            public Node<UKey, UValue> RightChild;
            public Node<UKey, UValue> Parent;

            public bool IsBlack;

            public Node<UKey, UValue> Sibling
            {
                get
                {
                    if (Parent.LeftChild == this)
                        return Parent.RightChild;
                    else
                        return Parent.LeftChild;
                }
            }

            public Node<UKey, UValue> Uncle
            {
                get
                {
                    if (GrandParent.LeftChild == Parent)
                        return GrandParent.RightChild;
                    else 
                        return GrandParent.LeftChild;
                }
            }

            public Node<UKey, UValue> GrandParent
            {
                get
                {
                    return Parent.Parent;
                }
            }

            //Конструктор объекта класса Node
            //Формальные параметры: пусто
            //Входные данные: пусто
            //Выходные данные: объект класса Node
            public Node()
            {
                Values = new List<UValue>();
                LeftChild = this;
                RightChild = this;
                Parent = this;
                IsBlack = true;
            }

            //Конструктор объекта класса Node
            //Формальные параметры: объект класса U, объект класса Node<U>
            //Входные данные: значение узла, nil-узел
            //Выходные данные: объект класса Node
            public Node(UKey key, UValue value, Node<UKey, UValue> nil)
            {
                Key = key;
                Values = new List<UValue>();
                Values.Add(value);
                LeftChild = nil;
                RightChild = nil;
                Parent = nil;
                IsBlack = false;
            }

            //Конструктор объекта класса Node
            //Формальные параметры: объект класса U, объект класса Node<U>, логическая переменная, объект класса Node<U>
            //Входные данные: значение узла, nil-узел
            //Выходные данные: объект класса Node
            public Node(UKey key, UValue value, Node<UKey, UValue> parent, bool isLeftChild, Node<UKey, UValue> nil)
            {
                Key = key;
                Values = new List<UValue>();
                Values.Add(value);
                LeftChild = nil;
                RightChild = nil;
                Parent = parent;

                if (parent != null)
                    if (isLeftChild)
                        parent.LeftChild = this;
                    else
                        parent.RightChild = this;

                IsBlack = false;
            }

            //Метод очистки полей узла
            //Формальные параметры: пусто
            //Входные данные: объект класса Node
            //Выходные данные: пусто
            public void Dispose()
            {
                Values = null;
                LeftChild = null;
                RightChild = null;
                Parent = null;
            }

            //Метод добавления значения в список узла
            //Формальные параметры: UValue
            //Входные данные: объект класса Node, значение для добавления
            //Выходные данные: пусто
            public void Add(UValue value) => Values.Add(value);

            //Метод удаления значения из списка узла
            //Формальные параметры: UValue
            //Входные данные: объект класса Node, значение для удаления
            //Выходные данные: пусто
            public void Remove(UValue value) => Values.Remove(value);
        }

        #endregion
    }
}
