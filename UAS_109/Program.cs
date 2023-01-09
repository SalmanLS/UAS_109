using System;

namespace UAS
{
    class Node
    {
        public int nomorB;
        public string namaB;
        public string namaP;
        public string tahunT;
        public Node next;
    }

    class List
    {
        Node START;

        public List()
        {
            START = null;
        }

        public void addBook()
        {
            int noB;
            string naB;
            string naP;
            string taT;
            Console.Write("Enter Book Number :");
            noB = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Book Name :");
            naB = Console.ReadLine();
            Console.Write("Enter Writer Name :");
            naP = Console.ReadLine();
            Console.Write("Enter Year :");
            taT= Console.ReadLine();

            Node newNode = new Node();  
            newNode.nomorB = noB;
            newNode.namaB = naB;
            newNode.namaP = naP;
            newNode.tahunT = taT;

            if (START == null || noB <= START.nomorB)
            {
                if ((START != null) && noB == START.nomorB)
                {
                    Console.WriteLine("The Number Book is Used! ");
                }
                newNode.next = START;
                START = newNode;
                return;

            }

            Node previous, current;

            for (current = previous = START; current != null && noB >= current.nomorB; previous = current, current = current)
            {
                if (noB == current.nomorB)
                {
                    Console.WriteLine("The Number Book is Used! ");
                    return;
                }
            }
            newNode.next = current;
            previous.next = newNode;

            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            newNode.next = current;
            previous.next = newNode;
            
        }

        public bool Search(string taT, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (string.Compare(taT,current.tahunT) <0 || string.Compare(taT, current.tahunT) >0))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        public void displayAllB()
        {
            if (listEmpty())
            {
                Console.WriteLine("\n Library data book is empty! ");
            }
            else
            {
                Console.WriteLine("\n Current updated data : ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next) 
                    Console.WriteLine(currentNode.nomorB + " " + currentNode.namaB + " " + currentNode.namaP + " " + currentNode.tahunT + "\n");
                Console.WriteLine();
            }
        }
        public void searchedDisplay(string taT, ref Node previous, ref Node current)
        {
            for (current = previous = START; current != null && string.Compare(taT, current.tahunT) == 0; previous = current, current = current.next)
            {
                Console.WriteLine(" -> " + current.tahunT + "  " + current.nomorB + "  " + current.namaB + "  " + current.namaP + "  ");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List perpus = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n M E N U ");
                    Console.WriteLine("1. Add new book record");
                    Console.WriteLine("2. View all the book record");
                    Console.WriteLine("3. Search for a book");
                    Console.WriteLine("4. Exit");
                    Console.Write("Please enter your choice (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                perpus.addBook();
                            }
                            break;
                        case '2':
                            {
                                perpus.displayAllB();
                            }
                            break;
                        case '3':
                            {
                                if (perpus.listEmpty() == true)
                                {
                                    Console.WriteLine("\n The data is still empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.WriteLine("Enter the year of publication : ");
                                string year = (Console.ReadLine());
                                if (perpus.Search(year, ref previous, ref current) == false)
                                {
                                    Console.WriteLine("\n The book not found");
                                }
                                else
                                {
                                    Console.WriteLine(" - Found! - ");
                                    perpus.searchedDisplay(year, ref previous, ref current);
                                }
                                break;
                            }
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid choice");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\n Check again! something is wrong");
                }
            }
        }
    }
}

// JAWABAN NO 2 - 5
// 2. Single Linked List
// 3. POP dan PUSH
// 4. 
// 5. a. 5 kedalaman
//    b. Inorder Traversa = 1,5,8,10,12,15,20,22,25,28,30,36,38,40,45,48,50